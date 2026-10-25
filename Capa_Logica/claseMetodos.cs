using System.Security.Cryptography;
using System.Text;

namespace Capa_Logica
{
    public class claseMetodos
    {
        // -- encryptToSHA256
        // Convierte cualquier texto en su hash SHA-256 (cadena hexadecimal de 64 chars).

        // ¿Por qué se usa en el sistema?
        ///   Porque las contraseñas NUNCA se guardan como texto plano en la base de datos.
        ///   Antes de guardar o comparar, se encripta la concatenacion entre la contraseña y el nombre del usuario.
        ///   Concatenar con el nombre de usuario actua de manera que dos usuarios con
        ///   la misma contraseña tendrán hashes diferentes.

        // SHA-256 es una función de una sola vía: dado el hash no se puede recuperar el texto original.
        public static string encryptToSHA256(string rawData)
        {
            // SHA256.Create() devuelve el motor de hashing.
            // "using" lo descarta correctamente al salir del bloque.
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Paso 1: convertir el string a bytes usando UTF-8.
                // Paso 2: calcular el hash a un arreglo de 32 bytes (256 bits).
                byte[] hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Paso 3: convertir cada byte a su representación hexadecimal de 2 dígitos.
                // "x2" = hex minúscula con cero a la izquierda si es necesario.
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString(); // Resultado: string encriptado en SHA256 de 64 caracteres
            }
        }

        // Las contraseñas temporales del sistema son siempre 6 dígitos. Ese formato no se permite
        // al elegir una contraseña propia, por eso sirve para detectar que se entró con una temporal.
        public static bool EsContrasenaTemporal(string contrasena)
        {
            if (contrasena.Length != 6) return false;
            foreach (char c in contrasena)
            {
                if (c < '0' || c > '9') return false;
            }
            return true;
        }
    }
}