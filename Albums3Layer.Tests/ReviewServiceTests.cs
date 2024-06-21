using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BLL; // Assuming your business logic layer namespace
using BLL.Interfaces; // Assuming your business logic interfaces are here
using System.Linq;

[TestClass]
public class ReviewServiceTests
{
    private FakeReviewRepository _fakeReviewRepository;
    private IReviewService _reviewService; // Assuming an IReviewService interface

    [TestInitialize]
    public void Setup()
    {
        _fakeReviewRepository = new FakeReviewRepository();
        _reviewService = new ReviewService(_fakeReviewRepository); // Assuming ReviewService takes an IReviewRepository in its constructor
    }

    [TestMethod]
    public void AddReview_ShouldIncreaseCount()
    {
        // Arrange
        var initialCount = _fakeReviewRepository.GetAllReviews().Count();
        var review = new Review { /* Initialize review properties */ };

        // Act
        _reviewService.AddReview(review);

        // Assert
        var newCount = _fakeReviewRepository.GetAllReviews().Count();
        Assert.AreEqual(initialCount + 1, newCount);
    }

    // Add more tests as needed
}
