using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Senfoni.Satis.Webui.Models
{
    public class SiparisKayitModel
    {
        public long Id { get; set; }
        public string Kod { get; set; }
        public long CariId { get; set; }
        public string CariAdi { get; set; }
        public string KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public List<SiparisBilgileriL> SiparisBilgileriL { get; set; }
    }
    public class SiparisInsertModel
    {
        public long Id { get; set; }
        public string Kod { get; set; }
        public long CariId { get; set; }
        public string KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public long[] StokIds { get; set; }
        public decimal[] Miktarlar { get; set; }
    }
    public class SiparisEditModel
    {
        public long Id { get; set; }
        public string Kod { get; set; }
        public long CariId { get; set; }
        public string CariAdi { get; set; }
        public string KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public List<string> StokKodu { get; set; }
        public List<string> StokAdi { get; set; }
        public decimal[] Prices { get; set; }
        public long[] StokIds { get; set; }
        public decimal[] Miktarlar { get; set; }

    }
    public static class SiparisModel
    {
        public static List<SiparisBilgileriL> SiparisBilgileri = new List<SiparisBilgileriL>();
        public static List<long> ListeDisiTutulacakKayitlar = new List<long>();
        public static List<Cari> CariList = new List<Cari>();
        public static Siparis Siparis { get; set; }
        public static SiparisS SiparisS = new SiparisS();
        public static DateTime SiparisTarihi { get; set; } = DateTime.Today;
        public static DateTime TeslimTarihi { get; set; } = DateTime.Today;
        public static bool KayitInsert { get; set; }
        public static bool KayitUpdate { get; set; }
        public static long SiparisId;
        public static string SiparisKod;
    }
}
