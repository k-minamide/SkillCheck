using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;
using System.Reflection;
using SkillCheck.Utility.Extention;

namespace SkillCheck.Base.Data
{
    public class RowBase : NotifyPropertyChangedBase, IRow
    {
        private Dictionary<string, object> values = new Dictionary<string, object>();

        public IEnumerable<string> Keys
        {
            get { return this.values.Keys; }
        }

        public object this[string name]
        {
            get { return this.GetValue(name); }
            set { this.SetValue(value , name); }
        }

        private Dictionary<string, object> option = new Dictionary<string, object>();
        public Dictionary<string, object> Option
        {
            get { return this.option; }
            set { this.SetValue(value, ref this.option); }
        }

        public RowBase()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.values.Clear();

            List<PropertyInfo> propertyInfoList 
                = this.GetType().GetProperties()
                                .Where(x => Attribute.GetCustomAttribute(x, typeof(DataColumnAttribute)).IsNotNull())
                                .ToList();
            foreach (var propertyInfopropertyInfo in propertyInfoList)
            {
                this.values[propertyInfopropertyInfo.Name] = propertyInfopropertyInfo.PropertyType.DefaultValue();
            }
        }

        protected object GetValue([CallerMemberName]string propartyName = null)
        {
            return this.GetValue<object>(propartyName);
        }

        protected T GetValue<T>([CallerMemberName]string propartyName = null)
        {
            if (propartyName.IsNull())
            {
                throw new ArgumentNullException("propartyName");
            }
            else if (!this.values.ContainsKey(propartyName))
            {
                throw new ArgumentException("プロパティ名が不正です。", "propartyName");
            }
            return (T)this.values[propartyName];
        }

        protected virtual void SetValue<T>(T value, [CallerMemberName]string propartyName = null)
        {
            if (!this.values.ContainsKey(propartyName))
            {
                throw new ArgumentException("プロパティ名が不正です。", "propartyName");
            }
            this.values[propartyName] = value;
            this.OnPropertyChanged(propartyName);
        }

        ////protected override void SetValue<T>(T value, ref T setInstance, [CallerMemberName] string propartyName = null)
        ////{
        ////    if (this.values.ContainsKey(propartyName))
        ////    {
        ////        this.values[propartyName] = value;
        ////    }
        ////    base.SetValue<T>(value, ref setInstance, propartyName);
        ////}
    }
}
