using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillCheck.Utility.Extention;

namespace SkillCheck.Utility.DB
{
    public class SelectClauseElement : Column
    {
        public string AliasName
        { get; private set; }

        public SelectClauseElement(object value)
            : this(value, null)
        { }

        public SelectClauseElement(object value, string aliasName)
            : base(value)
        { this.AliasName = aliasName; }

        public SelectClauseElement(string columnName)
            : this(columnName, null)
        { }

        public SelectClauseElement(string tableName, string columnName)
            : this(tableName, columnName, null)
        { }

        public SelectClauseElement(string tableName, string columnName, string aliasName)
            : base(tableName, columnName)
        { this.AliasName = aliasName; }

        public override string GetColumnElement()
        {
            string columnName = this.Value.IsNull() ? string.Empty : this.Value.GetColumnElement();

            string format = string.Empty;
            if (this.AliasName.IsNullOrWhiteSpace())
            { format = "{0}"; }
            else
            { format = "{0} AS {1}"; }

            return string.Format(format, columnName, this.AliasName);
        }
    }
}
