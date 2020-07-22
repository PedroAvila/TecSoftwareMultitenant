using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TecSoftware.EntidadesDominio
{
    public class Helper
    {
        public string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }
    }
}
