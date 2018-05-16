using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
using DotNetG2E.Data;
using DotNetG2E.Models;
using DotNetG2E.Services;
using DotNetG2E.Data.Filters;
using DotNetG2E.Models.Domain;
using DotNetG2E.Data.Repositories;

namespace DotNetG2E
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

			services.AddAuthorization(options =>
			options.AddPolicy("Leerkracht", policy => policy.RequireClaim(ClaimTypes.Role, "Leerkracht")));


            services.AddScoped<LeerkrachtFilter>();

            services.AddScoped<ISessieRepository, SessieRepository>();

			services.AddScoped<ILeerkrachtRepository, LeerkrachtRepository>();
			services.AddTransient<BreakOutBoxInitializer>();


			services.AddTransient<IEmailSender, EmailSender>();

			services.AddSession();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BreakOutBoxInitializer breakOutBoxInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
				app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
			app.UseSession();
			app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "LeerkrachtIndex",
                    template: "LeerkrachtIndex/{id?}",
                    defaults: new { controller = "Sessie", action = "Search" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //filter client side with javascript or server round trip
            //inbetween classes moeten er bij bij many to many
            //Lots and lots of bugs in this -_-
            breakOutBoxInitializer.InitializeData().Wait();
        }
    }
}
