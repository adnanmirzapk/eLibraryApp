using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eLibraryUI.Controllers
{
    public class BorrowerController : Controller
    { 
        //Get: /Borrower/Index
        public IActionResult Index()
        {
            var data = BorrowerBizLogic.GetAllBorrowers();
            List<Borrowers> borrowers = new List<Borrowers>();

            data.ForEach(borrower => borrowers.Add(new Borrowers
            {
                BorrowerID = borrower.BorrowerID,
                FirstName = borrower.FirstName,
                LastName = borrower.LastName,
                Address = borrower.Address,
                PhoneNumber = borrower.PhoneNumber,
                Email = borrower.Email
            }));

            return View(borrowers);
        }

        //Get: /Borrower/AddOrEdit
        public IActionResult AddOrEdit(int Id = 0)
        {
            if(Id == 0)
            {
                return View(new Borrowers());
            }
            else
            {
                var data = BorrowerBizLogic.GetBorrowerById(Id);
                Borrowers borrower = new Borrowers
                {
                    BorrowerID = data.BorrowerID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Address = data.Address,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email
                };

                return View(borrower);
            }
        }

        //Post: Borrower/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Borrowers model)
        {
            try
            {
                //Get the data from the database for comparison
                var borrower = BorrowerBizLogic.GetBorrowerById(model.BorrowerID);

                int CheckIfBorrowerExists = 0;
                if (borrower != null)
                {
                    CheckIfBorrowerExists = IfBorrowerExists(borrower.GetBorrowerDetails);
                }
                else
                {
                    CheckIfBorrowerExists = IfBorrowerExists(model.GetBorrowerDetails);
                }

                //Add new borrower functionality
                if(model.BorrowerID == 0)
                {
                    if(CheckIfBorrowerExists < 1)
                    {
                        BorrowerBizLogic.AddOrEdit(new BorrowerModel
                        {
                            BorrowerID = model.BorrowerID,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Address = model.Address,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["BorrowerAlreadyExists"] = "Borrower already exists";
                        return View(model);
                    }
                }
                //Edit funtionality of borrower
                else
                {
                    CheckIfBorrowerExists = IfBorrowerExists(model.GetBorrowerDetails);
                    if(CheckIfBorrowerExists < 1)
                    {
                        BorrowerBizLogic.AddOrEdit(new BorrowerModel
                        {
                            BorrowerID = model.BorrowerID,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Address = model.Address,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["BorrowerAlreadyExists"] = "Borrower already exists";
                        return View(model);
                    }
                }          
            }
            catch(Exception ex)
            {
                return View(model);
            }
            
        }

        //Post: Borrower/Delete/?Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            BorrowerBizLogic.DeleteBorrower(Id);
            return RedirectToAction("Index");
        }

        public int IfBorrowerExists(string borrowerDetails)
        {
            var data = BorrowerBizLogic.GetAllBorrowers();
            int borrowerFound = data.Where(x => x.GetBorrowerDetails.Equals(borrowerDetails)).Count();
            return borrowerFound;
        }
    }
}
