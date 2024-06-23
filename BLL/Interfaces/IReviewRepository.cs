using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        void DeleteReview(int reviewId);
        IEnumerable<Review> GetReviews();
    }
}