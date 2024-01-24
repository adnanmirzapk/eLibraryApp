using Dapper;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.BusinessLogic
{
    public static class UserBizLogic
    {
        public static List<UserModel> GetAllUsers()
        {
            return DataAccess.GetAllRecords<UserModel>("spUsers_GetAll");
        }

        public static UserModel GetUserByID(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);
            return DataAccess.GetRecordById<UserModel>("spUsers_GetByID", p);
        }

        public static int AddOrEdit(UserModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.UserID);
            p.Add("@UserName", model.UserName);
            p.Add("@Password", model.Password);
            p.Add("@BorrowerID", model.BorrowerID);
            p.Add("IsStaff", model.IsStaff);
            p.Add("@EmployeeID", model.EmployeeID);

           return DataAccess.DbEntityOperations("spUsers_Upsert", p);
        }

        public static int DeleteUser(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spUsers_Delete", p);
        }
    }
}
