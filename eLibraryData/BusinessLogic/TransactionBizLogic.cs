using Dapper;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.BusinessLogic
{
    public static class TransactionBizLogic
    {
        public static List<TransactionModel> GetAllTransactions()
        {
            return DataAccess.GetAllRecords <TransactionModel>("spTransactions_GetAll");
        }

        public static TransactionModel GetTransactionById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.GetRecordById<TransactionModel>("spTransactions_GetById", p);
        }

        public static int DeleteTransaction(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spTransactions_Delete", p);
        }

        public static int AddOrEdit(TransactionModel model)
        {
            var p = new DynamicParameters();
            p.Add("@ID", model.TransactionID);
            p.Add("@BorrowerID", model.BorrowerID);
            p.Add("@BookID", model.BookID);
            p.Add("@BorrowDate", model.BorrowDate);
            p.Add("@DueDate", model.DueDate);
            p.Add("@ReturnDate", model.ReturnDate);

            return DataAccess.DbEntityOperations("spTransactions_Upsert", p);
        }
    }
}
