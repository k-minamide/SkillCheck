using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base.Data;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

using System.Reflection;

namespace SkillCheck.ViewModel.Data
{
    public class BookCategoryMappingRow : RowBase
    {
        [DataColumn]
        public long BookID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        [DataColumn]
        public long CategoryID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }
    }
}
