﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base;
using SkillCheck.Base.Data;

namespace SkillCheck.ViewModel.Data
{
    public class BookDataRow : RowBase
    {
        /// <summary>
        /// 本ID
        /// </summary>
        [DataColumn]
        public long ID
        {
            get { return base.GetValue<long>(); }
            set { base.SetValue(value); }
        }

        /// <summary>
        /// 本名
        /// </summary>
        [DataColumn]
        public string Name
        {
            get { return base.GetValue<string>(); }
            set { base.SetValue(value); }
        }
    }
}
