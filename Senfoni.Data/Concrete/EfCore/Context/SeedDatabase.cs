using Microsoft.EntityFrameworkCore;
using Senfoni.Entity;
using System.Linq;

namespace Senfoni.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            using (var context = new SenfoniContext())
            {
                if(context.Database.GetPendingMigrations().Count()==0)
                {
                    if (context.Categories.ToList().Count == 0)
                    {
                        context.Categories.AddRange(Categories);
                    }
                    if (context.Products.ToList().Count == 0)
                    {
                        context.Products.AddRange(Products);
                        context.AddRange(ProductCategories);
                    }
                }

                context.SaveChanges();
            }
        }
        private static Category[] Categories = {
            new Category(){Name="Telefon",Url="telefon"},
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
            new Category(){Name="Elektronik",Url="elektronik"},
            new Category(){Name="Beyaz Eşya",Url="beyaz-esya"}
        };
        private static Product[] Products = {
            new Product(){Name="Sanmsung S5",Url="samsung-s5",Price=2000,ImageUrl="1.jpg",Aciklama="İyi Telefon",IsApproved=true},
            new Product(){Name="Sanmsung S6",Url="samsung-s6",Price=3000,ImageUrl="2.jpg",Aciklama="İyi Telefon",IsApproved=false},
            new Product(){Name="Sanmsung S7",Url="samsung-s7",Price=4000,ImageUrl="3.jpg",Aciklama="İyi Telefon",IsApproved=true},
            new Product(){Name="Sanmsung S8",Url="samsung-s8",Price=5000,ImageUrl="4.jpg",Aciklama="İyi Telefon",IsApproved=false},
            new Product(){Name="Sanmsung S9",Url="samsung-s9",Price=6000,ImageUrl="5.jpg",Aciklama="İyi Telefon",IsApproved=true},
        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[2]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[2]},
        };
    }
}
