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
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View(reviews);
        }

        [HttpGet]
        public IActionResult Add()
        {
               return View();
        }

        [HttpGet]
        public IActionResult SelectUserId()
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
                    int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

                    model.UserId = userId;

                    _reviewService.AddReview(model.UserName, model.Title, model.Rating, model.Comment, userId);

                    return RedirectToAction("Index");
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteReview(int reviewId)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Retrieve userId from session
            _reviewService.DeleteReview(reviewId, userId); // Pass both reviewId and userId to the service
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult SetUserId(int userId)
        {
            HttpContext.Session.SetInt32("UserId", userId);
            return RedirectToAction("Index"); // Adjust the redirection as needed
        }





    }
}
