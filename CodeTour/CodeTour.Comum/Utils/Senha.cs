using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTour.Comum.Utils
{
   public static class Senha
    {

        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool ValidacaoSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

        public static string GeradorSenha()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz023456789";
            string senha = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                senha = senha + caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
            }
            return senha;
        }
    }
}
