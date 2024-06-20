using System.ComponentModel.DataAnnotations;

namespace Albums3Layer.BBL.Models
{
    public class User
    {
        public string? profile_picture { get; set; }
        public int user_id { get; set; }
        [Required]
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string new_username { get; set; }





    }
}
