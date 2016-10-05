using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Base
{
    public class PropertyChangeEventArgs<T> : EventArgs
    {
        public T OldValue
        { get; private set; }

        public T NewValue
        { get; private set; }

        public PropertyChangeEventArgs(T oldValue, T newValue) : base()
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
