using Core.Domain.Enums;
using Infrastructure.Translation.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System;
using System.Linq;

namespace Test.Translation.Services
{
    [TestClass]
    public class QifParserShould
    {
        [TestMethod]
        public void qifParserShouldReadInCcdFile()
        {
            var target = QifParser.Parse("Artifacts/ccd.qfx");
            target.ShouldNotBeNull();

            var firstResult = target.Transactions.FirstOrDefault();

            //firstResult.AccountId.ShouldEqual("654XXXXXX");
            firstResult.Amount.ShouldEqual(29.84m);
            firstResult.Memo.ShouldEqual("TACO-MART SC - #7896");
            firstResult.DatePosted.ShouldEqual(new DateTime(2017, 05, 17));
            firstResult.Type.ShouldEqual("Credit");
        }

        [TestMethod]
        public void qifParserShouldReadInBankFile()
        {
            var target = QifParser.Parse("Artifacts/history.qfx");
            target.ShouldNotBeNull();

            var firstResult = target.Transactions.FirstOrDefault();

            firstResult.Amount.ShouldEqual(1500.41M);
            firstResult.Memo.ShouldEqual("Work-309lo Bat");
            firstResult.DatePosted.ShouldEqual(new DateTime(2017, 04, 21));
            firstResult.Type.ShouldEqual("Dep");
        }

        [TestMethod]
        public void qifParserShouldReadInCcvFile()
        {
            var target = QifParser.Parse("Artifacts/ccv.QFX");
            target.ShouldNotBeNull();

            var firstResult = target.Transactions.FirstOrDefault();

            firstResult.Amount.ShouldEqual(-50.65m);
            firstResult.Memo.ShouldEqual("WAL-MART #9999           GI");
            firstResult.DatePosted.ShouldEqual(new DateTime(2017, 05, 14));
            firstResult.Type.ShouldEqual("Debit");
        }
    }
}
