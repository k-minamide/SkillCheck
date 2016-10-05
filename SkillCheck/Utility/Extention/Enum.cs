using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillCheck.Utility.DB;

namespace SkillCheck.Utility.Extention
{
    public static class Enum
    {
        public static string EnumToString(this JoinType @enum)
        {
            string ret;

            switch (@enum)
            {
                case JoinType.None:
                    ret = string.Empty;
                    break;
                case JoinType.InnerJoin:
                    ret = "INNER JOIN";
                    break;
                case JoinType.LeftJoin:
                    ret = "LEFT JOIN";
                    break;
                case JoinType.RightJoin:
                    ret = "RIGHT JOIN";
                    break;
                case JoinType.CrossJoin:
                    ret = "CROSS JOIN";
                    break;
                default:
                    ret = @enum.ToString();
                    break;
            }

            return ret;
        }
    }
}
