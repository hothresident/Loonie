using AutoMapper;
using AutoMapper.Configuration;

namespace Infrastructure.Common.Test.Builders
{
    public class MapperBuilder
    {
        private readonly MapperConfigurationExpression _config;

        private MapperBuilder()
        {
            _config = new MapperConfigurationExpression();
        }

        public static MapperBuilder Create() => new MapperBuilder();

        public Mappings.IMapper Build()
        {
            return new TestMapper(new MapperConfiguration(_config)
                .CreateMapper());
        }

        public MapperBuilder WithMap<T>() where T : Profile, new()
        {
            _config.AddProfile<T>();

            return this;
        }
    }

    public class TestMapper : Mappings.IMapper
    {
        private readonly AutoMapper.IMapper _mapper;

        public TestMapper(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDest Map<TDest>(object source)
        {
            return _mapper.Map<TDest>(source);
        }

        public TDest Map<TSource, TDest>(TSource source, TDest destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
