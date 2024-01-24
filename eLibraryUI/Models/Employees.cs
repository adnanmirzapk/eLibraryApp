using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = "";

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = "";

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Position of an employee is required")]
        public string Position { get; set; } = "";

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Display(Name = "Confirm Email Adddress")]
        [Compare("Email", ErrorMessage = "Email and confirm email must match")]
        public string ConfirmEmail { get; set; } = "";

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; } = "";

        public string GetEmployeeDetails
        {
            get
            {
                return FirstName + " " + LastName + " | " + Position + " | " + Email;
            }
        }
    }
}
