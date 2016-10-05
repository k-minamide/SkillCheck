using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base;

namespace SkillCheck.Utility.DB
{
    public class FixedColumn : IColumn
    {
        public object Value
        { get; private set; }

        public FixedColumn(object value)
        { this.Value = value; }

        public bool IsParameterValue
        { get { return true; } }

        public string GetColumnElement()
        { return Constants.DBParameterAlias; }

        public object GetParameter()
        { return this.Value; }
    }
}
