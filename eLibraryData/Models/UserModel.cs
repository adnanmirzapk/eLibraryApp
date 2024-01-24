using eLibraryData.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int BorrowerID { get; set; }
        public Boolean IsStaff { get; set; } = false;
        public int EmployeeID { get; set; }
    }
}
