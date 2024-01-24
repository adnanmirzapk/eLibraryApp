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
    public static class AuthorsBizLogic
    {
        public static void AddOrEdit(AuthorModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.AuthorID);
            p.Add("@FirstName", model.FirstName);
            p.Add("@Lastname", model.LastName);
            p.Add("@DateOfBirth", model.DateOfBirth);
            p.Add("@Nationality", model.Nationality);

            DataAccess.DbEntityOperations("spAuthors_Upsert", p);
        }

        public static List<AuthorModel> GetAllAuthors()
        {
            return DataAccess.GetAllRecords<AuthorModel>("spAuthors_GetAll");
        }

        public static AuthorModel GetAuthorByID(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<AuthorModel>("spAuthors_GetById", p);
        }

        public static int DeleteAuthor(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);
            return DataAccess.DbEntityOperations("spAuthors_Delete", p);
        }
    }
}
