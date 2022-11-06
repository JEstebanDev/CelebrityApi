using System;
using System.Collections.Generic;

namespace CelebrityAPI.Model.DTO
{
    public class CelebrityResponse
    {
        public Guid Id { get; set; }
        public string ImageURL { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Profession { get; set; }
        public List<string> SocialMedia { get; set; }
    }
}
