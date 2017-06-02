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
        public void qifParserShouldReadInDiscoverFile()
        {
            var target = QifParser.Parse("Artifacts/discover.qfx");
            target.ShouldNotBeNull();

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(29.84m);
            firstResult.Description.ShouldEqual("WAL-MART SC - #2702 NIXA MO");
            firstResult.Date.ShouldEqual(new DateTime(2017, 05, 17));
            firstResult.Type.ShouldEqual(TransactionType.Credit);
        }

        [TestMethod]
        public void qifParserShouldReadInBankFile()
        {
            var target = QifParser.Parse("Artifacts/history.qfx");
            target.ShouldNotBeNull();

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(1755.41m);
            firstResult.Description.ShouldEqual("Work-109ME Bat");
            firstResult.Date.ShouldEqual(new DateTime(2017, 04, 21));
            firstResult.Type.ShouldEqual(TransactionType.Dep);
        }

        [TestMethod]
        public void qifParserShouldReadInVisaFile()
        {
            var target = QifParser.Parse("Artifacts/visa.QFX");
            target.ShouldNotBeNull();

            var firstResult = target.FirstOrDefault();

            firstResult.Amount.ShouldEqual(-50.65m);
            firstResult.Description.ShouldEqual("WAL-MART #2702           NI");
            firstResult.Date.ShouldEqual(new DateTime(2017, 05, 14));
            firstResult.Type.ShouldEqual(TransactionType.Debit);
        }
    }
}
