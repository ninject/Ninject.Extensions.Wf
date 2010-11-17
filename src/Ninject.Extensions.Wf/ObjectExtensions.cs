namespace Ninject.Extensions.Wf
{
    using System.Collections.Generic;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object value)
        {
            var dictionary = new Dictionary<string, object>();

            var publicProperties =
                value.GetType().GetProperties();
            
            foreach (var publicProperty in publicProperties)
            {
                dictionary.Add(publicProperty.Name, publicProperty.GetValue(value, null));    
            }

            return dictionary;
        }
    }
}