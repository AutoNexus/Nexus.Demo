﻿using System.ComponentModel;
using System.Reflection;

namespace Framework.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            var objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);  //Getting the description attribute.
            if (objs == null || objs.Length == 0)//If the attribute is not found, it returns the default value.
            {
                return value;
            }
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
    }
}
