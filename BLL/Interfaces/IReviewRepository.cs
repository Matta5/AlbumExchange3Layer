using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        IEnumerable<Review> GetReviews();
    }
}