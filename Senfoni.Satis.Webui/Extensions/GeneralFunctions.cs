using Senfoni.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senfoni.Satis.Webui.Extensions
{
    public static class GeneralFunctions
    {
        public static long IdOlustur(/*BaseEntity selectedEntity*/)
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                    return "0" + deger;
                return deger;
            }

            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;
                }
                return deger;
            }

            string Id()
            {
                var yil = SifirEkle(DateTime.Now.Date.Year.ToString());
                var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Date.Second.ToString());
                var milisaniye = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var random = SifirEkle(new Random().Next(0, 99).ToString());

                return yil + ay + gun + saat + dakika + saniye + milisaniye + random;
            }

            var id = Id();

            return /*islemTuru == IslemTuru.EntityUpdate ? selectedEntity.Id : */long.Parse(Id());
        }
    }
}
