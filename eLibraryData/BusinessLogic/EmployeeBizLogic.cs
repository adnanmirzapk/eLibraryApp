using Dapper;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.BusinessLogic
{
    public static class EmployeeBizLogic
    {
        public static List<EmployeeModel> GetAllEmployees()
        {
            return DataAccess.GetAllRecords<EmployeeModel>("spEmployees_GetAll");
        }

        public static EmployeeModel GetEmployeeById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<EmployeeModel>("spEmployees_GetById", p);
        }

        public static int DeleteEmployee(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spEmployees_Delete", p);
        }

        public static int AddOrEdit(EmployeeModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.EmployeeID);
            p.Add("@FirstName", model.FirstName);
            p.Add("@LastName", model.LastName);
            p.Add("@Position", model.Position);
            p.Add("@Email", model.Email);
            p.Add("@PhoneNumber", model.PhoneNumber);

            return DataAccess.DbEntityOperations("spEmployees_Upsert", p);
        }
    }
}
