using eLibraryData.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int GenreID { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalPages { get; set; }
        public int PublisherID { get; set; }
        public int AuthorID { get; set; }

        public string GetBookDetails
        {
            get
            {
                return Title + " | " + GetGenreName + " | " + GetAuthorName + " | " + GetPhblisherName; 
            }
        }

        public string GetGenreName
        {
            get
            {
                var genre = GenreBizLogic.GetGenreByID(GenreID);
                return genre.GenreName;
            }
        }

        public string GetPhblisherName
        {
            get
            {
                var publisher = PublishersBizLogic.GetPublisherById(PublisherID);
                return publisher.PublisherName;
            }
        }

        public string GetAuthorName
        {
            get
            {
                var author = AuthorsBizLogic.GetAuthorByID(AuthorID);
                return author.FirstName + " " + author.LastName;
            }
        }
    }
}
