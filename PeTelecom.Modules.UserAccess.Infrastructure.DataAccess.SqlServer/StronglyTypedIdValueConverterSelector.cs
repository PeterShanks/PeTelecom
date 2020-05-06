using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer
{
    // TODO this class should be made in a common location
    public class StronglyTypedIdValueConverterSelector : ValueConverterSelector 
    {
        // By using ConcurrentDictionary i am 100% sure that a converter will be made once not more
        private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderType), ValueConverterInfo> _converters = 
            new ConcurrentDictionary<(Type ModelClrType, Type ProviderType), ValueConverterInfo>();

        public StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies) : base(dependencies)
        {
        }

        public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type providerClrType = null)
        {
            var baseConverters = base.Select(modelClrType, providerClrType);
            foreach (ValueConverterInfo converter in baseConverters)
            {
                yield return converter;
            }

            // Extract the real type T from Nullable if required
            var underlyingModelType = UnwrapNullableType(modelClrType);
            var underlyingProviderType = UnwrapNullableType(providerClrType);

            // null means get any value converters for the modelClrType
            if (underlyingProviderType is null || typeof(Guid) == underlyingModelType)
            {
                // Try get nested class with expected name
                var isTypedIdValue = typeof(TypedIdValueBase).IsAssignableFrom(underlyingModelType);

                if (isTypedIdValue)
                {
                    var converterType = typeof(TypedIdValueConverter<>).MakeGenericType(modelClrType);

                    yield return _converters.GetOrAdd(
                        (underlyingProviderType, typeof(Guid)),
                        info =>
                        {
                            return new ValueConverterInfo(
                                modelClrType,
                                typeof(Guid),
                                converterInfo =>
                                    (ValueConverter) Activator.CreateInstance(converterType, converterInfo.MappingHints)
                            );
                        });
                }
            }
        }

        private Type UnwrapNullableType(Type type)
        {
            return type is null ? null : Nullable.GetUnderlyingType(type);
        }
    }
}
