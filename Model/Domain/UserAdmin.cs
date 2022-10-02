using System;

namespace CelebrityAPI.Model.Domain
{
    public class UserAdmin
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
