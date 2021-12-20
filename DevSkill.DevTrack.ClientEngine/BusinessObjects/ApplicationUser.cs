using System;

namespace DevSkill.DevTrack.ClientEngine.BusinessObjects
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}