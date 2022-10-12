using FuncSharp;
using Marvin.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Code.Bootstrap
{
    internal static class Database
    {
        internal static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            var activeConnectionString = builder.Configuration["ActiveConnectionString"];
            var connectionString = builder.Configuration.GetConnectionString(activeConnectionString);

            activeConnectionString.Contains("PostgresConnection")
                .Match(
                    t => builder.AddPostgreSql(connectionString),
                    f => builder.AddSqlServer(connectionString)
                );

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            return builder;
        }

        private static WebApplicationBuilder AddPostgreSql(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<IamDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddHealthChecks().AddNpgSql(connectionString, name: "Database");
            return builder;
        }

        private static WebApplicationBuilder AddSqlServer(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<IamDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddHealthChecks().AddSqlServer(connectionString, name: "Database");
            return builder;
        }
    }
}
