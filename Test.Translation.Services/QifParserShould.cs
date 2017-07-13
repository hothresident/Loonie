using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Translation.Services.Parsers;
using System.Linq;
using Core.Domain.Enums;

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

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(29.84m);
            firstResult.Memo.ShouldEqual("TACO-MART SC - #7896");
            firstResult.Date.ShouldEqual(new DateTime(2017, 05, 17));
            firstResult.Type.ShouldEqual(TransactionType.Credit);
        }

        [TestMethod]
        public void qifParserShouldReadInBankFile()
        {
            var target = QifParser.Parse("Artifacts/history.qfx");
            target.ShouldNotBeNull();

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(1500.41M);
            firstResult.Memo.ShouldEqual("Work-309lo Bat");
            firstResult.Date.ShouldEqual(new DateTime(2017, 04, 21));
            firstResult.Type.ShouldEqual(TransactionType.Dep);
        }

        [TestMethod]
        public void qifParserShouldReadInCcvFile()
        {
            var target = QifParser.Parse("Artifacts/ccv.QFX");
            target.ShouldNotBeNull();

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(-50.65m);
            firstResult.Memo.ShouldEqual("WAL-MART #9999           GI");
            firstResult.Date.ShouldEqual(new DateTime(2017, 05, 14));
            firstResult.Type.ShouldEqual(TransactionType.Debit);
        }
    }
}
