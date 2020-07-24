using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class EnumFunction
    {
        public IEnumerable<UniversalExtend> GetEnumDescription<T>(bool insertFirstItem)
        {
            var descriptions = new List<UniversalExtend>();

            var query2 = (from T v in Enum.GetValues(typeof(T)) select v);

            foreach (var element in query2)
            {
                var item = new UniversalExtend();

                item.Id = (int)Enum.Parse(typeof(T), Enum.GetName(typeof(T), element));
                item.Descripcion = GetDescription(element);
                descriptions.Add(item);
            }

            if (insertFirstItem) descriptions.Insert(0, new UniversalExtend { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return descriptions;
        }

        public IEnumerable<UniversalExtend> GetEnumDescription<T>(bool insertFirstItem, int[] paraInts)
        {
            var descriptions = new List<UniversalExtend>();

            var query2 = (from T v in Enum.GetValues(typeof(T)) select v);

            foreach (var element in query2)
            {
                var item = new UniversalExtend();

                item.Id = (int)Enum.Parse(typeof(T), Enum.GetName(typeof(T), element));
                item.Descripcion = GetDescription(element);

                foreach (var param in paraInts)
                {
                    if (param.Equals(item.Id))
                        descriptions.Add(item);
                }
            }

            if (insertFirstItem) descriptions.Insert(0, new UniversalExtend { Id = -1, Descripcion = "<<<Seleccione>>>" });

            return descriptions;
        }

        private string GetDescription(object enumValue)
        {

            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            object[] attrs = fi?.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
            return enumValue.ToString();
        }
    }
}
