using System;

namespace Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(int id, string login, string senha)
        {
            Id = id;
            Login = login;
            Senha = senha;
        }
    }
}
