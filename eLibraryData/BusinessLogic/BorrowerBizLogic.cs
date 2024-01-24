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
    public static class BorrowerBizLogic
    {
        public static List<BorrowerModel> GetAllBorrowers()
        {
            return DataAccess.GetAllRecords<BorrowerModel>("spBorrowers_GetAll");
        }

        public static BorrowerModel GetBorrowerById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<BorrowerModel>("spBorrowers_GetById", p);
        }

        public static int DeleteBorrower(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spBorrowers_Delete", p);
        }

        public static int AddOrEdit(BorrowerModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.BorrowerID);
            p.Add("@FirstName", model.FirstName);
            p.Add("@LastName", model.LastName);
            p.Add("@Address", model.Address);
            p.Add("@PhoneNumber", model.PhoneNumber);
            p.Add("Email", model.Email);

            return DataAccess.DbEntityOperations("spBorrowers_Upsert", p);
        }

    }
}
