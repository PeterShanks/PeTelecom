using PeTelecom.BuildingBlocks.DependencyInjection.Contracts;
using SimpleInjector;
using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PeTelecom.BuildingBlocks.DependencyInjection
{
    public class ModuleLoader
    {
        public void LoadContainer(Container container, string path, string pattern)
        {
            var directoryCatalog = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();

            try
            {
                using var aggregateCatalog = new AggregateCatalog();
                aggregateCatalog.Catalogs.Add(directoryCatalog);

                using var compositionContainer = new CompositionContainer(aggregateCatalog);
                var exports = compositionContainer.GetExports(importDef);
                var modules = exports.Select(export => export.Value as IModule)
                    .Where(c => c != null);

                var registrar = new ModuleRegistrar(container);
                foreach (var module in modules)
                {
                    module.Initialize(registrar);
                }
            }

            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                var builder = new StringBuilder();
                foreach (var loaderException in reflectionTypeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}.\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), reflectionTypeLoadException);
            }
        }
        private ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IModule).FullName,
                ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
