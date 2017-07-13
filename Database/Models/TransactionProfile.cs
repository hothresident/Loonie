using AutoMapper;

namespace Database.Models
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, Core.Domain.Models.Transaction>()
                .ForMember(d => d.AccountId, opt => opt.MapFrom(s => s.AccountId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Core.Domain.Models.Transaction, Transaction>();
        }
    }
}
