using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BLL;
using BLL.Interfaces;

[TestClass]
public class ReviewServiceTests
{
    private IReviewRepository _fakeReviewRepository;
    private ReviewService _reviewService;

    [TestInitialize]
    public void Setup()
    {
        _fakeReviewRepository = new FakeReviewRepository();
        _reviewService = new ReviewService(_fakeReviewRepository);
    }

    [TestMethod]
    public void DeleteReview_WithCorrectUserId_ShouldDeleteReview()
    {

        int userId = 3;
        int reviewId = 1;
        _fakeReviewRepository.AddReview(new Review { Id = reviewId, UserId = userId });


        _reviewService.DeleteReview(reviewId, userId);


        Assert.IsFalse(_fakeReviewRepository.GetReviews().Any(r => r.Id == reviewId), "Review should be deleted.");
    }

    [TestMethod]
    [ExpectedException(typeof(UnauthorizedAccessException))]
    public void DeleteReview_WithIncorrectUserId_ShouldThrowException()
    {

        int unauthorizedUserId = 2;
        int reviewId = 1;
        _fakeReviewRepository.AddReview(new Review { Id = reviewId, UserId = 3 });


        _reviewService.DeleteReview(reviewId, unauthorizedUserId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddReview_WithBannedWordsInComment_ShouldThrowException()
    {

        string commentWithBannedWords = "This is a comment with ziektes.";


        _reviewService.AddReview("User1", "Title1", 5, commentWithBannedWords, 1);
    }

    [TestMethod]
    public void AddReview_WithoutBannedWordsInComment_ShouldAddReview()
    {

        string commentWithoutBannedWords = "This is a safe comment.";


        _reviewService.AddReview("User1", "Title1", 5, commentWithoutBannedWords, 1);


        Assert.IsTrue(_fakeReviewRepository.GetReviews().Any(r => r.Comment == commentWithoutBannedWords), "Review should be added.");
    }
}
