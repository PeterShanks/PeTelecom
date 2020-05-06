using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeTelecom.BuildingBlocks.Domain;

namespace PeTelecom.Modules.UserAccess.Infrastructure.DataAccess.SqlServer
{
    // TODO this class should be made in a common location
    internal class TypedIdValueConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, Guid>
        where TTypedIdValue: TypedIdValueBase
    {
        public TypedIdValueConverter(ConverterMappingHints mappingHints = null) 
            : base(typedId => typedId.Value, id => Create(id), mappingHints)
        {
        }

        private static TTypedIdValue Create(Guid id) =>
            Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
    }
}
