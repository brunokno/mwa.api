using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : CustomerCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
