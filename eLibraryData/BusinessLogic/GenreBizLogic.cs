using Dapper;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.BusinessLogic
{
    public static class GenreBizLogic
    {
        public static List<GenreModel> GetAllGenre()
        {
            return DataAccess.GetAllRecords<GenreModel>("spGenres_GetAll"); 
        }

        public static GenreModel GetGenreByID(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<GenreModel>("spGenres_GetById", p);
        }

        public static int AddOrEdit(GenreModel genre)
        {
            var p = new DynamicParameters();
            p.Add("@ID", genre.GenreID);
            p.Add("@GenreName", genre.GenreName);

            return DataAccess.DbEntityOperations("spGenres_Upsert", p);
        }

        public static int DeleteGenere(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spGenres_Delete", p);
        }
    }
}
