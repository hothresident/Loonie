using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using Domain.Services.Interfaces;
using Should;
using Translation.Services;
using Infrastructure.Common.DependencyInjection;

namespace Infrastructure.Common.Test
{
    [TestClass]
    public class LoonieRegistryShould
    {
        private readonly IContainer _target = new Container(c => c.AddRegistry<LoonieRegistry>());

        [TestMethod]
        public void registry_resolves_types()
        {
            _target.GetInstance<IAdapter>()
                .ShouldBeType<Adapter>();
        }
    }
}
