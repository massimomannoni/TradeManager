﻿using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace TradeManager.Service.SeedWork
{
    public class TypedIdValueConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, Guid>
        where TTypedIdValue : TypedIdValueBase
    {
        public TypedIdValueConverter(ConverterMappingHints mappingHints = null) 
            : base(id => id.Value, value => Create(value), mappingHints)
        {
        }

        private static TTypedIdValue Create(Guid id) => Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
    }
}