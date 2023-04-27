using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace Airline_OARS
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddCors();
            services.AddTransient(typeof(Airline_OARSContext));
            services.AddTransient(typeof(LoginDataService));
            services.AddTransient(typeof(IUser), typeof(LoginDataService));
            services.AddTransient(typeof(FlightService));
            services.AddTransient(typeof(IFlight), typeof(FlightService));
            services.AddTransient(typeof(ReservationService));
            services.AddTransient(typeof(IReservation), typeof(ReservationService));
            services.AddTransient(typeof(TicketstatusService));
            services.AddTransient(typeof(ITicketstatus), typeof(TicketstatusService));
            services.AddTransient(typeof(FlightRevenueService));
            services.AddTransient(typeof(IFlightRevenueReport), typeof(FlightRevenueService));

            services.AddSwaggerGen();


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

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


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
