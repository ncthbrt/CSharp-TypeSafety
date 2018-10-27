using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Taken from
// https://blogs.msdn.microsoft.com/kevinpilchbisson/2007/11/20/enforcing-immutability-in-code/
namespace Safety
{
  [Serializable]
  public static class ReflectionHelper
  {
    public static IEnumerable<Type> FindAllTypesThatDeriveFrom<TBase>(Assembly assembly)
    {
      return assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(TBase)));
    }

    public static bool TypeHasAttribute<TAttribute>(Type type)
        where TAttribute : Attribute
    {
      return Attribute.IsDefined(type, typeof(TAttribute));
    }

    public static IEnumerable<FieldInfo> GetAllDeclaredInstanceFields(Type type)
    {
      return type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    }

    public static TAttribute GetCustomAttribute<TAttribute>(MemberInfo element)
        where TAttribute : Attribute
    {
      return (TAttribute)Attribute.GetCustomAttribute(element, typeof(TAttribute));
    }

    public static IEnumerable<Type> GetTypes(this IEnumerable<Assembly> assemblies)
    {
      return assemblies.SelectMany(assembly => assembly.GetTypes());
    }
  }
}