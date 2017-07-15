using Database.Models;
using Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Linq;

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

        public async Task Save(IEnumerable<Core.Domain.Models.Transaction> transactions)
        {
            _context.Transactions.AddRange(_mapper.Map<IEnumerable<Transaction>>(transactions));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Core.Domain.Models.Transaction>> GetAsync()
        {
            return _mapper.Map<List<Core.Domain.Models.Transaction>>(await _context.Transactions.ToListAsync());
        }

        public async Task<int> GetTransactionIndexAsync()
        {
            return await _context.Transactions.MaxAsync(t => t.Id);
        }
    }
}
