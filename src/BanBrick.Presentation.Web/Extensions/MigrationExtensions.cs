using BanBrick.Infrastructure.Repositories.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.Extensions
{
    /// <summary>
    /// migration exntion for app to migration database
    /// </summary>
    public static class MigrationExtensions
    {
        public static void UseMigration<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = ((TContext)scope.ServiceProvider.GetService(typeof(TContext)));
                context.Database.EnsureMigrate();
            }
        }
    }
}
