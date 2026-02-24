using EntityFramework.BulkInsert;
using EntityFramework.BulkInsert.Helpers;
using EntityFramework.BulkInsert.Providers;
using EntityFramework.MappingAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.framework.IRepository.EntityFramework
{
    /// <summary>
    /// MySQL批量插入Provider，使用之前要注册
    /// </summary>
    public class EfMySqlBulkInsertProviderWithMappedDataReader : ProviderBase<MySqlConnection, MySqlTransaction>
    {
        public static void Register()
        {
            ProviderFactory.Register<EfMySqlBulkInsertProviderWithMappedDataReader>("MySql.Data.MySqlClient.MySqlConnection");
        }


        protected override string ConnectionString
        {
            get
            {
                return base.DbConnection.ConnectionString;
            }
        }


        public override object GetSqlGeography(string wkt, int srid)
        {
            throw new NotImplementedException();
        }

        public override object GetSqlGeometry(string wkt, int srid)
        {
            throw new NotImplementedException();
        }

        public override void Run<T>(IEnumerable<T> entities, MySqlTransaction transaction)
        {
            //拼接sql和参数
            var parameters = new List<MySqlParameter>();
            Func<string, int, string> getParameterName = (columnName, i) =>
            {
                return $"@{columnName}_{i}";
            };

            Func<bool, string> getFormatter = (isLast) =>
            {
                return isLast ? "{0}" : "{0},";
            };

            var sql = new StringBuilder();
            using (MappedDataReader<T> mappedDataReader = new MappedDataReader<T>(entities, this))
            {
                sql.Append($"INSERT INTO {mappedDataReader.TableName}(");
                int columnCount = 0;
                foreach (KeyValuePair<int, IPropertyMap> col in mappedDataReader.Cols)
                {
                    columnCount++;
                    var formatter = getFormatter(columnCount == mappedDataReader.Cols.Count);
                    sql.AppendFormat(formatter, col.Value.ColumnName);
                }
                sql.Append(") VALUES");

                var rowCount = 0;
                while (mappedDataReader.Read())
                {
                    rowCount++;
                    columnCount = 0;
                    sql.Append("(");
                    foreach (KeyValuePair<int, IPropertyMap> col in mappedDataReader.Cols)
                    {
                        columnCount++;
                        var columnName = col.Value.ColumnName;
                        var parameterName = getParameterName(columnName, rowCount);
                        var parameterValue = mappedDataReader.GetValue(mappedDataReader.Indexes[columnName]);
                        var formatter = getFormatter(columnCount == mappedDataReader.Cols.Count);
                        sql.AppendFormat(formatter, parameterName);
                        parameters.Add(new MySqlParameter() { ParameterName = parameterName, Value = parameterValue });
                    }
                    sql.Append("),");
                }
            }
            if (sql.Length > 0)
            {
                sql.Remove(sql.Length - 1, 1);
            }

            //执行
            if (transaction.Connection.State != ConnectionState.Open)
            {
                transaction.Connection.Open();
            }

            var command = new MySqlCommand()
            {
                Connection = transaction.Connection,
                CommandTimeout = transaction.Connection.ConnectionTimeout,
                CommandText = sql.ToString(),
                CommandType = CommandType.Text
            };

            command.Parameters.AddRange(parameters.ToArray());
            var RecordsAffected = command.ExecuteNonQuery();
        }

        public override Task RunAsync<T>(IEnumerable<T> entities, MySqlTransaction transaction)
        {
            return Task.Run(() =>
            {
                Run(entities, transaction);
            }).ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    //log or throw
                }
            });
        }

        protected override MySqlConnection CreateConnection()
        {
            return new MySqlConnection(this.ConnectionString);
        }
    }
}
