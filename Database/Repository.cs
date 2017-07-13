using Domain.Services.Interfaces;
using System.Collections.Generic;
using Database.Models;

namespace Database
{
    public class Repository : IRepository
    {
        private LoonieContext _context = new LoonieContext();
        private readonly IMapper _mapper;

        public Repository(IMapper mapper)
        {
            _mapper = mapper;
        }
        //public void Save(IEnumerable<Transaction> transactions)
        //{
        //    _context.Transacations.AddRange(transactions);
        //    _context.SaveChangesAsync();
        //    //_context.SaveChanges();
        //}

        public void Save(IEnumerable<Core.Domain.Models.Transaction> transactions)
        {
            _context.Transactions.AddRange(_mapper.Map<IEnumerable<Transaction>>(transactions));
            _context.SaveChangesAsync();
        }
    }
}
