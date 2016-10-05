using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Utility.Extention;

namespace SkillCheck.Utility.DB
{
    public class Column : IColumn
    {
        public IColumn Value
        { get; private set; }

        public Column(object value)
        { this.Value = new FixedColumn(value); }

        public Column(string columnName)
        { this.Value = new TableColumn(null, columnName); }

        public Column(string tableName, string columnName)
        { this.Value = new TableColumn(tableName, columnName); }

        public virtual bool IsParameterValue
        { get { return this.Value.IsNull() ? false : this.Value.IsParameterValue; } }

        public virtual string GetColumnElement()
        { return this.Value.IsNull() ? string.Empty : this.Value.GetColumnElement(); }

        public virtual object GetParameter()
        { return this.Value.IsNull() ? null : this.Value.GetParameter(); }
    }
}
