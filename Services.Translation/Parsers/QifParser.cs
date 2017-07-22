using Core.Domain.Enums;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Infrastructure.Translation.Parsers
{
    public static class QifParser
    {
        public static IEnumerable<Transaction> Parse(string path)
        {
            var file = FileReader.Read(path);

            var records = file.Substring(file.IndexOf("<STMTTRN>"))
                .Split(new string[] { "<STMTTRN>" }, System.StringSplitOptions.RemoveEmptyEntries);

            var accountId = file.Parse("ACCTID").Trim();

            return records.Select(r => new Transaction
            {
                AccountId = accountId,
                Amount = decimal.Parse(r.Parse("TRNAMT")),
                Memo = r.Parse("NAME").Trim(),
                Type = (TransactionType)Enum.Parse(typeof(TransactionType), r.Parse("TRNTYPE").ToTitleCase()),
                Date = r.Parse("DTPOSTED").ParseDate()
            });
        }

        private static string Parse(this string source, string searchString)
        {
            return Regex.Match(source, $"<{searchString}> *[^<]*").Value.Replace($"<{searchString}>", "");
        }

        private static DateTime ParseDate(this string source)
        {
            return DateTime.ParseExact(source.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        private static string ToTitleCase(this string source)
        {
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(source.ToLower());
        }
    }
}
