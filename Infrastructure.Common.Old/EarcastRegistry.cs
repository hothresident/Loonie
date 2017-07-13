using StructureMap;
using System;

namespace Infrastructure.Common
{
    public class EarcastRegistry : Registry
    {
        public EarcastRegistry()
        {
                Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AssembliesFromApplicationBaseDirectory();
                });
        }
    }
}
