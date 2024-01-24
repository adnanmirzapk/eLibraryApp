using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eLibraryUI.Controllers
{
    public class EmployeeController : Controller
    {
        //Get: Employee/Index
        public IActionResult Index()
        {
            var data = EmployeeBizLogic.GetAllEmployees();
            List<Employees> employees = new List<Employees>();

            data.ForEach(employee => employees.Add(
                new Employees
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Position = employee.Position,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber
                }));

            return View(employees);
        }

        //Get: Employee/AddOrEdit
        public IActionResult AddOrEdit(int Id) 
        {
            if(Id == 0)
            {
                return View(new Employees());
            }
            else
            {
                var data = EmployeeBizLogic.GetEmployeeById(Id);
                Employees employee = new Employees
                {
                    EmployeeID = data.EmployeeID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Position = data.Position,
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber
                };

                return View(employee);
            }
        }

        //Post: Employee/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Employees model)
        {
            //Get the data from the database for comparison
            //incase of editing the employee
            var data = EmployeeBizLogic.GetEmployeeById(model.EmployeeID);
            int CheckIfEmployeeExists = 0;

            if(data != null)
            {
                //This condition is checked when the user wants to edit any record
                //Check if the employee details enetered by the user already exists 
                //If the emplyee found then set the value CheckIfEmployeeExists = 1
                CheckIfEmployeeExists = IfEmployeeExists(data.GetEmployeeDetails);
            }
            else
            {
                //This condition is checked when the user wants to add a new record
                //Check if the employee details enetered by the user already exists 
                //If the emplyee found then set the value CheckIfEmployeeExists = 1
                CheckIfEmployeeExists = IfEmployeeExists(model.GetEmployeeDetails);
            }
            
            //Add new employee functionality
            if(model.EmployeeID == 0)
            {
                //if employee does not found then save the employee
                //in the database
                if(CheckIfEmployeeExists < 1)
                {
                    EmployeeBizLogic.AddOrEdit(new EmployeeModel
                    {
                        EmployeeID = model.EmployeeID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Position = model.Position,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    });

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["IfExployeeExists"] = "Emplyee already exists in the database.";
                    return View(model);
                }
            }
            //Edit employee functionality
            else
            {
                //Check if the employee details enetered by the user already exists 
                //If the emplyee found then set the value CheckIfEmployeeExists = 1
                CheckIfEmployeeExists = IfEmployeeExists(model.GetEmployeeDetails);
                if(CheckIfEmployeeExists < 1)
                {
                    EmployeeBizLogic.AddOrEdit(new EmployeeModel
                    {
                        EmployeeID = model.EmployeeID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Position = model.Position,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    });

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["IfExployeeExists"] = "Emplyee already exists in the database.";
                    return View(model);
                }
            }            
        }

        //Post: Employee/Delete/?{Id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            EmployeeBizLogic.DeleteEmployee(Id);

            return RedirectToAction("Index");
        }

        private int IfEmployeeExists(string employeeDetails)
        {
            var data = EmployeeBizLogic.GetAllEmployees();
            int employeeFound = data.Where(x => x.GetEmployeeDetails.Equals(employeeDetails)).Count();
            return employeeFound;
        }

    }
}
