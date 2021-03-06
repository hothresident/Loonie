﻿using StructureMap;

namespace Loonie
{
    public static class ContainerHelper
    {
        private static Container _container;

        static ContainerHelper()
        {
            _container = new Container(c =>
            {
                c.Scan(x =>
                {
                    x.AssembliesFromApplicationBaseDirectory();
                    x.LookForRegistries();
                    x.WithDefaultConventions();
                });
            });
        }

        public static Container Container => _container;
    }
}
