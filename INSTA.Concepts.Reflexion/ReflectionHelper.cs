using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INSTA.Concepts.Reflexion
{
    /// <summary>
    /// Classe facilitant les opérations de réflxion..
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Gets the standard bindings (public + non public + static + instance).
        /// </summary>
        /// <returns>
        ///     A value of type BindingFlags that specifies ALL members.
        /// </returns>
        public static BindingFlags GetStandardBindings ()
        {
            return BindingFlags.Public |
                   BindingFlags.NonPublic |
                   BindingFlags.Instance |
                   BindingFlags.Static;

        }

        public static object GetPropertyValue(object container, string propertyName)
        {
            // On obtient le type de l'objet contenant la propriété
            var containerType = container.GetType();

            // On obtient une référence vers l'objet PropertyInfo
            // qui représente notre propriété..
            //var property = containerType.GetProperty(propertyName, GetStandardBindings());

            var result = containerType.InvokeMember(propertyName,
                GetStandardBindings() | BindingFlags.GetProperty,
                null,
                container,
                null);

            return result;
        }
    }
}
