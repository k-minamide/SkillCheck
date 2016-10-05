using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base.Data
{
    public class TableBase<TRow> 
        : ObservableCollection<TRow>, ITable<TRow>
        where TRow : IRow, new()
    {
        public void Add(IRow row)
        {
            if (!(row is TRow))
            {
                throw new System.TypeAccessException();
            }
            base.Add((TRow)row);
        }

        public TRow NewRow()
        {
            return new TRow();        
        }

        IRow ITable.NewRow()
        {
            return this.NewRow();
        }
    }
}
