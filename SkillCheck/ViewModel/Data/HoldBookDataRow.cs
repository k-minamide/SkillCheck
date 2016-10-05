using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base;
using SkillCheck.Base.Data;

namespace SkillCheck.ViewModel.Data
{
    public class HoldBookDataRow : RowBase
    {
        /// <summary>
        /// 場所ID
        /// </summary>
        [DataColumn]
        public long PlaceID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        /// <summary>
        /// 本棚ID
        /// </summary>
        [DataColumn]
        public long BookshelfID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        /// <summary>
        /// 棚ID
        /// </summary>
        [DataColumn]
        public long ShelfID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        /// <summary>
        /// 本ID
        /// </summary>
        [DataColumn]
        public long BookID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }
    }
}
