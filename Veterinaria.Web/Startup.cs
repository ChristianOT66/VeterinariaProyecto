using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Infrastructure;
using Veterinaria.Infrastructure.Contracts;
using Veterinaria.Infrastructure.Extensions;
using Veterinaria.Infrastructure.Repository;
using Veterinaria.Models.ConfigurationModels;
using Veterinaria.Models.DataModels;
using Veterinaria.Website.Application.Contracts;
using Veterinaria.Website.Application;


namespace Veterinaria.Website
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

            services.AddDbContext<ApplicationDbContext>
    (
        options =>
            options.UseSqlServer
                (Configuration.GetConnectionString("Default"))
    );

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Veterinario, VeterinarioRepository>()
                .AddRepository<Dueno, DuenoRepository>()
                .AddRepository<Mascota, MascotaRepository>()
                .AddRepository<Cita, CitaRepository>()
                .AddRepository<Historial, HistorialRepository>();


            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());
            services.AddControllersWithViews();

            services.Configure<SmtpConfiguration>
    (Configuration.GetSection("SmtpConfiguration"));

            services.AddSingleton<IEmailSenderService, EmailSenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acceso}/{action=Index}/{id?}");
            });
        }
    }
}
