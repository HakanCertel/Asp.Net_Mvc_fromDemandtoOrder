using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senfoni.Data.Concrete.EfCore;
using Senfoni.Satis.Webui.EmailServices;
using Senfoni.Satis.Webui.Identity;
using System;

namespace Senfoni.Satis.Webui
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(@"Server = DESKTOP-A8NNBCN; Database = Senfoni_Erp2; Trusted_Connection = True; "));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly=true,
                    Name=".SenfoniSatis.Securty.Cookie",
                    //SameSite=SameSiteMode.Strict
                };
            });

            services.AddScoped<IEmailSender, SmtpEmailSender>(x=>
                new SmtpEmailSender(
                        Configuration["EmailSender:Host"],
                        Configuration.GetValue<int>("EmailSender:Port"),
                        Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                        Configuration["EmailSender:UserName"],
                        Configuration["EmailSender:Password"] )
                );

            //services.AddScoped<IProductRepository, EfCoreProductRepository>();
            //services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            //services.AddScoped<ICartRepository, EfCoreCartRepository>();
            //services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
            //services.AddScoped<IStokRepository, EfCoreStokRepository>();

            //services.AddScoped<IProductService, ProductManager>();
            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICartService, CartManager>();
            //services.AddScoped<IOrderService, OrderManager>();
            //services.AddScoped<IStokService, StokManager>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            //app.UseStaticFiles(new StaticFileOptions
            // {
            //     FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
            //     RequestPath="/modules"

            // });
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "siparisInsert",
                    template: "siparisolustur/{id?}",
                    defaults: new { controller = "Siparis", action = "Insert" }
                    );
                routes.MapRoute(
                    name: "siparisEdit",
                    template: "siparis/edit/{siparisId?}",
                    defaults: new { controller = "Siparis", action = "SiparisEdit" }
                    );
                routes.MapRoute(
                    name: "siparisEditHareketSil",
                    template: "siparis/hareketSil/{stokId?}",
                    defaults: new { controller = "Siparis", action = "SiparisEditHareketSil" }
                    );
                routes.MapRoute(
                    name: "siparisList",
                    template: "siparisler",
                    defaults: new { controller = "Siparis", action = "SiparisList" }
                    );
                routes.MapRoute(
                    name: "teklifInsert",
                    template: "teklif/create/{id?}",
                    defaults: new { controller = "Teklif", action = "Insert" }
                    );
                    routes.MapRoute(
                    name: "teklifEdit",
                    template: "teklif/edit/{teklifId?}",
                    defaults: new { controller = "Teklif", action = "TeklifEdit" }
                    );
                routes.MapRoute(
                    name: "teklifEditHareketSil",
                    template: "teklif/hareketSil/{stokId?}",
                    defaults: new { controller = "Teklif", action = "TeklifEditHareketSil" }
                    );
                routes.MapRoute(
                    name: "teklifList",
                    template: "teklifler",
                    defaults: new { controller = "Teklif", action = "TeklifList" }
                    );
                routes.MapRoute(
                    name: "cari",
                    template: "admin/cari/create",
                    defaults: new { controller = "Admin", action = "CariCreate" }
                    );
                routes.MapRoute(
                    name: "admincariedit",
                    template: "admin/cari/{id?}",
                    defaults: new { controller = "Admin", action = "CariEdit" }
                    );
                routes.MapRoute(
                    name: "carikartlari",
                    template: "admin/cari/list",
                    defaults: new { controller = "Admin", action = "CariList" }
                    );
                routes.MapRoute(
                    name: "adminusers",
                    template: "admin/user/list",
                    defaults: new { controller = "Admin", action = "UserList" }
                    );
                routes.MapRoute(
                    name: "adminusertedit",
                    template: "admin/user/{id?}",
                    defaults: new { controller = "Admin", action = "UserEdit" }
                    );

                routes.MapRoute(
                    name: "adminroles",
                    template: "admin/role/list",
                    defaults: new { controller = "Admin", action = "RoleList" }
                    );
                routes.MapRoute(
                    name: "adminrolecreate",
                    template: "admin/role/create",
                    defaults: new { controller = "Admin", action = "RoleCreate" }
                    );
                routes.MapRoute(
                    name: "adminroletedit",
                    template: "admin/role/edit/{id?}",
                    defaults: new { controller = "Admin", action = "RoleEdit" }
                    );
                routes.MapRoute(
                    name: "search",
                    template: "search",
                    defaults: new { controller = "Satis", action = "Search" }
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
        }
    }
}
