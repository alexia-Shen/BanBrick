using BanBrick.Infrastructure.Geometry;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.Extensions
{
    public static class MongoExtensions
    {
        public static IServiceCollection AddMongoContext<TContext>(
            this IServiceCollection serviceCollection, 
            Action<MongoSettingsBuilder> optionsAction = null, 
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped, 
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
            ) where TContext : class
        {
            var optionsBuilder = new MongoSettingsBuilder(optionsAction);

            var optionsService = new ServiceDescriptor(typeof(MongoOptions), x => optionsBuilder.Options, optionsLifetime);
            var contextService = new ServiceDescriptor(typeof(TContext), typeof(TContext), contextLifetime);

            serviceCollection.Add(optionsService);
            serviceCollection.Add(contextService);

            return serviceCollection;
        }
    }
}
