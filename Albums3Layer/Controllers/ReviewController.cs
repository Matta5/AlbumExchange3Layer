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
                // Hardcoded user_id
                int userId = 3;

                // Ensure you're passing the userId to the AddReview method
                _reviewService.AddReview(model.UserName, model.Title, model.Rating, model.Comment, userId);

                return RedirectToAction("Index"); // Redirect to a confirmation page or list view
            }
            return View(model);
        }
    }
}
