using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Results
{
    public class AuthenticateUserCommandResult : ICommandResult
    {
        public AuthenticateUserCommandResult(){}

        public AuthenticateUserCommandResult(
            string document,
            string email,
            string name,
            string password,
            string username)
        {
            Active = true;
            Document = document;
            Email = email;
            Name = name;
            Password = password;
            Username = username;
            Birthdate = DateTime.Now;
        }

        public bool Active  {get;set;}
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
