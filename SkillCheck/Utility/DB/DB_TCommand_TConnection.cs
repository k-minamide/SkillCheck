using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using SkillCheck.Utility.Extention;
using SkillCheck.Base.Data;

namespace SkillCheck.Utility.DB
{
    public class DB<TCommand, TConnection>
        where TCommand : IDbCommand, new()
        where TConnection : IDbConnection, new()
    {
        public string ConnectionString
        { get; set; }

        public DB()
        { }

        public TableBase<RowDictionary> Select(string commandText, params IDbDataParameter[] parameters)
        {
            return this.Select<TableBase<RowDictionary>>(commandText, parameters);
        }

        public TTable Select<TTable>(string commandText, params IDbDataParameter[] parameters)
            where TTable : ITable, new()
        {
            return this.ExecuteCommand<TTable>(this.ExecuteSelectCommand<TTable>, commandText, parameters);
        }

        private TTable ExecuteSelectCommand<TTable>(TCommand command)
            where TTable : ITable, new()
        {
            TTable ret = new TTable();

            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                IRow row = ret.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader[i];
                }
                ret.Add(row);
            }

            return ret;
        }

        public virtual int Update(string commandText, params IDbDataParameter[] parameters)
        {
            return ExecuteCommand<int>(this.ExecuteUpdateCommand, commandText, parameters);
        }

        private int ExecuteUpdateCommand(TCommand command)
        {
            return command.ExecuteNonQuery();
        } 

        protected virtual TResult ExecuteCommand<TResult>(Func<TCommand, TResult> executeFunc , string commandText, params IDbDataParameter[] parameters)
            where TResult: new()
        {
            TResult ret = new TResult();

            lock (this)
            {
                using (TCommand command = new TCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Clear();
                    if (parameters.IsNotNull())
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    using (TConnection connection = new TConnection())
                    {
                        command.Connection = connection;
                        command.Connection.ConnectionString = this.ConnectionString;

                        command.Connection.Open();
                        ret = executeFunc(command);
                    }
                }
            }

            return ret;
        }
    }
}
