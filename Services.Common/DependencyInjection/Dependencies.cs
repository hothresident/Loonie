using StructureMap;

namespace Infrastructure.Common.DependencyInjection
{
    public class Dependencies
    {
        public static IContainer GetContainer()
        {
            return GetContainer<LoonieRegistry>();
        }

        public static IContainer GetContainer<TRegistry>()
            where TRegistry : Registry, new()
        {
            return new Container(c => c.AddRegistry<TRegistry>());
        }
    }
}
