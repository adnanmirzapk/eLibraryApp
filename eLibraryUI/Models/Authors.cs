using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace eLibraryUI.Models
{
    public class Authors
    {
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = "";

        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Nationality { get; set; } = "";

        public string FullName 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
