﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSqlServer.LanguageAnalyzer
{
    public class TableRecord
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string DataLength { get; set; }
    }
}