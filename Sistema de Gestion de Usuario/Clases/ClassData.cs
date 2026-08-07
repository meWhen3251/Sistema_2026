/// ClassData.cs actua como un estado global compartido entre todos los formularios.
/// Al ser statica (static), existe una sola copia en memoria durante toda la ejecucion del sistema.

namespace Sistema_de_Gestion_de_Usuario.Clases
{
    // "internal" = solo accesible dentro de este proyecto (no desde otros assemblies).
    // "static" = no se puede hacer "new ClassData()".
    internal static class ClassData
    {
        // Cantidad de preguntas de seguridad que se mostrarán al usuario en el
        // primer login. Si vale 0, se muestran todas las preguntas activas.
        public static int contadorPreguntas = 0;

        // Nombre de usuario (login) del usuario que inició sesión.
        // Se usa también para construir el hash de la contraseña (contraseña + nombreUsuario).
        public static string nombreUsuario = string.Empty;

        // ID numérico del usuario en la tabla Usuarios de la base de datos.
        // Se carga al hacer login exitoso y lo usan los SPs para identificar al usuario.
        public static int idUsuario = 0;

        // Indica si el usuario logueado tiene el rol "Administrador".
        // De esta manera, se controla si tiene acceso al formAdmin o no.
        public static bool esAdmin = false;
    }
}