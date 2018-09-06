using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User:Entity
    {
        public User(){}

        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password =  EncryptPassword(password);
            Active = true;

            AddNotifications(new ValidationContract()
                .AreEquals(Password, EncryptPassword(confirmPassword), "Password", "As senhas não coincidem")
                );
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }

        public bool Authenticate(string username, string password)
        {
            if (Username == username && Password == EncryptPassword(password))
                return true;

            AddNotification("Password", "Usuário ou senha inválidos");
            return false;
        }

        public void Activate() => Active = true;
        public void Desactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
