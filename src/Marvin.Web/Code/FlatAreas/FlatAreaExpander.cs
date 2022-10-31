using FuncSharp;
using Marvin.FluentChecks.Validators;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

// Modified from https://github.com/OdeToCode/AddFeatureFolders

namespace Marvin.Web
{
    /// <summary>
    /// Flat Area Expander
    /// </summary>
    public sealed class FlatAreaExpander : IViewLocationExpander
    {
        private readonly string _placeholder;

        /// <summary>
        /// Flat Area Expander
        /// </summary>
        /// <param name="options">Flat Area Options from configuration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FlatAreaExpander(IOption<FlatAreaOptions> options)
        {
            _placeholder = options.Match(o => o.AreaPlaceholder, e => throw new ArgumentNullException(nameof(options)));
        }

        /// <summary>
        /// Populate Values Command
        /// </summary>
        /// <param name="context"><see cref="ViewLocationExpanderContext"/></param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }

        /// <summary>
        /// Expand View Locations Command
        /// </summary>
        /// <param name="context"><see cref="ViewLocationExpanderContext"/></param>
        /// <param name="viewLocations">A group of strings representing view locations.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Null exception for parameters</exception>
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            Validation.Begin()
                .ArgumentNullCheck(context, nameof(context))
                .ArgumentNullCheck(viewLocations, nameof(viewLocations))
                .Check();

            var controllerDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
            var areaName = controllerDescriptor?.Properties["area"] as string;

            foreach (var location in viewLocations)
            {
                yield return location.Replace(_placeholder, areaName);
            }
        }
    }
}
