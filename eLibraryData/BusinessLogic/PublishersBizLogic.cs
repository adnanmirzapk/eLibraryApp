using Dapper;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.BusinessLogic
{
    public static class PublishersBizLogic
    {
        public static List<PublisherModel> GetAllPublishers()
        {
            return DataAccess.GetAllRecords<PublisherModel>("spPublishers_GetAll");
        }

        public static void AddOrEdit(PublisherModel publisher)
        {
            var p = new DynamicParameters();
            p.Add("@ID", publisher.PublisherID);
            p.Add("@PublisherName", publisher.PublisherName);
            p.Add("@Address", publisher.Address);
            p.Add("@PhoneNumber", publisher.PhoneNumber);
            p.Add("@Email", publisher.Email);

            DataAccess.DbEntityOperations("spPublishers_Upsert", p);
        }

        public static PublisherModel GetPublisherById(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);
            return DataAccess.GetRecordById<PublisherModel>("spPublishers_GetById", p);
        }

        public static int DeletePublisher(int Id)
        {
            var p = new DynamicParameters();
            p.Add("@ID", Id);

            return DataAccess.DbEntityOperations("spPublishers_Delete", p);
        }
    }
}
