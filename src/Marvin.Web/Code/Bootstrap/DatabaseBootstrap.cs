using FuncSharp;
using Marvin.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Code.Bootstrap
{
    internal static class DatabaseBootstrap
    {
        internal static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            var activeConnectionString = builder.Configuration["ActiveConnectionString"];
            var connectionString = builder.Configuration.GetConnectionString(activeConnectionString);

            activeConnectionString.Contains("PostgresConnection")
                .Match(
                    t => builder.Services.AddPostgreSql(connectionString),
                    f => builder.Services.AddSqlServer(connectionString)
                );

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            return builder;
        }

        private static IServiceCollection AddPostgreSql(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<IamDbContext>(options => options.UseNpgsql(connectionString));
            service.AddHealthChecks().AddNpgSql(connectionString, name: "Database");
            return service;
        }

        private static IServiceCollection AddSqlServer(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<IamDbContext>(options => options.UseSqlServer(connectionString));
            service.AddHealthChecks().AddSqlServer(connectionString, name: "Database");
            return service;
        }
    }
}
