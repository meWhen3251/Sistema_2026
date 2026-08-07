///ClassMethods.cs son las funciones generales reutilizables dentro del sistema.

using Sistema_de_Gestion_de_Usuario.Clases;
using System.Data;
using System.Security.Cryptography; // Para poder encriptar datos a SHA256
using System.Text;
using Sistema_de_Gestion_de_Usuario.Metodos;
using System.Drawing.Text;

namespace Sistema_de_Gestion_de_Usuario.Metodos
{
    internal class ClassMethods
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

        // -- abrirFormulario
        // Navega de un formulario a otro de forma encadenada:
        //   1. Esconde el formulario actual (no lo cierra todavía).
        //   2. Muestra el formulario destino.
        //   3. Cuando el formulario destino se cierra, cierra también el actual.

        // Esto hace que al cerrar el destino se propague el cierre hacia atrás,
        // evitando que queden formularios "fantasma" abiertos en segundo plano.

        // Parámetros:
        //   formularioActual - el Form que llama al método (generalmente "this").
        //   formularioObjetivo - el Form al que se quiere navegar.
        public void abrirFormulario(Form formularioActual, Form formularioObjetivo)
        {
            // FormClosed es un evento: se suscribe una función anónima (lambda)
            // que se ejecutará automáticamente cuando formularioObjetivo se cierre.
            // La lambda (s, args) => formularioActual.Close() cierra el formulario actual.
            formularioObjetivo.FormClosed += (s, args) => formularioActual.Close();

            formularioActual.Hide();      // Ocultar (no destruir) el formulario actual
            formularioObjetivo.Show();    // Mostrar el formulario destino
        }
    }
}