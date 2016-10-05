using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillCheck.Utility.Extention
{
    public static class Common
    {
        public static T DefaultValue<T>(this T t)
        {
            return default(T);
        }

        public static T NewValue<T>(this T t)
            where T: new()
        {
            T ret = default(T);
            try
            {
                ret = (T)Activator.CreateInstance(typeof(T));
            }
            catch
            {
                ret = default(T);
            }

            return ret;
        }

        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }

        public static bool IsNotNull<T>(this T obj)
        {
            return !obj.IsNull();
        }

        public static bool IsNullOrEmpty(this string obj)
        {
            return string.IsNullOrEmpty(obj);
        }

        public static bool IsNullOrWhiteSpace(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj);
        }
    }
}
