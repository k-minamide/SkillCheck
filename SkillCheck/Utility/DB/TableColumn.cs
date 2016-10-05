using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Utility.Extention;

namespace SkillCheck.Utility.DB
{
    public class TableColumn : IColumn
    {
        public string TableName
        { get; private set; }

        public string ColumnName
        { get; private set; }

        public TableColumn(string columnName)
        {
            this.TableName = null;
            this.ColumnName = columnName;
        }

        public TableColumn(string tableName, string columnName)
        {
            this.TableName = tableName;
            this.ColumnName = columnName;
        }

        public bool IsParameterValue
        { get { return false; } }

        public string GetColumnElement()
        {
            string format = string.Empty;
            if (this.TableName.IsNullOrWhiteSpace())
            { format = "{1}"; }
            else
            { format = "{0}.{1}"; }

            return string.Format(format, this.TableName, this.ColumnName);
        }

        public object GetParameter()
        { return null; }
    }
}
