using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eLibraryUI.Controllers
{
    public class TransactionController : Controller
    {
        //Get: Transaction/
        public IActionResult Index()
        {
            var data = TransactionBizLogic.GetAllTransactions();
            List<Transactions> transactions = new List<Transactions>();

            data.ForEach(transaction => transactions.Add(
                new Transactions
                {
                    TransactionID = transaction.TransactionID,
                    BorrowerID = transaction.BorrowerID,
                    BookID = transaction.BookID,
                    BorrowDate = transaction.BorrowDate,
                    DueDate = transaction.DueDate,
                    ReturnDate = transaction.ReturnDate
                }));

            return View(transactions);
        }

        //Get: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int Id = 0)
        {
            if(Id == 0)
            {
                PopulateList();
                return View(new Transactions());
            }
            else
            {
                PopulateList();
                var data = TransactionBizLogic.GetTransactionById(Id);
                Transactions transaction = new Transactions
                {
                    TransactionID = data.TransactionID,
                    BorrowerID = data.BorrowerID,
                    BookID = data.BookID,
                    BorrowDate = data.BorrowDate,
                    DueDate = data.DueDate,
                    ReturnDate = data.ReturnDate
                };

                return View(transaction);
            }
        }

        //Post: Transaction/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Transactions model)
        {
            TransactionBizLogic.AddOrEdit(new TransactionModel
            {
                TransactionID = model.TransactionID,
                BorrowerID = model.BorrowerID,
                BookID = model.BookID,
                BorrowDate = model.BorrowDate,
                DueDate = model.DueDate,
                ReturnDate = model.ReturnDate
            });


            return RedirectToAction("Index");
        }

        //Post: Transaction/Delete/?Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            TransactionBizLogic.DeleteTransaction(Id);
            return RedirectToAction("Index");
        }

        public void PopulateList()
        {
            var borrowerList = BorrowerBizLogic.GetAllBorrowers();
            ViewBag.BorrowerList = new SelectList(borrowerList, "BorrowerID", "GetBorrowerFullName");

            var bookList = BooksBizLogic.GetAllBooks();
            ViewBag.BookList = new SelectList(bookList, "BookID", "GetBookDetails");
        }

    }
}
