using eLibraryData.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Books
    {
        public int BookID { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; } = "";

        public string ISBN { get; set; } = "";

        [Required(ErrorMessage = "Please select atleast one genre")]
        public int GenreID { get; set; }

        [Required]
        [DataType(dataType: DataType.DateTime, ErrorMessage = "date format is not correct")]
        public DateTime PublishedDate { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        [Required]
        public int TotalPages { get; set; }

        [Required(ErrorMessage = "Please select a publisher")]
        public int PublisherID { get; set; }

        [Required(ErrorMessage = "Please select an author")]
        public int AuthorID { get; set; }

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
