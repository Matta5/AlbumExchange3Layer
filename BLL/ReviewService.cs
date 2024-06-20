using System;
using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly List<string> _bannedWords = new List<string> { "kanker", "tyfus" };

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

        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }
    }
}
