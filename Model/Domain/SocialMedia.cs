using System;

namespace CelebrityAPI.Model.Domain
{
    public class SocialMedia
    {
        public Guid Id { get; set; }
        public string InstagramURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
    }
}
