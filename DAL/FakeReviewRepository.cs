using BLL;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class FakeReviewRepository : IReviewRepository
    {
        private readonly List<Review> _reviews = new List<Review>();

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public void DeleteReview(int reviewId)
        {
            var review = _reviews.FirstOrDefault(r => r.Id == reviewId);
            if (review != null)
            {
                _reviews.Remove(review);
            }
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviews;
        }
    }
}