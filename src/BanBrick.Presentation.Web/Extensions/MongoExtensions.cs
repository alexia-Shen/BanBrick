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
            TContext context, 
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped) where TContext: class
        {
            switch (contextLifetime)
            {
                case ServiceLifetime.Scoped:
                    return serviceCollection.AddScoped(x => context);
                case ServiceLifetime.Singleton:
                    return serviceCollection.AddSingleton(x => context);
                case ServiceLifetime.Transient:
                    return serviceCollection.AddTransient(x => context);
            }

            return serviceCollection;
        }

        public static IServiceCollection AddMongoContext<TContext>(
            this IServiceCollection serviceCollection, 
            Action<MongoOptionsBuilder> optionsAction = null, 
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped, 
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
            ) where TContext : class
        {
            return null;
        }
    }
}
