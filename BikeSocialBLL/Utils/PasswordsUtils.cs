using System.Security.Cryptography;

namespace BikeSocialBLL.Utils
{
    public static class PasswordsUtils
    {
        public static string Encrypt(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Criar o Rfc2898DeriveBytes e obter o valor da hash
            // (Rfc2898DeriveBytes: classe que produz uma chave a partir de uma chave base e do outros parâmetros)
            // (pbkdf2 = password-based key derivation function 2)
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combinar o "salt" e os bytes da password
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Combinar o salt e a hash numa string para guardar pass de modo seguro
            return Convert.ToBase64String(hashBytes);
        }

        public static void ValidatePassword(string inputPassword, string dbPassword)
        {
            // Pegar na hashed password guardada na BD
            string savedPasswordHash = dbPassword;

            // Extrair os bytes
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            // Obter o "salt"
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Calcular a hash na pass que o user acabou de introduzir
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Comparar os resultados
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException("Wrong Password");
        }

        public static int GenerateRecoveryPasswordCode()
        {
            string output;
            Random rn = new Random();

            //Gerar primeiro digito
            output = rn.Next(0, 9).ToString();
        
            // Gerar restantes 5
            for(int i = 0; i < 5; i++)
            {
                output += rn.Next(0, 9).ToString();
            }

            return int.Parse(output);
        }
    }
}
