using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;

namespace Senfoni.Satis.Webui.Models
{
    public  class TeklifKayitModel
    {
        public long Id { get; set; }
        public string Kod { get; set; }
        public long CariId { get; set; }
        public string CariAdi { get; set; }
        public string KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool SipariseDonustu { get; set; }
        public  List<TeklifBilgileriL> TeklifBilgileriL  { get; set; }
    }
    public class TeklifInsertModel
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
    public class TeklifEditModel
    {
        public long Id { get; set; }
        public string Kod { get; set; }
        public long CariId { get; set; }
        public string CariAdi { get; set; }
        public string KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public List<string> StokKodu { get; set; }
        public List<string> StokAdi{ get; set; }
        public decimal[] Prices { get; set; }
        public long[] StokIds { get; set; }
        public decimal[] Miktarlar { get; set; }

    }
    public static class TeklifModel
    {
        public static List<TeklifBilgileriL> TeklifBilgileri = new List<TeklifBilgileriL>();
        public static List<long> ListeDisiTutulacakKayitlar = new List<long>();
        public static List<Cari> CariList = new List<Cari>();
        public static Teklif Teklif { get; set; }
        public static TeklifS teklif = new TeklifS();
        public static bool KayitInsert { get; set; }
        public static bool KayitUpdate{ get; set; }
        public static long TekilfId;
        public static string TeklifKod;
    }
}
