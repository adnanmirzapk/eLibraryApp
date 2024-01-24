using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;

namespace eLibraryUI.Controllers
{
    public class UserController : Controller
    {
        //Get: User/Index
        public IActionResult Index()
        {
            var data = UserBizLogic.GetAllUsers();
            List<Users> users = new List<Users>();

            data.ForEach(user => users.Add(new Users
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Password = user.Password,
                BorrowerID = user.BorrowerID,
                IsStaff = user.IsStaff,
                EmployeeID = user.EmployeeID
            }));

            return View(users);
        }

        //Get: User/AddOrEdit
        public IActionResult AddOrEdit(int Id)
        {
            if(Id == 0)
            {
                PopulateLists();
                return View(new Users());
            }

            else
            {
                PopulateLists();
                var data = UserBizLogic.GetUserByID(Id);
                Users user = new Users
                {
                    UserID = data.UserID,
                    UserName = data.UserName,
                    Password = data.Password,
                    BorrowerID = data.BorrowerID,
                    IsStaff = data.IsStaff,
                    EmployeeID = data.EmployeeID
                };

                return View(user);
            }
        }

        //Post: User/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Users user)
        {
            try
            {
                //Get the data ffrom the database for comparison puposes
                var userData = UserBizLogic.GetUserByID(user.UserID);
                int CheckIfUserExists = 0;

                if(userData != null)
                {
                    //This condition is checked when the user wants to edit any record
                    //Check if the user details enetered by the user already exists 
                    //If the user found then set the value CheckIfUserExists = 1
                    CheckIfUserExists = IfUserExists(userData.UserName);
                }
                else
                {
                    //This condition is checked when the user wants to edit any record
                    //Check if the user details enetered by the user already exists 
                    //If the user found then set the value CheckIfUserExists = 1
                    CheckIfUserExists = IfUserExists(user.UserName);
                }

                //Add user functionality
                if(user.UserID == 0)
                {
                    if(CheckIfUserExists < 1)
                    {
                        if (user.BorrowerID == 0)
                        {
                            UserBizLogic.AddOrEdit(new UserModel
                            {
                                UserID = user.UserID,
                                UserName = user.UserName,
                                Password = user.Password,
                                BorrowerID = 0,
                                IsStaff = user.IsStaff,
                                EmployeeID = user.EmployeeID
                            });

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            UserBizLogic.AddOrEdit(new UserModel
                            {
                                UserID = user.UserID,
                                UserName = user.UserName,
                                Password = user.Password,
                                BorrowerID = user.BorrowerID,
                                IsStaff = user.IsStaff,
                                EmployeeID = 0
                            });

                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["IfUserExists"] = "User already exists in the database";
                        PopulateLists();
                        return View(user);
                    }
                }
                //Edit user functionality
                else
                {
                    CheckIfUserExists = IfUserExists(user.UserName);
                    if(CheckIfUserExists < 1)
                    {
                        if (user.BorrowerID == 0)
                        {
                            UserBizLogic.AddOrEdit(new UserModel
                            {
                                UserID = user.UserID,
                                UserName = user.UserName,
                                Password = user.Password,
                                BorrowerID = 0,
                                IsStaff = user.IsStaff,
                                EmployeeID = user.EmployeeID
                            });

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            UserBizLogic.AddOrEdit(new UserModel
                            {
                                UserID = user.UserID,
                                UserName = user.UserName,
                                Password = user.Password,
                                BorrowerID = user.BorrowerID,
                                IsStaff = user.IsStaff,
                                EmployeeID = 0
                            });

                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["IfUserExists"] = "User already exists in the database";
                        PopulateLists();
                        return View(user);
                    }
                }
            }
            catch(Exception ex)
            {
                PopulateLists();
                return View(user);
            }
        }

        //Post: Users/Delete/?Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            UserBizLogic.DeleteUser(Id);
            return RedirectToAction("Index");
        }

        public void PopulateLists()
        {
            var borrowers = BorrowerBizLogic.GetAllBorrowers();
            ViewBag.BorrowersList = new SelectList(borrowers, "BorrowerID", "GetBorrowerDetails");

            var employees = EmployeeBizLogic.GetAllEmployees();
            ViewBag.EmployeeList = new SelectList(employees, "EmployeeID", "GetEmployeeDetails");
        }

        private int IfUserExists(string? userName)
        {
            var users = UserBizLogic.GetAllUsers();
            int userFound = users.Where(x => x.UserName.Equals(userName)).Count();
            return userFound;
        }

    }
}
