using HashidsNet;

namespace Marvin.Web.Code.Bootstrap
{
    internal static class HashIdsBootstrap
    {
        internal static IServiceCollection AddHashids(this IServiceCollection services, HashidOptions options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            services.AddSingleton<IHashids>(_ => new Hashids(options.Salt, options.Length));
            return services;
        }
    }
}
