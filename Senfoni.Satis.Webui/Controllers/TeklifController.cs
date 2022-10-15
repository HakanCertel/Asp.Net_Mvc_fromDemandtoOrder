using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
//return RedirectToAction( "Main", new RouteValueDictionary(
//    new { controller = controllerName, action = "Main", Id = Id, extraParam = someVariable } ) );
namespace Senfoni.Satis.Webui.Controllers
{
    [Authorize]
    public class TeklifController : Controller
    {
        private IBaseBll Bll;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public TeklifController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            Bll = new TeklifBll();
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Insert(long? id)
        {
            var caribll = GenerealFunctions.CreateInstanceOfBll<CariBll>();
            //if (RouteData.Values["action"].ToString() != "StokSecim")
            if (id != null)
            {
                var eleman = TeklifModel.TeklifBilgileri.Find(x => x.StokId == id);
                TeklifModel.TeklifBilgileri.Remove(eleman);
            }
            if (!TeklifModel.KayitInsert)
            {
                TeklifModel.CariList = caribll.List(null).EntityListConvert<Cari>().ToList();
                TeklifModel.TeklifBilgileri.Clear();
                TeklifModel.ListeDisiTutulacakKayitlar.Clear();
                TeklifModel.TekilfId = GeneralFunctions.IdOlustur();
                TeklifModel.TeklifKod = ((TeklifBll)Bll).YeniKodVer();
                TeklifModel.KayitInsert = true;
                TeklifModel.KayitUpdate = false;
            }
            var teklifKayitModel = new TeklifKayitModel
            {
                Id = TeklifModel.TekilfId,
                Kod = TeklifModel.TeklifKod,
                SiparisTarihi = DateTime.Today,
                TeslimTarihi = DateTime.Today,
                TeklifBilgileriL = TeklifModel.TeklifBilgileri,
            };
            ViewBag.CariList = new SelectList(TeklifModel.CariList, "Id", "CariAdi");

            return View(teklifKayitModel);
        }

        [HttpPost]
        public IActionResult Insert(TeklifInsertModel model)
        {
            var teklifBilgileri = new List<TeklifBilgileriL>();

            var teklifBilgileriBll = GenerealFunctions.CreateInstanceOfBll<TeklifBilgileriBll>();
            for (int i = 0; i < model.StokIds.Length; i++)
            {
                var teklifBilgisi = TeklifModel.TeklifBilgileri.Find(x => x.StokId == model.StokIds[i]);

                teklifBilgisi.TalepMiktari= model.Miktarlar[i];
                teklifBilgisi.TeklifId = model.Id;
                teklifBilgisi.KullaniciId = _userManager.GetUserId(User);
                teklifBilgisi.CariId = model.CariId;
                teklifBilgisi.SiparisTarihi = model.SiparisTarihi;
                teklifBilgisi.TeslimTarihi = model.TeslimTarihi;

                teklifBilgileri.Add(teklifBilgisi);
            }
            var teklif = new Teklif
            {
                Id=model.Id,
                Kod=model.Kod,
                CariId=model.CariId,
                KullaniciId= _userManager.GetUserId(User),
                SiparisTarihi =model.SiparisTarihi,
                TeslimTarihi=model.TeslimTarihi,
            };
            if (!((TeklifBll)Bll).Insert(teklif)||!teklifBilgileriBll.BaseInsert(teklifBilgileri))
            {
                return View();
            }
            TeklifModel.KayitInsert = false;
            return RedirectToAction("TeklifList");
        }
        public IActionResult TeklifEdit(long? teklifId)
        {
            if (teklifId != null)
            {
                TeklifModel.TekilfId = (long)teklifId;

                var caribll = GenerealFunctions.CreateInstanceOfBll<CariBll>();
                var teklifBilgileriBll = GenerealFunctions.CreateInstanceOfBll<TeklifBilgileriBll>();
                TeklifModel.teklif = ((TeklifBll)Bll).Single(x => x.Id == TeklifModel.TekilfId).EntityConvert<TeklifS>();

                TeklifModel.CariList = caribll.List(null).EntityListConvert<Cari>().ToList();
                TeklifModel.TeklifBilgileri = teklifBilgileriBll.List(x => x.TeklifId == TeklifModel.TekilfId).EntityListConvert<TeklifBilgileriL>().ToList();
                TeklifModel.ListeDisiTutulacakKayitlar = TeklifModel.TeklifBilgileri.Select(x => x.StokId).ToList();
                TeklifModel.KayitInsert = false;
                TeklifModel.KayitUpdate = true;
            }
            var teklifEditModel = new TeklifEditModel
            {
                Id = TeklifModel.teklif.Id,
                Kod = TeklifModel.teklif.Kod,
                SiparisTarihi = TeklifModel.teklif.SiparisTarihi,
                TeslimTarihi = TeklifModel.teklif.TeslimTarihi,
                CariId = TeklifModel.teklif.CariId,
                StokIds = TeklifModel.TeklifBilgileri.Select(x => x.StokId).ToArray(),
                StokKodu= TeklifModel.TeklifBilgileri.Select(x=>x.StokKodu).ToList(),
                StokAdi= TeklifModel.TeklifBilgileri.Select(x=>x.StokAdi).ToList(),
                Miktarlar = TeklifModel.TeklifBilgileri.Select(x=>x.TalepMiktari).ToArray()
            };
            ViewBag.CariList = new SelectList(TeklifModel.CariList, "Id", "CariAdi");
            return View(teklifEditModel);
        }

