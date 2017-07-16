using AutoMapper;
using StructureMap;

namespace Infrastructure.Common.DependencyInjection
{
    public class LoonieRegistry : Registry
    {
        public LoonieRegistry()
        {
            For<IMapper>().Singleton().Use(c => BuildMapper(c));
            //c.For<ITranslationFacade>().Use<Adapter>();
            //c.For<IRepository>().Use<Repository>();

            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.LookForRegistries();
                x.WithDefaultConventions();
                x.AddAllTypesOf<Profile>();
            });

        }

        private static IMapper BuildMapper(IContext context)
        {
            return new MapperConfiguration(mapConfig =>
            {
                foreach (var profile in context.GetAllInstances<Profile>())
                {
                    mapConfig.AddProfile(profile);
                }
            }).CreateMapper();
        }
    }
}
