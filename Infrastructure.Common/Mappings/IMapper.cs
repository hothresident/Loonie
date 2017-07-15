namespace Infrastructure.Common.Mappings
{
    public interface IMapper
    {
        TDestinationType Map<TDestinationType>(object source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
