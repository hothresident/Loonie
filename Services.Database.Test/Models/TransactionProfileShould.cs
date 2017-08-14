using Database.Models;
using Infrastructure.Common.Mappings;
using Infrastructure.Common.Test.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System;

namespace Services.Database.Test.Models
{
    [TestClass]
    public class TransactionProfileShould
    {
        private readonly IMapper _mapper = MapperBuilder.Create()
            .WithMap<TransactionProfile>()
            .Build();

        [TestMethod]
        public void TestMethod1()
        {
            var target = new Transaction
            {
                AccountId = 1,
                Amount = 123.123M,
                Id = 1,
                DatePosted = new DateTime(2017, 1, 1),
                Memo = "My memo",
                Reconciled = false
            };

            var result = _mapper.Map<Transaction>(target);

            //result.AccountId.ShouldEqual(1);
        }
    }
}

