using eLibraryData.BusinessLogic;

namespace eLibraryUI.Models
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public int BorrowerID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string GetBorrowerName
        {
            get
            {
                var borrower = BorrowerBizLogic.GetBorrowerById(BorrowerID);
                return borrower.FirstName + " " + borrower.LastName;
            } 
        }

        public string GetBookName
        {
            get
            {
                var book = BooksBizLogic.GetBookByID(BookID);
                var author = AuthorsBizLogic.GetAuthorByID(book.AuthorID);
                return book.Title + " | " + author.FirstName + " " + author.LastName;
            }
        }
    }
}
