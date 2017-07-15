using Infrastructure.Common.DependencyInjection;
using Infrastructure.Translation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using StructureMap;

namespace Infrastructure.Common.Test
{
    [TestClass]
    public class LoonieRegistryShould
    {
        private readonly IContainer _target = new Container(c => c.AddRegistry<LoonieRegistry>());

        [TestMethod]
        public void registry_resolves_types()
        {
            _target.GetInstance<Translation.ITranslationFacade>()
                .ShouldBeType<TranslationFacade>();
        }
    }
}
