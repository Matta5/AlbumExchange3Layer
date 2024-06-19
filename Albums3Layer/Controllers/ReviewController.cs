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

        [HttpPost]
        public IActionResult Add(string userName, string title, int rating, string comment, int userId)
        {
            _reviewService.AddReview(userName, title, rating, comment, userId);
            return RedirectToAction("Index");
        }
    }
}
