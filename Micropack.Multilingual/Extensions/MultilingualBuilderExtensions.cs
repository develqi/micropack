using System.Reflection;

namespace Micropack.Multilingual;

public static class MultilingualBuilderExtensions
{
    public static MultilingualModule?[]? GetMultilingualModules(this Assembly assembly)
    {
        static bool IsModuleMultilingualBuilder(Type type) => type.IsAssignableTo(typeof(ModuleMultilingualBuilder));

        var moduleItems = assembly.GetTypes()
                              .Where(type => type.IsClass)
                              .Where(IsModuleMultilingualBuilder)
                              .Select(type => (Activator.CreateInstance(type) as ModuleMultilingualBuilder))
                              .Select(moduleBuilder => moduleBuilder?.Items.FirstOrDefault())
                              .ToArray();
        return moduleItems;
    }
}