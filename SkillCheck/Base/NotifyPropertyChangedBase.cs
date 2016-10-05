using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using SkillCheck.Utility.Extention;

namespace SkillCheck.Base
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propartyName = null)
        {
            if (this.PropertyChanged.IsNotNull())
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propartyName));
            }
        }

        protected virtual void SetValue<T>(T value, ref T setInstance, [CallerMemberName]string propartyName = null)
        {
            setInstance = value;
            this.OnPropertyChanged(propartyName);
        }
    }
}
