using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base.Data
{
    public interface ITable<TRow> : ITable
        where TRow : IRow
    {
        new TRow NewRow();

        void Add(TRow row);
    }
}