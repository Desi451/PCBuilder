using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common;

public static class Helper
{
    public static void CopyProperties<T>(T source, T destination)
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            if (property.CanRead && property.CanWrite)
            {
                var value = property.GetValue(source);
                property.SetValue(destination, value);
            }
        }
    }
}
