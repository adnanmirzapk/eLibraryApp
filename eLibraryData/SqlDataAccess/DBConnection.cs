using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace eLibraryData.SqlDataAccess
{
    public static class DBConnection
    {
        public static string ConnectToDB()
        { 
            //return ConfigurationManager.ConnectionStrings[db].ConnectionString;
            return "Server=ALPHA\\SQLEXPRESS; Database=eLibrary; Trusted_Connection=True;TrustServerCertificate=True";
        }
    }
}
