using System;

namespace ModernStore.Application.ViewModels
{
    public class AuthenticateUserViewModel
    {
        public bool Active { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
