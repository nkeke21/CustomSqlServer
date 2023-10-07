using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace CustomSqlServer.LanguageAnalyzer
{
    public  class SqlLexer
    {
        private readonly string _input;
        private int _position;
        private static readonly Regex IdentifierRegex = new Regex(@"[A-Za-Z0-9_][A-Za-z0-9_]*");
        private List<SqlToken> _tokens = new List<SqlToken>();

        public SqlLexer(string input) 
        {
            _input = input;
            _position = 0;
        }

        public SqlToken GetNextToken()
        {
            if(_position > _input.Length)
            {
                return new SqlToken(SqlTokenKind.EndOfFile, string.Empty);
            }

            if (char.IsWhiteSpace(_input[_position]))
            {
                while(_position < _input.Length && char.IsWhiteSpace(_input[_position])) 
                {
                    _position++;
                }
            }

            //Create Table
            if (_input.Substring(_position).StartsWith("CREATE TABLE", StringComparison.OrdinalIgnoreCase))
            {
                var start = _position;
                _position += "CREATE TABLE".Length;

                while(_position < _input.Length && char.IsWhiteSpace(_input[_position]))
                {
                    _position++;
                }

                var tableNameStart = _position;
                while(_position < _input.Length && !char.IsWhiteSpace(_input[_position]) && _input[_position] != '(')
                {
                    _position++;
                }

                var tableName = _input.Substring(tableNameStart, _position - tableNameStart);
                return new SqlToken(SqlTokenKind.TableName, tableName);
            }

            var match = IdentifierRegex.Match(_input.Substring(_position));
            if (match.Success)
            {
                var identifier = match.Value;
                _position += identifier.Length;

                if(_position < _input.Length && _input[_position] == ':')
                {
                    _position++;
                    if(identifier.Equals("CREATE TABLE", StringComparison.OrdinalIgnoreCase))
                    {
                        return new SqlToken(SqlTokenKind.CreateTable, identifier);
                    }

                    return new SqlToken(SqlTokenKind.InsertIntoTable, identifier);
                }

                return new SqlToken(SqlTokenKind.DataType, identifier);
            }

            return new SqlToken(SqlTokenKind.Unknown, _input[_position++].ToString());
        }
    }
}
