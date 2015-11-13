using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SealedClassMocking.DescriptiveEnums
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            return value == null
                ? String.Empty
                : value.GetType().GetFields()
                    .Where(x => x.FieldType.BaseType == typeof (Enum) && x.Name.Equals(value.ToString()))
                    .Select(fieldInfo => fieldInfo.GetCustomAttribute<DescriptionAttribute>())
                    .Single(descriptionAttribute => descriptionAttribute != null)
                    .Description;
        }
    }
}