using Assessment_SlipStream.DAL.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Assessment_SlipStream.DAL
{
    public static class DapperExtension
    {
        public static IEnumerable<T> Get<T>(this AppConfiguration configuration, string Query, T parameters, CommandType commandType = CommandType.StoredProcedure) where T : class
        {
            string ConnString = configuration.sqlConnectionString;

            using (var connection = new SqlConnection(ConnString))
            {
                return connection.Query<T>(Query, parameters, commandType: commandType, commandTimeout: 300);
            }
        }
        public static bool AddUpdate<T>(this AppConfiguration configuration, string Query, T parameters, CommandType commandType = CommandType.StoredProcedure) where T : class
        {
            string ConnString = configuration.sqlConnectionString;

            using (var connection = new SqlConnection(ConnString))
            {
                return connection.Execute(Query, parameters, commandType: commandType, commandTimeout: 300) > 0;
            }
        }

        public static string FlattenQuery(string Query, List<SqlParameter> sqlParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            DynamicParameters parameter = new DynamicParameters();
            foreach (var params_ in sqlParameters)
            {
                parameter.Add(params_.ParameterName, params_.Value);
            }


            Query = $"{Query} { string.Join(",", sqlParameters.Select(p => $"@{p.ParameterName.Replace("@", "")} = {(p.Value != null ? $"{(!p.Value.ToString().StartsWith("@") ? "'" : "")}{p.Value}{(!p.Value.ToString().StartsWith("@") ? "'" : "")}" : "null")}").ToArray()) }";

            return Query;
        }
    }
}
