using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base;
using SkillCheck.Base.Data;

namespace SkillCheck.ViewModel.Data
{
    public class CategoryDataRow: RowBase
    {
        /// <summary>
        /// カテゴリID
        /// </summary>
        [DataColumn]
        public long ID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        /// <summary>
        /// カテゴリ名
        /// </summary>
        [DataColumn]
        public string Name
        {
            get { return base.GetValue<string>(); }
            set { base.SetValue(value); }
        }
    }
}
