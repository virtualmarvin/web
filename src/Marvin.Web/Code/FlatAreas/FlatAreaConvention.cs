using Marvin.Web.Code.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

// Modified from https://github.com/OdeToCode/AddFeatureFolders

namespace Marvin.Web
{
    /// <summary>
    /// Flat Area Convention
    /// </summary>
    public sealed class FlatAreaConvention : IControllerModelConvention
    {
        private readonly string _folderName;
        private readonly Func<ControllerModel, string> _nameDerivationStrategy;

        /// <summary>
        /// Flat Area Convention
        /// </summary>
        /// <param name="options">Flat Area Options</param>
        /// <exception cref="ArgumentNullException">Null exception for <paramref name="options"/></exception>
        public FlatAreaConvention(FlatAreaOptions options)
        {
            if (options.IsNull())
            {
                throw new ArgumentNullException(nameof(options));
            }
            _folderName = options.RootFolderName;
            _nameDerivationStrategy = options.DeriveFolderName ?? DeriveAreaFolderName;
        }

        /// <summary>
        /// Apply Command
        /// </summary>
        /// <param name="controller">Controller Model</param>
        /// <exception cref="ArgumentNullException">Null exception for <paramref name="controller"/></exception>
        public void Apply(ControllerModel controller)
        {
            if (controller.IsNull())
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var areaName = _nameDerivationStrategy(controller);
            controller.Properties.Add("area", areaName);
        }

        private string DeriveAreaFolderName(ControllerModel model)
        {
            var @namespace = model.ControllerType.Namespace;
            var result = @namespace!.Split('.')
                  .SkipWhile(s => s != _folderName)
                  .Aggregate("", Path.Combine);

            return result;
        }
    }
}
