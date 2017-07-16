using AutoMapper;

namespace Database.Models
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, Core.Domain.Models.Transaction>();

            CreateMap<Core.Domain.Models.Transaction, Transaction>();
        }
    }
}
