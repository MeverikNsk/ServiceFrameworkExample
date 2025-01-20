namespace Vsk.VooDoo.Core.Module
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    internal static class LoaderModulesHelper
    {
        public static void LoadAndInitServiceModules(IServiceCollection services, IList<string> dllPrefixes)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (dllPrefixes?.Any() == true)
            {
                List<string> list = (from x in Directory.GetFiles(baseDirectory)
                                     where dllPrefixes.Any((string p) => Path.GetFileName(x).Contains(p, StringComparison.OrdinalIgnoreCase)) && Path.GetExtension(x).Equals(".dll", StringComparison.OrdinalIgnoreCase)
                                     select x).ToList();
                foreach (string item in list)
                {
                    var assemblyName = AssemblyName.GetAssemblyName(item);
                    var assembly = Assembly.Load(assemblyName);

                    List<Type> list2 = (from t in assembly.GetTypes()
                                        where t.BaseType == typeof(AssemblyDefinedModule)
                                        select t).ToList();
                    foreach (Type item2 in list2)
                    {
                        AssemblyDefinedModule? assemblyDefinedModule = Activator.CreateInstance(item2) as AssemblyDefinedModule;
                        assemblyDefinedModule?.Init(services);

                        if (assemblyDefinedModule is IAutoMapperConfiguration instanceAutomapper)
                        {
                            services.AddAutoMapper(delegate (IMapperConfigurationExpression config)
                            {
                                instanceAutomapper.RegisterMaps(config);
                            });
                        }
                    }
                }
            }
        }
    }
}
