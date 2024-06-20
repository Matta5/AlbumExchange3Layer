using Microsoft.AspNetCore.Mvc;
using BLL;

namespace Albums3Layer.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var reviews = _reviewService.GetReviews();
            return View(reviews);
        }

        [HttpGet]
        public IActionResult Add()
        {
               return View();
        }

        [HttpPost]
        public IActionResult Add(Review model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = 18; // Example user ID, this should be dynamically determined based on your application's requirements

                    model.UserId = userId;


                    _reviewService.AddReview(model.UserName, model.Title, model.Rating, model.Comment, userId);

                    return RedirectToAction("Index");
                }
                catch (ArgumentException ex)
                {
                    // Add the exception message to the ModelState to display in the view
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }





    }
}
