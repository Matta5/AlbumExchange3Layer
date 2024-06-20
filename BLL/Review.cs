namespace BLL
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public string? UserName { get; set; }
    }
}