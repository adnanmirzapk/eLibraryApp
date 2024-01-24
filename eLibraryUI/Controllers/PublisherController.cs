using Dapper;
using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryData.SqlDataAccess;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eLibraryUI.Controllers
{
    public class PublisherController : Controller
    {
        //Get: Publisher/
        public IActionResult Index()
        {
            var data = PublishersBizLogic.GetAllPublishers();
            List<Publishers> publishers = new List<Publishers>();

            data.ForEach(publisher => publishers.Add(new Publishers
            { 
                PublisherID = publisher.PublisherID,
                PublisherName = publisher.PublisherName,
                Address = publisher.Address,
                PhoneNumber = publisher.PhoneNumber,
                Email = publisher.Email
            }));

            return View(publishers);
        }

       //Get: Publisher/AddOrEdit
        public IActionResult AddOrEdit(int Id = 0)
        {
            if(Id == 0)
            {
                return View(new Publishers());
            }
            else
            {
                var data = PublishersBizLogic.GetPublisherById(Id);
                Publishers publisher = new Publishers
                {
                    PublisherID = data.PublisherID,
                    PublisherName = data.PublisherName,
                    Address = data.Address,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email
                };

                return View(publisher);
            }
        }

        //Post: Publisher/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Publishers publisher)
        {
            try
            {
                //Get the data from the database for comparison purposes
                var data = PublishersBizLogic.GetPublisherById(publisher.PublisherID);
                int CheckIfPublisherExists = 0;

                if(data != null)
                {
                    //This condition is checked when the user wants to edit any record
                    //Check if the publisher details enetered by the user already exists 
                    //If the publisher found then set the value CheckIfPublisherExists = 1
                    CheckIfPublisherExists = IfPublisherExists(data.PublisherName);
                }
                else
                {
                    //This condition is checked when the user wants to add a new record
                    //Check if the publisher details enetered by the user already exists 
                    //If the publisher found then set the value CheckIfPublisherExists = 1
                    CheckIfPublisherExists = IfPublisherExists(publisher.PublisherName);
                }

                //Add new publisher functionality
                if(publisher.PublisherID == 0)
                {
                    //If publisher is not already exists the save the publisher
                    //in the database
                    if(CheckIfPublisherExists < 1)
                    {
                        PublishersBizLogic.AddOrEdit(new PublisherModel
                        {
                            PublisherID = publisher.PublisherID,
                            PublisherName = publisher.PublisherName,
                            Address = publisher.Address,
                            PhoneNumber = publisher.PhoneNumber,
                            Email = publisher.Email
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["PublisherAlreadyExists"] = "Publisher already exists with this name";
                        return View(publisher);
                    }
                }
                //edit publisher functionality
                else
                {
                    //Check if the publisher details enetered by the user already exists 
                    //If the publisher found then set the value CheckIfPublisherExists = 1
                    CheckIfPublisherExists = IfPublisherExists(publisher.PublisherName);
                    if(CheckIfPublisherExists < 1)
                    {
                        PublishersBizLogic.AddOrEdit(new PublisherModel
                        {
                            PublisherID = publisher.PublisherID,
                            PublisherName = publisher.PublisherName,
                            Address = publisher.Address,
                            PhoneNumber = publisher.PhoneNumber,
                            Email = publisher.Email
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["PublisherAlreadyExists"] = "Publisher already exists with this name";
                        return View(publisher);
                    }
                }    
            }
            catch
            {
                return View(publisher);
            }
        }

        //Post: Publisher/Delete/{Id}
        public IActionResult Delete(int Id)
        {
            PublishersBizLogic.DeletePublisher(Id);

            return RedirectToAction("Index");
        }

        public int IfPublisherExists(string publisherName)
        {
            var publishers = PublishersBizLogic.GetAllPublishers();
            int publisherFound = publishers.Where(x => x.PublisherName.Equals(publisherName, StringComparison.CurrentCultureIgnoreCase)).Count();
            return publisherFound;
        }
    }
}
