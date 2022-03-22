using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlFromScratch.Data;
using MySqlFromScratch.Models;

namespace MySqlFromScratch.Controllers
{
    public class RatingController : Controller
    {

        IMovieRatingProvider data;
        public RatingController(IMovieRatingProvider _data)
        {
            data = _data;
        }
        // GET: RatingController
        public ActionResult Index()
        {
            // get all the data to be displayed, and pass it to the View as a model
            //List<MovieRating> data = new List<MovieRating>();
            //data.Add(new MovieRating() { ID = 0, Description = "One", MinAge = 1, Rating = "ONE", LongerDescription = "ONE ONE ONE" });
            //data.Add(new MovieRating() { ID = 1, Description = "Two", MinAge = 2, Rating = "TWO", LongerDescription = "TWO TWO TWO" });

            
            return View(data.GetAllData());
        }

        // GET: RatingController/Details/5
        public ActionResult Details(int id)
        {
            // get the particular matching record for the id - pass it to the view as the model
            
            MovieRating rating = data.GetMovieRating(id);
            return View(rating);
        }

        // GET: RatingController/Create
        public ActionResult Create()
        {
            //  data to pass to the view (IN THIS CASE), but sometimes you may want to compute defaults here and pass the defaults to the view
            return View();
        }

        // POST: RatingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieRating collection)
        {
            try
            {
                // The data that the user entered into the create form will be in the 'collection' variable
                // use it to create a record, and then redrect to the index
                data.CreateMovieRating(collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // if an exception occurs while creating the record, you will end up here
                return View("ExceptionPage", ex );
            }
        }

        // GET: RatingController/Edit/5
        public ActionResult Edit(int id)
        {
            // get the particular matching record for the id - pass it to the view as the model
            MovieRating rating = data.GetMovieRating(id);
            return View(rating);
          
        }

        // POST: RatingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieRating collection)
        {
            try
            {
                // The data that the user entered into the update form will be in the 'collection' variable
                // use it to update the record, and then redrect to the index
                data.UpdateMovieRating(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // if an exception occurs while creating the record, you will end up here
                return View();
            }
        }

        // GET: RatingController/Delete/5
        public ActionResult Delete(int id)
        {
            // get the particular matching record for the id - pass it to the view as the model
            MovieRating rating = data.GetMovieRating(id);
            return View(rating);
           
        }

        // POST: RatingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MovieRating collection)
        {
            try
            {
                // The user indicated that they wanted to delete the record, the data of the record is in the collection
                // use it to delete the record, and then redrect to the index
                data.DeleteMovieRating(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // if an exception occurs while creating the record, you will end up here
                return View();
            }
        }
    }
}
