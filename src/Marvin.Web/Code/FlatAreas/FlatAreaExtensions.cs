// Modified from https://github.com/OdeToCode/AddFeatureFolders

using FuncSharp;

namespace Marvin.Web
{
    public static class FlatAreaExtensions
    {
        /// <summary>
        /// Use flat area folders with custom options
        /// </summary>
        public static IMvcBuilder AddFlatAreas(this IMvcBuilder services, FlatAreaOptions options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var expander = new FlatAreaExpander(options.ToOption());

            services.AddMvcOptions(o =>
            {
                o.Conventions.Add(new FlatAreaConvention(options));
            })
            .AddRazorOptions(o =>
            {
                // Helps finding shared and other fully qualified resources

                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add(options.AreaPlaceholder + @"\{0}.cshtml");
                o.ViewLocationFormats.Add(options.RootFolderName + @"\_Base\{0}.cshtml");
                o.ViewLocationFormats.Add(options.RootFolderName + @"\_Related\{0}.cshtml");
                o.ViewLocationFormats.Add(options.RootFolderName + @"\{0}.cshtml"); // locates fully-qualified partial views
                o.ViewLocationExpanders.Add(expander);
            });

            return services;
        }

        /// <summary>
        /// Use feature folders with the default options. Controllers and view will be located
        /// under a folder named Features. Shared views are located in Features\Shared.
        /// </summary>
        public static IMvcBuilder AddAreaFolders(this IMvcBuilder services) =>
            AddFlatAreas(services, new FlatAreaOptions());
    }
}