using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Genres
    {
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        public string GenreName { get; set; } = "";

    }
}
