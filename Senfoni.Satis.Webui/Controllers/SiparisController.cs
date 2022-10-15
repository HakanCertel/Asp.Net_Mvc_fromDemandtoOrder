using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Senfoni.Data.Concrete.EfCore;
using Senfoni.Data.Concrete.EfCore.GenelBll;
using Senfoni.Entity;
using Senfoni.Entity.Dto;
using Senfoni.Satis.Webui.Extensions;
using Senfoni.Satis.Webui.Identity;
using Senfoni.Satis.Webui.Models;

namespace Senfoni.Satis.Webui.Controllers
{
    public class SiparisController : Controller
    {
        private IBaseBll Bll;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public SiparisController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            Bll = new SiparisBll();
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Insert(long? id)
        {
            var caribll = GenerealFunctions.CreateInstanceOfBll<CariBll>();
            //if (RouteData.Values["action"].ToString() != "StokSecim")
            if (id != null)
            {
                var eleman = SiparisModel.SiparisBilgileri.Find(x => x.StokId == id);
                SiparisModel.SiparisBilgileri.Remove(eleman);
            }
            if (!SiparisModel.KayitInsert)
            {
                SiparisModel.CariList = caribll.List(null).EntityListConvert<Cari>().ToList();
                SiparisModel.SiparisBilgileri.Clear();
                SiparisModel.ListeDisiTutulacakKayitlar.Clear();
                SiparisModel.SiparisId = GeneralFunctions.IdOlustur();
                SiparisModel.SiparisKod = ((SiparisBll)Bll).YeniKodVer();
                
                SiparisModel.KayitInsert = true;
                SiparisModel.KayitUpdate = false;
            }
            var siparisKayitModel = new SiparisKayitModel
            {
                Id = SiparisModel.SiparisId,
                Kod = SiparisModel.SiparisKod,
                SiparisTarihi =/*SiparisModel.SiparisTarihi==null? DateTime.Today:*/ SiparisModel.SiparisTarihi,
                TeslimTarihi = SiparisModel.TeslimTarihi == null ? DateTime.Today : SiparisModel.TeslimTarihi,
                SiparisBilgileriL = SiparisModel.SiparisBilgileri,
            };
            ViewBag.CariList = new SelectList(SiparisModel.CariList, "Id", "CariAdi");

            return View(siparisKayitModel);
        }
        public IActionResult TeklifBilgileriAl(long?[] stokIds, decimal?[] quantities,DateTime siparisTarihi,DateTime teslimTarihi)
        {
            if (stokIds != null)
            {
                var caribll = GenerealFunctions.CreateInstanceOfBll<CariBll>();
                SiparisModel.CariList = caribll.List(null).EntityListConvert<Cari>().ToList();
                SiparisModel.SiparisBilgileri.Clear();
                SiparisModel.ListeDisiTutulacakKayitlar.Clear();
                SiparisModel.SiparisId = GeneralFunctions.IdOlustur();
                SiparisModel.SiparisKod = ((SiparisBll)Bll).YeniKodVer();
                SiparisModel.SiparisTarihi = siparisTarihi;
                SiparisModel.TeslimTarihi = teslimTarihi;
                SiparisModel.KayitInsert = true;
                SiparisModel.KayitUpdate = false;
                for (int i = 0; i < stokIds.Count(); i++)
                {
                    var stok = GenerealFunctions.FindStok((long)stokIds[i]);
                    var siparisBilgisi = new SiparisBilgileriL
                    {
                        StokId = stok.Id,
                        StokKodu = stok.Kod,
                        StokAdi = stok.StokAdi,
                        FiyatBirim = stok.FiyatBirim,
                        Fiyat = stok.Fiyat,
                        TalepMiktari = (decimal)quantities[i]
                    };
                    SiparisModel.ListeDisiTutulacakKayitlar.Add(stok.Id);
                    SiparisModel.SiparisBilgileri.Add(siparisBilgisi);
                }
            }
            return Redirect("Insert");
        }
        [HttpPost]
        public IActionResult Insert(SiparisInsertModel model)
        {
            var siparisBilgileri = new List<SiparisBilgileriL>();

            var siparisBilgileriBll = GenerealFunctions.CreateInstanceOfBll<SiparisBilgileriBll>();
            for (int i = 0; i < model.StokIds.Length; i++)
            {
                var siparisBilgisi = SiparisModel.SiparisBilgileri.Find(x => x.StokId == model.StokIds[i]);

                siparisBilgisi.TalepMiktari = model.Miktarlar[i];
                siparisBilgisi.SiparisId = model.Id;
                siparisBilgisi.KullaniciId = _userManager.GetUserId(User);
                siparisBilgisi.CariId = model.CariId;
                siparisBilgisi.SiparisTarihi = model.SiparisTarihi;
                siparisBilgisi.TeslimTarihi = model.TeslimTarihi;

                siparisBilgileri.Add(siparisBilgisi);
            }
            var siparis = new Siparis
            {
                Id = SiparisModel.SiparisId,
                Kod = SiparisModel.SiparisKod,
                CariId = model.CariId,
                KullaniciId = _userManager.GetUserId(User),
                SiparisTarihi = model.SiparisTarihi,
                TeslimTarihi = model.TeslimTarihi,
            };
            //var lknd = ((SiparisBll)Bll).Insert(siparis);
            //var sdj= siparisBilgileriBll.BaseInsert(siparisBilgileri);
            if (!((SiparisBll)Bll).Insert(siparis) || !siparisBilgileriBll.BaseInsert(siparisBilgileri))
            {
                return View();
            }
            SiparisModel.KayitInsert = false;
            return RedirectToAction("SiparisList");
        }
        public IActionResult SiparisEdit(long? siparisId)
        {
            if (siparisId != null)
            {
                SiparisModel.SiparisId = (long)siparisId;

                var caribll = GenerealFunctions.CreateInstanceOfBll<CariBll>();
                var siparisBilgileriBll = GenerealFunctions.CreateInstanceOfBll<SiparisBilgileriBll>();
                SiparisModel.SiparisS = ((SiparisBll)Bll).Single(x => x.Id == SiparisModel.SiparisId).EntityConvert<SiparisS>();

                SiparisModel.CariList = caribll.List(null).EntityListConvert<Cari>().ToList();
                SiparisModel.SiparisBilgileri = siparisBilgileriBll.List(x => x.SiparisId == SiparisModel.SiparisId).EntityListConvert<SiparisBilgileriL>().ToList();
                SiparisModel.ListeDisiTutulacakKayitlar = SiparisModel.SiparisBilgileri.Select(x => x.StokId).ToList();
                SiparisModel.KayitUpdate = true;
                SiparisModel.KayitInsert = false;
            }
            var siparisEditModel = new SiparisEditModel
            {
                Id = SiparisModel.SiparisS.Id,
                Kod = SiparisModel.SiparisS.Kod,
                SiparisTarihi = SiparisModel.SiparisS.SiparisTarihi,
                TeslimTarihi = SiparisModel.SiparisS.TeslimTarihi,
                CariId = SiparisModel.SiparisS.CariId,
                StokIds = SiparisModel.SiparisBilgileri.Select(x => x.StokId).ToArray(),
                StokKodu = SiparisModel.SiparisBilgileri.Select(x => x.StokKodu).ToList(),
                StokAdi = SiparisModel.SiparisBilgileri.Select(x => x.StokAdi).ToList(),
                Miktarlar = SiparisModel.SiparisBilgileri.Select(x => x.TalepMiktari).ToArray()
            };
            ViewBag.CariList = new SelectList(SiparisModel.CariList, "Id", "CariAdi");
            return View(siparisEditModel);
        }

