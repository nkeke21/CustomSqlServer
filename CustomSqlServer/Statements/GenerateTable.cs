using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSqlServer.LanguageAnalyzer
{
    public static class GenerateTable
    {
        public static void GenerateTables(string query)
        {
            var lexer = new SqlLexer(query);
            var tokens = new List<SqlToken>();
            while (true)
            {
                var token = lexer.GetNextToken();
                if (token.Kind == SqlTokenKind.EndOfFile)
                    break;
                else if (token.Kind == SqlTokenKind.Alias)
                    continue;

                tokens.Add(token);
            }

            var tableRecord = new Table
            {
                Records = new List<TableRecord>()
            };
        }
    }
}


