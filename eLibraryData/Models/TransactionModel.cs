using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLibraryData.Models
{
    public class TransactionModel
    {
        public int TransactionID { get; set; }
        public int BorrowerID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = new DateTime().AddDays(7);
        public DateTime ReturnDate { get; set; } = DateTime.Now;
    }
}
