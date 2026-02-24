using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqwang.BackEnd.CSharp.Extension;

namespace Cqwang.BackEnd.CSharp.MySQL
{
    public static class OperateHelper
    {
        public static List<T> ExecuteSQLList<T>(string connectionStr, string sql, MySqlParameter[] parameters, int commandTimeout = 600) where T : new()
        {
            List<T> records = null;
            using (var connection = new MySqlConnection(connectionStr))
            {
                var dataSet = ExecuteDataSet(connection, null, CommandType.Text, sql, parameters, commandTimeout);
                records = dataSet.Tables[0].ToObjectList<T>();
            }
            return records;
        }

        private static DataSet ExecuteDataSet(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] parameters, int commandTimeout)
        {
            var command = PrepareCommand(connection, transaction, commandType, commandText, parameters, commandTimeout);
            var adapter = new MySqlDataAdapter(command);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);//性能较差
            command.Parameters.Clear();
            return dataSet;
        }

        private static void ReplaceDBNull(MySqlParameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
            }
        }

        public static int ExecuteSQLNonQuery(string connectionStr, string sql, MySqlParameter[] parameters, int commandTimeout = 600)
        {
            using (var connection = new MySqlConnection(connectionStr))
            {
                return ExecuteNonQuery(connection, null, CommandType.Text, sql, parameters, commandTimeout);
            }
        }

        private static int ExecuteNonQuery(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] parameters, int commandTimeout)
        {
            var command = PrepareCommand(connection, transaction, commandType, commandText, parameters, commandTimeout);
            int count = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return count;
        }


        private static MySqlCommand PrepareCommand(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] parameters, int commandTimeout)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new MySqlCommand()
            {
                Connection = connection,
                CommandTimeout = commandTimeout,
                CommandText = commandText,
                Transaction = transaction,
                CommandType = commandType
            };
            if (parameters != null && parameters.Length > 0)
            {
                ReplaceDBNull(parameters);
                command.Parameters.AddRange(parameters);
            }
            return command;
        }
    }
}
