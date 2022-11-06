using System;

namespace CelebrityAPI.Model.DTO
{
    public class CelebrityDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProfessionId { get; set; }
        public Guid SocialMediaId { get; set; }
    }
}
