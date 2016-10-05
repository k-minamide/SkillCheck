using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base.Data
{
    public interface ITable
    {
        IRow NewRow();

        void Add(IRow row);
    }
}
