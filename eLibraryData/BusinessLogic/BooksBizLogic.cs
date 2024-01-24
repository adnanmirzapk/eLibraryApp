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
    public static class BooksBizLogic
    {
        public static List<BookModel> GetAllBooks()
        {
            return DataAccess.GetAllRecords<BookModel>("spBooks_GetAll");
        }

        public static BookModel GetBookByID(int Id) 
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<BookModel>("spBooks_GetById", p);
        }

        public static int AddOrEdit(BookModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.BookID);
            p.Add("@Title", model.Title);
            p.Add("@ISBN", model.ISBN);
            p.Add("@GenreID", model.GenreID);
            p.Add("@PublishedDate", model.PublishedDate);
            p.Add("@TotalCopies", model.TotalCopies);
            p.Add("@AvailableCopies", model.AvailableCopies);
            p.Add("@TotalPages", model.TotalPages);
            p.Add("@PublisherID", model.PublisherID);
            p.Add("@AuthorID", model.AuthorID);

            return DataAccess.DbEntityOperations("spBooks_Upsert", p);
        } 

        public static int DeleteBook(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spBooks_Delete", p);
        }
    }
}
