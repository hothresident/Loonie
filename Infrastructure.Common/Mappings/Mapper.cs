using Domain.Services.Interfaces;

namespace Infrastructure.Common.Mappings
{
    public class Mapper : IMapper
    {
        private readonly AutoMapper.IMapper _mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestinationType Map<TDestinationType>(object source)
        {
            return _mapper.Map<TDestinationType>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
