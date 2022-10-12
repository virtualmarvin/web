using Microsoft.AspNetCore.Mvc.ApplicationModels;

// Modified from https://github.com/OdeToCode/AddFeatureFolders

namespace Marvin.Web
{
    public sealed class FlatAreaConvention : IControllerModelConvention
    {
        private readonly string _folderName;
        private readonly Func<ControllerModel, string> _nameDerivationStrategy;

        public FlatAreaConvention(FlatAreaOptions options)
        {
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _folderName = options.RootFolderName;
            _nameDerivationStrategy = options.DeriveFolderName ?? DeriveAreaFolderName;
        }

        public void Apply(ControllerModel controller)
        {
            if (controller == null)
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
