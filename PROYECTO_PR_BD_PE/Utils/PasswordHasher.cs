using System;
using System.Collections.Generic;
using System.Security.Cryptography; // Importante para la encriptación
using System.Text;

namespace PROYECTO_PR_BD_PE.Utils
{
    internal class PasswordHasher
    {
        // Configuraciones para el formato: PBKDF2$100000$sal$hash
        private const int Iterations = 100000;
        private const int SaltSize = 16; // 16 bytes para la sal
        private const int HashSize = 32; // 32 bytes (256 bits) para SHA256
        private const string AlgorithmPrefix = "PBKDF2";

        /// <summary>
        /// Genera el hash de la contraseña para guardarla en la base de datos.
        /// </summary>
        public static string HashPassword(string password)
        {
            // 1. Generar la sal aleatoria
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // 2. Aplicar PBKDF2 con SHA256
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            // 3. Convertir a Base64
            string saltBase64 = Convert.ToBase64String(salt);
            string hashBase64 = Convert.ToBase64String(hash);

            // 4. Concatenar con el formato requerido
            return $"{AlgorithmPrefix}${Iterations}${saltBase64}${hashBase64}";
        }

        /// <summary>
        /// Valida la contraseña ingresada en el Login contra el hash de la base de datos.
        /// </summary>
        public static bool VerifyPassword(string password, string storedHashString)
        {
            if (string.IsNullOrEmpty(storedHashString)) return false;

            string[] parts = storedHashString.Split('$');

            // Validar que tenga las 4 partes exactas del formato
            if (parts.Length != 4 || parts[0] != AlgorithmPrefix)
            {
                return false;
            }

            try
            {
                // Extraer los componentes guardados
                int iterations = int.Parse(parts[1]);
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] storedHash = Convert.FromBase64String(parts[3]);

                // Generar el hash de la contraseña ingresada usando los mismos parámetros
                byte[] computedHash;
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                {
                    computedHash = pbkdf2.GetBytes(storedHash.Length);
                }

                // Comparación segura (evita ataques de tiempo)
                return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
            }
            catch
            {
                // Si la conversión de Base64 falla por un formato corrupto
                return false;
            }
        }
    }
}