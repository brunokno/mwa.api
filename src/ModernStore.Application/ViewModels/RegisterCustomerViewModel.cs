using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class RegisterCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
