using Core.Domain.Enums;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Infrastructure.Translation.Parsers
{
    public static class QifParser
    {
        public static Account Parse(string path)
        {
            var file = FileReader.Read(path);

            var records = file.Substring(file.IndexOf("<STMTTRN>"))
                .Split(new string[] { "<STMTTRN>" }, System.StringSplitOptions.RemoveEmptyEntries);

            var account = new Account
            {
                AccountNumber = file.Parse("ACCTID").Trim(),
                Transactions = records.Select(r => new Transaction
                {
                    Amount = decimal.Parse(r.Parse("TRNAMT")),
                    Memo = r.Parse("NAME").Trim(),
                    //Type = (TransactionType)Enum.Parse(typeof(TransactionType), r.Parse("TRNTYPE").ToTitleCase()),
                    Type =  r.Parse("TRNTYPE").ToTitleCase(),
                    DatePosted = r.Parse("DTPOSTED").ParseDate(),
                }).ToList()
            };

            return account;
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
