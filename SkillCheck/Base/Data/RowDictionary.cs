using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base.Data
{
    public class RowDictionary : Dictionary<string, object>, IRow
    {
        IEnumerable<string> IRow.Keys
        {
            get
            {
                return base.Keys;
            }
        }
    }
}
