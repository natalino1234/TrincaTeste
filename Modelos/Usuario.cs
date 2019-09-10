using System;

namespace Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string AuthToken { get; set; }

        public Usuario(int id, string login, string senha, string nome, string authToken)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Nome = nome;
            AuthToken = authToken;
        }
        public Usuario(string login, string senha, string nome, string authToken)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            AuthToken = authToken;
        }
    }
}
