using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoUniversity
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(_configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<IPasswordValidator<IdentityUser>, CustomPasswordValidator>();

            services.AddScoped<IUserValidator<IdentityUser>, CustomPasswordValidator>();


            services.AddIdentity<IdentityUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("sortingpage", "Students/OrderBy{sortBy}/Page{page}",
                    new { Controller = "Students", action = "Index", page = 1 });

                endpoints.MapControllerRoute("sorting", "Students/OrderBy{sortBy}",
                    new { Controller = "Students", action = "Index" });

                // e.g. /Students/Page2)
                endpoints.MapControllerRoute("pagination", "Students/Page{page}",
                    new { Controller = "Students", action = "Index", page = 1 });

                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsurePopulated(app);
            SeedDataIdentity.EnsurePopulated(app);
        }
    }
}
