using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void AddReview(string userName, string title, int rating, string comment, int userId)
        {
            var review = new Review
            {
                UserName = userName,
                Title = title,
                Rating = rating,
                Comment = comment,
                UserId = userId
            };
            _reviewRepository.AddReview(review);
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }
    }
}
