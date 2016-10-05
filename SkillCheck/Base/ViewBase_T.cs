using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkillCheck.Base
{
    public class ViewBase<T> : Window where T : new()
    {
        public ViewBase()
            : base()
        {
            this.DataContext = new T();
        }
    }
}
