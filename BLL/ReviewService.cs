using BLL.Interfaces;


namespace BLL
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly List<string> _bannedWords = new List<string> { "ziektes", "Patrick is geen goede leraar" };

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }


        public void AddReview(string userName, string title, int rating, string comment, int userId)
        {
            // Check for banned words in the comment
            foreach (var bannedWord in _bannedWords)
            {
                if (comment.IndexOf(bannedWord, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentException("A couple of words are banned, you used one. Please keep it family friendly.");
                }
            }

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

        public void DeleteReview(int reviewId, int userId)
        {
            if (userId != 3)
            {
                throw new UnauthorizedAccessException("Only user with ID 3 can delete reviews.");
            }

            _reviewRepository.DeleteReview(reviewId);
        }


        public IEnumerable<Review> GetAllReviews() { return _reviewRepository.GetReviews();}
        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }
    }
}
