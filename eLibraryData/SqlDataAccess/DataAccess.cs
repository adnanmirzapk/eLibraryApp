using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace eLibraryData.SqlDataAccess
{
    public static class DataAccess
    {
        public static int DbEntityOperations(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectToDB()))
            {
                return connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public static List<T> GetAllRecords<T>(string sql)
        {
            using(IDbConnection connection = new SqlConnection(DBConnection.ConnectToDB()))
            {
                return connection.Query<T>(sql, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static T GetRecordById<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectToDB()))
            {
                return connection.Query<T>(sql, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }

}
