using Core.Domain.Models;
using System.Collections.Generic;

namespace Domain.Services.Interfaces
{
    public interface IRepository
    {
        void Save(IEnumerable<Transaction> transactions);
    }
}
