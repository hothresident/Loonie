using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Mapper
{
    public class Mapper : IMapper
    {
        private readonly AutoMapper.Mapper _mapper;

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
