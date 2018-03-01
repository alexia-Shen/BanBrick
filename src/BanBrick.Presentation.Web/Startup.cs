using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanBrick.Infrastructure.Geometry;
using BanBrick.Infrastructure.Repositories;
using BanBrick.Presentation.Web.RouteConfigs;
using BanBrick.Presentation.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rissole.EntityFramework;

namespace BanBrick.Presentation.WebSite
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
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add(GeoPointRouteConstaint.ConstraintMap));

            services.AddMvc(options => options.ModelBinderProviders.Insert(0, new GeoPointModelBinderProvider()));

            services.AddDbContext<BanBrickDatabaseContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));
            services.AddMongoContext<BanBrickGeometryContext>(options => options.UseMongo(Configuration.GetConnectionString("MongoConnection")));

            services.AddScoped<IBanBrickDatabaseFacade, BanBrickDatabaseFacade>();
            services.AddScoped<IBanBrickGeometryFacade, BanBrickGeometryFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMigration<BanBrickDatabaseContext>();

                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "geopoint",
                    template: "{controller}/{action}/{location:GeoPoint?}",
                    defaults: null,
                    constraints: new { location = new GeoPointRouteConstaint() }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
