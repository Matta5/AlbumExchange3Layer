﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BLL;
using BLL.Interfaces;

namespace DAL
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;

        public ReviewRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddReview(Review review)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Review (rating, comment, title, user_id, date) VALUES (@rating, @comment, @title, @user_id, @date)",
                    connection);
                command.Parameters.AddWithValue("@rating", review.Rating);
                command.Parameters.AddWithValue("@comment", review.Comment);
                command.Parameters.AddWithValue("@title", review.Title);
                command.Parameters.AddWithValue("@user_id", review.UserId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Review> GetReviews()
        {
            var reviews = new List<Review>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Review", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var review = new Review
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("review_id")),
                            Rating = reader.GetInt32(reader.GetOrdinal("rating")),
                            Comment = reader.GetString(reader.GetOrdinal("comment")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            UserId = reader.GetInt32(reader.GetOrdinal("user_id"))
                        };
                        reviews.Add(review);
                    }
                }
            }

            return reviews;
        }
    }
}