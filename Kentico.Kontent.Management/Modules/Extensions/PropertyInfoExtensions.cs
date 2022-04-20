using System;
using System.Reflection;
using Kentico.Kontent.Management.Modules.ModelBuilders;

namespace Kentico.Kontent.Management.Modules.Extensions;

/// <summary>
/// Extension methods for mapping element to strongly typed model properties.
/// </summary>
public static class PropertyInfoExtensions
{
    /// <summary>
    /// Get Element ID from strongly typed model property.
    /// </summary>
    public static Guid GetKontentElementId(this PropertyInfo property)
    {
        var attribute = property.GetCustomAttribute<KontentElementIdAttribute>();

        return attribute == null
            ? throw new InvalidOperationException($"Cannot get kontent element id as there is no attribute of type {nameof(KontentElementIdAttribute)}")
            : Guid.Parse(property.GetCustomAttribute<KontentElementIdAttribute>()?.ElementId);
    }
}