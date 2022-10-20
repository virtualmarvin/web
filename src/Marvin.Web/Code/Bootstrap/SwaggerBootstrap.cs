using Marvin.Web.Code.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Marvin.Web.Code.Bootstrap
{
    internal static class SwaggerBootstrap
    {
        internal static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });

            return services;
        }

        internal static WebApplication ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();

            var provider = app.Services.GetService<IApiVersionDescriptionProvider>() ?? throw new NullReferenceException();

            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(ApplicationEnvironment.ApplicationBasePath, fileName);
            }
        }
    }
}
