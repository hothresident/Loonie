using System;
using System.Collections.Generic;
using Core.Domain.Models;
using Domain.Services.Interfaces;
using Translation.Services.Parsers;
using System.Threading.Tasks;

namespace Translation.Services
{
    public class Adapter : IAdapter
    {
        public async Task<IEnumerable<Transaction>> ParseFileAsync(string path)
        {
            return await Task.Run(() => QifParser.Parse(path));
        }
    }
}
