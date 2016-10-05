using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Utility.DB
{
    public interface IColumn
    {
        bool IsParameterValue { get; }

        string GetColumnElement();

        object GetParameter();
    }
}
