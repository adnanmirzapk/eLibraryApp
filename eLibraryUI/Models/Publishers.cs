

using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Publishers
    {
        public int PublisherID { get; set; }

        [Required(ErrorMessage = "Phblisher name is required")]
        public string PublisherName { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