        [HttpPost]
        public IActionResult TeklifEdit(TeklifEditModel model)
        {
            var teklifBilgileri = new List<TeklifBilgileriL>();

            var teklifBilgileriBll = GenerealFunctions.CreateInstanceOfBll<TeklifBilgileriBll>();
            for (int i = 0; i < model.StokIds.Length; i++)
            {
                var teklifBilgisi = TeklifModel.TeklifBilgileri.Find(x => x.StokId == model.StokIds[i]);

                teklifBilgisi.TalepMiktari = model.Miktarlar[i];
                teklifBilgisi.TeklifId = model.Id;
                teklifBilgisi.KullaniciId = _userManager.GetUserId(User);
                teklifBilgisi.CariId = model.CariId;
                teklifBilgisi.SiparisTarihi = model.SiparisTarihi;
                teklifBilgisi.TeslimTarihi = model.TeslimTarihi;

                teklifBilgileri.Add(teklifBilgisi);
            }
            var oldTeklif = ((TeklifBll)Bll).Single(x => x.Id == model.Id);
            var currentTeklif = new Teklif
            {
                Id = model.Id,
                Kod = model.Kod,
                CariId = model.CariId,
                KullaniciId = _userManager.GetUserId(User),
                SiparisTarihi = model.SiparisTarihi,
                TeslimTarihi = model.TeslimTarihi,
            };
            var entity= ((TeklifBll)Bll).Update(oldTeklif, currentTeklif);
            var entitiesUpdate = teklifBilgileriBll.BaseUpdate(teklifBilgileri.Where(x=>x.Update));
            var entitiesInsert= teklifBilgileriBll.BaseInsert(teklifBilgileri.Where(x=>x.Insert));

            if (!entity||!entitiesUpdate||!entitiesInsert)
            {
                return View();
            }
            return RedirectToAction("TeklifList");
        }
        public IActionResult TeklifEditHareketSil (long? stokId)
        {
            var eleman = TeklifModel.TeklifBilgileri.Find(x => x.StokId == stokId);
            var teklifBilgileriBll = GenerealFunctions.CreateInstanceOfBll<TeklifBilgileriBll>();

            teklifBilgileriBll.BaseDelete(eleman);
            TeklifModel.TeklifBilgileri.Remove(eleman);

            return RedirectToAction("TeklifEdit");
        }
        public async Task<IActionResult> TeklifList()
        {
            var teklifList = new List<TeklifL>();
            var kullaniciId = _userManager.GetUserId(User);
            var user =await _userManager.FindByIdAsync(kullaniciId);
            var rolKullanicilari = await _userManager.GetUsersInRoleAsync("admin");

            if (rolKullanicilari.Contains(user))
            {
                teklifList = ((TeklifBll)Bll).List(x => !x.SipariseDonustu).EntityListConvert<TeklifL>().ToList();
                return View(teklifList);
            }
            else
            {
                teklifList= ((TeklifBll)Bll).List(x => !x.SipariseDonustu&&x.KullaniciId== kullaniciId).EntityListConvert<TeklifL>().ToList();
                return View(teklifList);
            }

        }
        public IActionResult StokSecim(long? id)
        {
            if (id != null)
            {
                TeklifModel.ListeDisiTutulacakKayitlar.Add((long)id);
                using (var bll = new StokBll())
                {
                    var stok = bll.Single(x => x.Id == id).EntityConvert<Stok>();
                    var tek = new TeklifBilgileriL
                    {
                        StokId = stok.Id,
                        StokKodu = stok.Kod,
                        StokAdi = stok.StokAdi,
                        TalepMiktari = 0,
                        FiyatBirim = stok.FiyatBirim,
                        Fiyat = stok.Fiyat,
                        Insert=true
                        //TeklifId = TeklifModel.Teklif.Id,
                    };
                    TeklifModel.TeklifBilgileri.Add(tek);
                }
            }
            var stokSecimModel = new StokSecimModel
            {
                ListelenecekKayitlar = TeklifModel.ListeDisiTutulacakKayitlar.ListelenecekKayitlar<Stok, StokBll>().EntityListConvert<StokL>(),
                KayitInsert= TeklifModel.KayitInsert,
                KayitUpdate=TeklifModel.KayitUpdate
            };


            return View(stokSecimModel);
        }

        private List<StokL> StokList(List<long> listeDisiKayitlar)
        {
            List<StokL> stokList = new List<StokL>();
            using (var stokBll=new StokBll())
            {
                if (TeklifModel.ListeDisiTutulacakKayitlar != null)
                {
                    stokList = stokBll.List(x => !TeklifModel.ListeDisiTutulacakKayitlar.Contains(x.Id)).EntityListConvert<StokL>().ToList();
                }
                else
                    stokList = stokBll.List(null).EntityListConvert<StokL>().ToList();

                return stokList;
            }
        }
    }
}