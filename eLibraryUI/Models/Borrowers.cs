using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Borrowers
    {
        public int BorrowerID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "Emai address is required")]
        public string Email { get; set; } = "";

        public string GetBorrowerFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string GetBorrowerDetails
        {
            get
            {
                return FirstName + " " + LastName + " | " + PhoneNumber + " | " + Email;
            }
        }

    }
}
