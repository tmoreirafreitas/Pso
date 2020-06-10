using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pso.BackEnd.Infra.CrossCutting.IoC
{
    public abstract class InstallerBase
    {
        protected IEnumerable<Assembly> AllAssemblies;
        protected void LoadAssemblies()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var directory = new DirectoryInfo(path);
            var files = directory.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            AllAssemblies = files.Select(file =>
                    AssemblyName.GetAssemblyName(file.FullName))
                .Select(assemblyName =>
                    AppDomain.CurrentDomain.Load(assemblyName));
        }
    }
}