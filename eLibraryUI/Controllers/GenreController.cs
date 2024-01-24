using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eLibraryUI.Controllers
{
    public class GenreController : Controller
    {
        //Get: Gente/Index
        public IActionResult Index()
        {
            var data = GenreBizLogic.GetAllGenre();
            List<Genres> genres = new List<Genres>();

            data.ForEach(genre => genres.Add(new Genres
            {
                GenreID = genre.GenreID,
                GenreName = genre.GenreName
            }));

            return View(genres);
        }

        //Get: Genre/AddOrEdit
        public IActionResult AddOrEdit(int Id = 0)
        {
            if(Id == 0 )
            {
                return View(new Genres());
            }
            else
            {
                var genre = GenreBizLogic.GetGenreByID(Id);
                Genres genres = new Genres
                {
                    GenreID = genre.GenreID,
                    GenreName = genre.GenreName
                };

                return View(genres);
            }
        }

        //Post: Genre/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Genres model)
        {
            try
            {
                int CheckIfGenreExists = 0;

                //Get the data from the database for comparison
                //incase of editing the genre
                var data = GenreBizLogic.GetGenreByID(model.GenreID);
                
                if (data != null)
                {
                    //This condition is checked when the user wants to edit any record
                    //Check if the Genre details enetered by the user already exists 
                    //If the Genre found then set the value CheckIfEmployeeExists = 1
                    CheckIfGenreExists = IfGenreExists(data.GenreName); 
                }
                else
                {
                    //This condition is checked when the user wants to add a new record
                    //Check if the Genre details enetered by the user already exists 
                    //If the Genre found then set the value CheckIfEmployeeExists = 1
                    CheckIfGenreExists = IfGenreExists(model.GenreName);
                }

                //Add new genre functionality
                if(model.GenreID == 0)
                {
                    //if genre does not found thne save the genre 
                    //in the database
                    if(CheckIfGenreExists < 1)
                    {
                        var genre = GenreBizLogic.AddOrEdit(new GenreModel
                        {
                            GenreID = model.GenreID,
                            GenreName = model.GenreName,
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["IfGenreExists"] = "Genere already exists in the database";
                        return View(model);
                    }
                }
                //edit genre functionality
                else
                {
                    //Check if the genre details enetered by the user already exists 
                    //If the genre found then set the value CheckIfEmployeeExists = 1
                    CheckIfGenreExists = IfGenreExists(model.GenreName);
                    if(CheckIfGenreExists < 1)
                    {
                        var genre = GenreBizLogic.AddOrEdit(new GenreModel
                        {
                            GenreID = model.GenreID,
                            GenreName = model.GenreName,
                        });

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["IfGenreExists"] = "Genere already exists in the database";
                        return View(model);
                    }
                }                
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            try
            {
                GenreBizLogic.DeleteGenere(Id);
                return RedirectToAction("Index");
            }
             catch
            {
                return View();
            }
        }

        public int IfGenreExists(string genreName)
        {
            var data = GenreBizLogic.GetAllGenre();
            int genreFound = data.Where(x => x.GenreName.Equals(genreName)).Count();
            return genreFound;
        }
    }
}
