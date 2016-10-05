using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Base;
using SkillCheck.Utility.Extention;
using SkillCheck.Utility.DB;
using SkillCheck.ViewModel.Data;

namespace SkillCheck.Utility.DB
{
    public class FromClauseElement
    {
        public string TableName
        { get; private set; }

        public string AliasName
        { get; private set; }

        public JoinCondition[] JoinCondition
        { get; private set; }

        public FromClauseElement(string tableName)
            : this(tableName, null)
        { }

        public FromClauseElement(string tableName, string aliasName)
        {
            this.TableName = tableName;
            this.AliasName = aliasName;
        }
    }

    public class JoinCondition
    {
        public JoinType JoinType
        { get; private set; } = JoinType.None;

        public FromClauseElement FromClauseElement
        { get; private set; }

        
    }

    public enum JoinType
    {
        None = 0,
        InnerJoin = 1,
        LeftJoin = 2,
        RightJoin = 3,
        CrossJoin = 4,
    }

    public class JoinClauseElement
    {
        public string LeftTableName
        { get; set; }

        public string LeftColumnName
        { get; set; }

        public string Operator
        { get; set; }

        public string RightTableName
        { get; set; }

        public string RightColumnName
        { get; set; }

        public JoinClauseElement(string tableName, string columnName, string @operator, string value)
        {
           
        }
    }

    public struct WhereClauseElement
    {
        public IColumn LeftColumn
        { get; private set; }

        public string Operator
        { get; set; }

        public IColumn RightColumn
        { get; private set; }
    }
}
