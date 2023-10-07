using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomSqlServer.LanguageAnalyzer
{
    internal class SqlLexer
    {
        private readonly string _input;
        private int _position;
        private static readonly Regex IdentifierRegex = new Regex();
    }
}
