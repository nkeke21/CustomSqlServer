using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSqlServer.LanguageAnalyzer
{
    public class SqlToken
    {
        public SqlToken(SqlTokenKind kind, string text)
        {
            Kind = kind;
            Text = text;
        }

        public SqlTokenKind Kind { get; }
        public string Text { get; }
    }

}
