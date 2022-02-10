using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlatPhone.Extention

{
    public static class EnumExtention
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }/// <summary>
         /// Get description for normal enums
         /// </summary>
         /// <param name="value"></param>
         /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

        /// <summary>
        /// Get list of desciptions for Flagged multi enums
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDescriptionsList(this Enum value)
        {
            List<string> descriptions = new List<string>();
            List<Enum> values = new List<Enum>();

            foreach (Enum enumValue in Enum.GetValues(value.GetType()))
            {
                var v = Convert.ToInt16(enumValue);
                if (value.HasFlag(enumValue))
                {
                    values.Add(enumValue);
                }
            }

            var zeroValue = values.FirstOrDefault(v => Convert.ToInt16(v) == 0);
            if (values.Count > 1 && zeroValue != null)
            {
                values.Remove(zeroValue);
            }

            foreach (var val in values)
            {
                descriptions.Add(val.GetDescription());
            }
            return descriptions;
        }

        /// <summary>
        /// Get string description for Flagged multi enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptions(this Enum value, string separator = ",")
        {
            return String.Join(separator, GetDescriptionsList(value));
        }

        /// <summary>
        /// دریافت آیتم Enum از روی مقدار
        /// </summary>
        /// <typeparam name="E">Enum مربوطه</typeparam>
        /// <param name="value">مقدار مورد نظر</param>
        /// <returns>آیتم مورد نظر انتخاب شده از Enum</returns>
        public static E GetEnum<E>(this int value)
        {
            return (E)Enum.ToObject(typeof(E), value);
        }
    }
}
