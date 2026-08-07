///ClassEmails.cs es una clase que almacena los metodos relacionados con el envio o validacion de correos electronicos.
///Utiliza la libreria MailKit y Mimekit para enviar mails a traves de una cuenta de Gmail configurada en codigo.

using MailKit.Net.Smtp; // Cliente SMTP de MailKit
using MailKit.Security; // SecureSocketOptions (TLS/SSL)
using MimeKit; // Clases para construir el mensaje de correo

namespace Sistema_de_Gestion_de_Usuario.Metodos
{
    internal class ClassEmails
    {
        // -- validateEmail
        // Verifica que el string tenga formato de correo válido (ej: usuario@dominio.com).
        // Usa la clase MailAddress de .NET que lanza una excepción si el formato es inválido.

        // Retorna true si es válido, false si no (y muestra un MessageBox de error).
        public bool validateEmail(string email)
        {
            try
            {
                // MailAddress parsea el string; si falla lanza FormatException.
                var addr = new System.Net.Mail.MailAddress(email);

                // Comprobación extra: el Address normalizado debe ser idéntico al ingresado.
                // Esto evita casos como "usuario@dominio.com  " (con espacios).
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Correo electrónico no válido. Por favor, ingresa un correo electrónico válido.");
                return false;
            }
        }

        // -- sendEmailContraseña
        // Envía un email con la contraseña temporal al usuario recién registrado o al usuario que solicitó recuperar su contraseña.

        // "async Task" significa que el método es asíncrono:
        //   - No bloquea la interfaz gráfica mientras espera que el servidor SMTP responda.
        //   - Quien lo llame debe usar "await" para esperar el resultado.

        // Parámetros:
        //   usuario - nombre de usuario (para el saludo en el cuerpo del mail).
        //   email - dirección de destino.
        //   contrasenaTemp - contraseña en texto plano (solo se envía por mail, nunca se guarda así).
        public async Task sendEmailContraseña(string usuario, string email, string contrasenaTemp)
        {
            // MimeMessage es el "sobre" del correo: contiene remitente, destinatario, asunto y cuerpo.
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Sistema de Gestión", "email@dominio.com"));
            emailMessage.To.Add(new MailboxAddress(usuario, email));
            emailMessage.Subject = "Bienvenido - Tu contraseña temporal";

            // TextPart("plain") = cuerpo en texto plano.
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Hola {usuario},\n\n" +
                       $"Tu contraseña temporal es: {contrasenaTemp}\n\n" +
                       $"Por favor, iniciá sesión y cambiá tu contraseña en el primer ingreso.\n\n" +
                       $"Sistema de Gestión de Usuarios"
            };

            // SmtpClient de MailKit maneja la conexión con el servidor de correo.
            using (var client = new SmtpClient())
            {
                // ConnectAsync: conecta al servidor SMTP de Gmail en el puerto 587.
                // SecureSocketOptions.StartTls: inicia la conexión sin cifrado y luego la "sube" a TLS (protocolo de seguridad). Es el estándar en el puerto 587.
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // AuthenticateAsync: inicia sesión con la cuenta de Gmail.
                // La segunda cadena NO es la contraseña de Gmail sino una "App Password" generada en la configuración de seguridad de Google.
                // Google bloquea el login con la contraseña normal desde aplicaciones externas.
                await client.AuthenticateAsync("email@dominio.com", "contraseña_app");

                // SendAsync: envía el mensaje. "await" pausa aquí hasta que el servidor confirme.
                await client.SendAsync(emailMessage);

                // DisconnectAsync(true): cierra la sesión enviando el comando QUIT al servidor.
                await client.DisconnectAsync(true);
            }
        }
    }
}