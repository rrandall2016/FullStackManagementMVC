using FullStackManagementMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullStackManagementMVC.Data;
using FullStackManagementMVC.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;

namespace FullStackManagementMVC
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
            services.AddDefaultIdentity<IndividualUsers>().AddEntityFrameworkStores<FullStackManagementMVCContext>();
            services.AddHttpContextAccessor();
            services.AddHttpClient<WebServices>();
            services.AddHttpClient("Yelp", c =>
            {
                c.BaseAddress = new Uri("https://api.yelp.com/v3/businesses/search");
               
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "TV-m-5-KAx-FcOkMfwoDmvix5DXU3VTFCM7CN6nJlvK9dxuPr_i6caRcxB-uvVJ1Rzz-AR7kASh_LaAgi314SzjnvWO9oqlZMHiKogBZPxwMbtqxFNLtlpnrrFFFYXYx");

            });

            services.AddControllersWithViews();

            services.AddDbContext<FullStackManagementMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FullStackManagementMVCContext")));
            services.AddRazorPages();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
