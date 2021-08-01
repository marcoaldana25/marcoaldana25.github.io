namespace AnimalMaintenance.ExtensionMethods
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using Managers.DataTransferObjects;

    public static class DisplayNameExtensionMethods
    {
        public static string GetDisplayName(this string propertyName)
        {
            var myProperty = typeof(Animal)
                .GetProperty(propertyName) as MemberInfo;

            var displayAttribute = myProperty
                .GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return displayAttribute?.Name ?? string.Empty;
        }
    }
}