        [HttpPost]
        public IActionResult SiparisEdit(SiparisEditModel model)
        {
            var siparisBilgileri = new List<SiparisBilgileriL>();

            var siparisBilgileriBll = GenerealFunctions.CreateInstanceOfBll<SiparisBilgileriBll>();
            for (int i = 0; i < model.StokIds.Length; i++)
            {
                var siparisBilgisi = SiparisModel.SiparisBilgileri.Find(x => x.StokId == model.StokIds[i]);

                siparisBilgisi.TalepMiktari = model.Miktarlar[i];
                siparisBilgisi.SiparisId = model.Id;
                siparisBilgisi.KullaniciId = _userManager.GetUserId(User);
                siparisBilgisi.CariId = model.CariId;
                siparisBilgisi.SiparisTarihi = model.SiparisTarihi;
                siparisBilgisi.TeslimTarihi = model.TeslimTarihi;

                siparisBilgileri.Add(siparisBilgisi);
            }
            var oldSiparis = ((SiparisBll)Bll).Single(x => x.Id == model.Id);
            var currentSiparis = new Siparis
            {
                Id = model.Id,
                Kod = model.Kod,
                CariId = model.CariId,
                KullaniciId = _userManager.GetUserId(User),
                SiparisTarihi = model.SiparisTarihi,
                TeslimTarihi = model.TeslimTarihi,
            };
            if (!((SiparisBll)Bll).Update(oldSiparis, currentSiparis) || !siparisBilgileriBll.BaseUpdate(siparisBilgileri))
            {
                return View();
            }
            return RedirectToAction("SiparisList");
        }
        public IActionResult SiparisEditHareketSil(long? stokId)
        {
            var eleman = SiparisModel.SiparisBilgileri.Find(x => x.StokId == stokId);
            var siparisBilgileriBll = GenerealFunctions.CreateInstanceOfBll<SiparisBilgileriBll>();

            siparisBilgileriBll.BaseDelete(eleman);
            SiparisModel.SiparisBilgileri.Remove(eleman);

            return RedirectToAction("SiparisEdit");
        }
        public IActionResult SiparisList()
        {
            var siparisList = new List<SiparisL>();
            var kullaniciId = _userManager.GetUserId(User);
            
            if (User.IsInRole("admin"))
            {
                siparisList = ((SiparisBll)Bll).List(null).EntityListConvert<SiparisL>().ToList();
                return View(siparisList);
            }
            else
            {
                siparisList = ((SiparisBll)Bll).List(x => !x.Kapandi && x.KullaniciId == kullaniciId).EntityListConvert<SiparisL>().ToList();
                return View(siparisList);
            }

        }
        public IActionResult StokSecim(long? id)
        {
            if (id != null)
            {
                SiparisModel.ListeDisiTutulacakKayitlar.Add((long)id);
                using (var bll = new StokBll())
                {
                    var stok = bll.Single(x => x.Id == id).EntityConvert<Stok>();
                    var tek = new SiparisBilgileriL
                    {
                        StokId = stok.Id,
                        StokKodu = stok.Kod,
                        StokAdi = stok.StokAdi,
                        TalepMiktari = 0,
                        FiyatBirim = stok.FiyatBirim,
                        Fiyat = stok.Fiyat,
                        //TeklifId = TeklifModel.Teklif.Id,
                    };
                    SiparisModel.SiparisBilgileri.Add(tek);
                }
            }
            var stokSecimModel = new StokSecimModel
            {
                ListelenecekKayitlar = SiparisModel.ListeDisiTutulacakKayitlar.ListelenecekKayitlar<Stok, StokBll>().EntityListConvert<StokL>(),
                KayitInsert = SiparisModel.KayitInsert,
                KayitUpdate = SiparisModel.KayitUpdate
            };
            return View(stokSecimModel);
        }

        private List<StokL> StokList(List<long> listeDisiKayitlar)
        {
            List<StokL> stokList = new List<StokL>();
            using (var stokBll = new StokBll())
            {
                if (SiparisModel.ListeDisiTutulacakKayitlar != null)
                {
                    stokList = stokBll.List(x => !SiparisModel.ListeDisiTutulacakKayitlar.Contains(x.Id)).EntityListConvert<StokL>().ToList();
                }
                else
                    stokList = stokBll.List(null).EntityListConvert<StokL>().ToList();

                return stokList;
            }
        }

    }
}