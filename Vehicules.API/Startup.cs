using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vehicules.API.Data;
using Vehicules.API.Data.Entities;
using Vehicules.API.Helpers;

namespace Vehicules.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                x.SignIn.RequireConfirmedEmail = true;
                x.User.RequireUniqueEmail = true;
                x.Password.RequireDigit = false;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication()
               .AddCookie()
               .AddJwtBearer(cfg =>
               {
                   cfg.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidIssuer = Configuration["Tokens:Issuer"],
                       ValidAudience = Configuration["Tokens:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                   };
               });


            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Account/NotAuthorized";
                options.AccessDeniedPath = "/Account/NotAuthorized";
            });

            services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<SeedDb>();
            services.AddScoped<IBlobHelper, BlobHelper>();
            services.AddScoped<ICombosHelper, CombosHelper>();
            services.AddScoped<IConverterHelper, ConverterHelper>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IMailHelper, MailHelper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
