using eLibraryUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Authorization;

namespace eLibraryUI.Controllers
{
    public class AuthorController : Controller
    {
        // GET: AuthorController
        public ActionResult Index()
        {
           var data = AuthorsBizLogic.GetAllAuthors();
           List<Authors> authors = new List<Authors>();

            data.ForEach(author => authors.Add(new Authors
            {
                AuthorID = author.AuthorID,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                Nationality = author.Nationality
            }));

            //foreach (var item in data)
            //{
            //    authors.Add(new Authors()
            //    {
            //        AuthorID = item.AuthorID,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        DateOfBirth = item.DateOfBirth,
            //        Nationality = item.Nationality
            //    });
            //} 

            return View(authors);
        }


        // GET: AuthorController/AddOrEdit
        public ActionResult AddOrEdit(int Id = 0)
        {
            if (Id == 0)
                return View(new Authors());
            else
            {
                var data = AuthorsBizLogic.GetAuthorByID(Id);
                Authors author = new Authors{
                    AuthorID = data.AuthorID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    DateOfBirth = data.DateOfBirth,
                    Nationality = data.Nationality
                };

                return View(author);
            }      
        }

        // POST: AuthorController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(IFormCollection collection, Authors author)
        {
            try
            {
                //Get the data from the database for comparison purposes
                var data = AuthorsBizLogic.GetAuthorByID(author.AuthorID);
                int checkIfAuthorExists;

                if (data != null) 
                {
                   checkIfAuthorExists = IfAuthorExists(data.FullName);
                }
                else
                {
                   checkIfAuthorExists = IfAuthorExists(author.FullName);
                }
                     
                //Add functionality  
                if (author.AuthorID == 0)
                {
                    if (checkIfAuthorExists < 1)
                    {
                        AuthorsBizLogic.AddOrEdit(new AuthorModel()
                        {
                            AuthorID = author.AuthorID,
                            FirstName = author.FirstName,
                            LastName = author.LastName,
                            DateOfBirth = author.DateOfBirth,
                            Nationality = author.Nationality
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AuthorFirstNameAlreadyExists"] = "Author with this name already exists";
                        TempData["AuthorLastNameAlreadyExists"] = "Author with this name already exists";
                        return View(author);
                    }
                }

                //Edit functionality
                else
                {
                        checkIfAuthorExists = IfAuthorExists(author.FullName);
                        if(checkIfAuthorExists < 1)
                        {
                            AuthorsBizLogic.AddOrEdit(new AuthorModel()
                            {
                                AuthorID = author.AuthorID,
                                FirstName = author.FirstName,
                                LastName = author.LastName,
                                DateOfBirth = author.DateOfBirth,
                                Nationality = author.Nationality
                            });

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["AuthorFirstNameAlreadyExists"] = "Author with this name already exists";
                            TempData["AuthorLastNameAlreadyExists"] = "Author with this name already exists";
                            return View(author);
                        }      
                }
            }
            catch
            {
                return View();
            }
        }

        //POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            try
            {
                AuthorsBizLogic.DeleteAuthor(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public int IfAuthorExists(string authorName)
        {
            var authors = AuthorsBizLogic.GetAllAuthors();
            int authorFound = authors.Where(x => x.FullName.Equals(authorName, StringComparison.OrdinalIgnoreCase)).Count();
            return authorFound;
        }

    }
}
