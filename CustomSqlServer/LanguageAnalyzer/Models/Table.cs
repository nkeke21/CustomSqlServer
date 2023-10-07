using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSqlServer.LanguageAnalyzer
{
    internal class Table
    {
        public string TableName { get; set; }
        public List<TableRecord> Records { get; set; }
    }
}