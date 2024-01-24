using eLibraryData.BusinessLogic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eLibraryUI.Models
{
    public class Users
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [DisplayName(displayName:"User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(dataType: DataType.Password)]
        [DisplayName(displayName: "Password")]
        public string? Password { get; set; }

        [DisplayName(displayName: "Borrower")]
        public int BorrowerID { get; set; }

        [DisplayName(displayName: "Is Staff")]
        public Boolean IsStaff { get; set; }

        [DisplayName(displayName: "Employee Name")]
        public int EmployeeID { get; set; }

    }
}
