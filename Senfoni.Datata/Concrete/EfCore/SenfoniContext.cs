using Senfoni.Entity;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Senfoni.Data.Concrete.EfCore
{
    public class SenfoniContext:DbContext
    {
        private static string _nameOrConnectionString = typeof(DbContext).Name;

        public SenfoniContext() : base(_nameOrConnectionString) { }

        public SenfoniContext(string connectionString) : base(connectionString)
        {
            //databaseli kod, oluşturmuş olduğumuz Entitylerdebir güncelleme yaptığımızda
            //bunu gidip database'e uygulamak için kullanılır...
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
            _nameOrConnectionString = connectionString;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.CategoryId, c.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
    public class Configuration : DbMigrationsConfiguration<SenfoniContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;//migration işlemlerini otomatik yapmaya yarar..
            AutomaticMigrationDataLossAllowed = true;//migration işlemi yaparken veri kaybı olması durumuna izin veriş oluyoruz..
        }
    }
    public class Configurations:DbConfiguration
    {
        
    }
}
