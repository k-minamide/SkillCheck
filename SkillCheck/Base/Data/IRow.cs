using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base.Data
{
    public interface IRow
    {
        IEnumerable<string> Keys
        {
            get;
        }

        object this[string key]
        {
            get;
            set;
        }
    }
}
