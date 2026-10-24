using Microsoft.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class claseSP
    {
        public claseConexionBD DB = new claseConexionBD();

        // ══════════════════════════════════════════════════════════════════════
        //  SPs SIN PARÁMETROS — Solo ejecutan y devuelven todos sus datos
        // ══════════════════════════════════════════════════════════════════════

        // Devuelve todos los roles
        public DataTable SP_CargaRoles()
        {
            return DB.UsarSP_SinParametros("SP_CargaRoles");
        }

        // Devuelve todas las preguntas de seguridad.
        // Incluye tanto activas (Habilitada=1) como desactivadas (Habilitada=0).
        // Los formularios filtran por Habilitada según lo que necesiten.
        public DataTable SP_CargaPreguntasSeguridad()
        {
            return DB.UsarSP_SinParametros("SP_CargaPreguntasSeguridad");
        }

        // Devuelve todas las configuraciones del sistema.
        public DataTable SP_CargarConfiguraciones()
        {
            return DB.UsarSP_SinParametros("SP_CargarConfiguraciones");
        }

        // Devuelve todos los usuarios registrados.
        public DataTable SP_CargaUsuarios()
        {
            return DB.UsarSP_SinParametros("SP_CargaUsuarios");
        }

        // Devuelve los datos esenciales del usuario (usado en DGVs)
        public DataTable SP_CargaUsuariosDetalle()
        {
            return DB.UsarSP_SinParametros("SP_CargaUsuariosDetalle");
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SPs CON PARÁMETROS — Consultas y validaciones
        // ══════════════════════════════════════════════════════════════════════

        // SP_LoginUsuario - valida usuario + contraseña hasheada.
        // Retorna una fila con los datos del usuario si las credenciales son correctas, o ninguna fila si son incorrectas.
        public DataTable SP_LoginUsuario(string nombre, string contrasena)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@contrasena", contrasena)
            };
            return DB.UsarSP_ConParametros("SP_LoginUsuario", parametros);
        }

        // SP_ObtenerPreguntasSeguridad - obtiene las preguntas de seguridad que respondió un usuario específico (solo las activas/habilitadas).
        public DataTable SP_ObtenerPreguntasSeguridad(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerPreguntasSeguridad", parametros);
        }
        //SP_ObtenerPermisosUsuariosCompleto - Obtiene los permisos y usuarios
        public DataTable SP_ObtenerPermisosUsuariosCompleto(int? idUsuario = null)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", (object)idUsuario ?? DBNull.Value)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerPermisosUsuariosCompleto", parametros);
        }
        // SP_VerificarRespuestasSeguridad - comprueba si una respuesta ingresada coincide con alguna respuesta del usuario en la BD.
        // Devuelve 1 fila si es correcta, 0 filas si no lo es.
        // Este SP no verifica una pregunta específica, sino que busca la respuesta entre todas las del usuario. Los formularios iteran de a una por vez.
        public DataTable SP_VerificarRespuestasSeguridad(int idUsuario, string respuesta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", idUsuario),
                new SqlParameter("@Respuesta", respuesta)
            };
            return DB.UsarSP_ConParametros("SP_VerificarRespuestasSeguridad", parametros);
        }

        // SP_VerificarMail - verifica si un correo está registrado en el sistema.
        // Usa RETURN en el SP (no SELECT), por eso se usa EjecutarSP_ConRetorno.
        // Retorna: 1 = el correo existe, 0 = no existe.
        public int SP_VerificarMail(string correo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Correo", correo)
            };
            return DB.EjecutarSP_ConRetorno("SP_VerificarMail", parametros);
        }

        // SP_LoginsTotal - cuenta cuántas contraseñas tiene un usuario identificándolo por nombre + contraseña (forma alternativa al ID).
        // Devuelve una fila con un COUNT(*).
        public DataTable SP_LoginsTotal(string usuario, string pass)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@pass", pass)
            };
            return DB.UsarSP_ConParametros("SP_LoginsTotal", parametros);
        }

        // SP_ObtenerCantidadContrasenas - igual que SP_LoginsTotal pero usando el ID.
        // Columna del resultado: CantidadContrasenas.
        // Se usa en el login para detectar si es el primer ingreso.
        public DataTable SP_ObtenerCantidadContrasenas(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerCantidadContrasenas", parametros);
        }

        // SP_EsAdministrador - verifica si el usuario tiene el rol "Administrador".
        // Devuelve 1 fila (o más) si es admin, 0 filas si no lo es.
        // El formulario de login lo usa para setear ClassData.esAdmin.
        public DataTable SP_EsAdministrador(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_EsAdministrador", parametros);
        }

        // SP_ObtenerUsuarioPorCorreo - dado un correo, devuelve los datos del usuario.
        // Se usa en FormRecuperar para obtener el ID y el nombre del usuario antes de mostrar las preguntas de seguridad.
        public DataTable SP_ObtenerUsuarioPorCorreo(string correo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Correo", correo)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerUsuarioPorCorreo", parametros);
        }

        // Obtiene el correo utilizando el nombre de un usuario
        public DataTable SP_ObtenerCorreoPorUsuario(string user)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@user", user)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerCorreoPorUsuario", parametros);
        }

        // SP_CargaDatosUsuario - obtiene datos de un usuario específico vía ID_Usuario
        public DataTable SP_CargaDatosUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_CargaDatosUsuario", parametros);
        }
        //SP_ObtenerPermisosFaltantesUsuario - Obtiene los permisos que no tiene un usuario
        public DataTable SP_ObtenerPermisosFaltantesUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerPermisosFaltantesUsuario", parametros);
        }
        //SP_ObtenerRolesDeUsuario - Obtiene los roles que tiene vinculado un usuario
        public DataTable SP_ObtenerRolesDeUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerRolesDeUsuario", parametros);
        }

        //SP_ObtenerFamiliasDeUsuario - Obtiene las familias que tiene vinculado un usuario

        public DataTable SP_ObtenerFamiliasDeUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerFamiliasDeUsuario", parametros);
        }

        //SP_ObtenerPermisosDeUsuario - Obtiene los permisos que tiene vinculado un usuario

        public DataTable SP_ObtenerPermisosDeUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("ID_Usuario", idUsuario)
            };
            return DB.UsarSP_ConParametros("SP_ObtenerPermisosDeUsuario", parametros);
        }
        // Datos del usuario. Columnas: ID_Usuario, NombreUsuario, Nombre, Apellido, Correo, UltimaPass
        public DataTable SP_ObtenerDatosUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@ID_Usuario", idUsuario) 
            };
            return DB.UsarSP_ConParametros("SP_ObtenerDatosUsuario", parametros);
        }

        // ══════════════════════════════════════════════════════════════════════
        //  SPs CON PARÁMETROS — Inserts y actualizaciones
        // ══════════════════════════════════════════════════════════════════════

        // Agrega una nueva pregunta de seguridad al sistema.
        // Por defecto queda deshabilitada (Habilitada = 0); el admin debe activarla.
        public void SP_AgregarPreguntaSeguridad(string pregunta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Pregunta", pregunta)
            };
            DB.UsarSP_ConParametros("SP_AgregarPreguntaSeguridad", parametros);
        }

        // Crea una nueva familia de permisos/roles.
        // Devuelve el ID_Familia generado.
        public DataTable SP_InsertarFamilia(string nombreFamilia)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreFamilia", nombreFamilia)
            };
            return DB.UsarSP_ConParametros("SP_InsertarFamilia", parametros);
        }

        // Crea un nuevo rol. El parámetro descripcion es opcional (puede ser null).

        // "(object)descripcion ?? DBNull.Value" convierte null de C# a NULL de SQL.
        // Si no se hace esta conversión, SqlParameter lanza una excepción.
        public DataTable SP_InsertarRol(string nombreRol, string descripcion = "")
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreRol", nombreRol),
                new SqlParameter("@Descripcion", (object)descripcion ?? DBNull.Value)
            };
            return DB.UsarSP_ConParametros("SP_InsertarRol", parametros);
        }

        // Inserta una nueva configuración. No verifica duplicados.
        public void SP_InsertarConfiguracion(string accion, string valor)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Accion", accion),
                new SqlParameter("@Valor", valor)
            };
            DB.UsarSP_ConParametros("SP_InsertarConfiguracion", parametros);
        }

        // Crea un nuevo permiso. Descripcion es opcional.
        public void SP_InsertarPermiso(string permiso, string descripcion = "")
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Permiso", permiso),
                new SqlParameter("@Descripcion", (object)descripcion ?? DBNull.Value)

              //EXPERIMENTAR CON ESTO LUEGO
              /*new ("@Permiso", permiso),
                new ("@Descripcion", (object)descripcion ?? DBNull.Value)*/
            };

            DB.UsarSP_ConParametros("SP_InsertarPermiso", parametros);
        }

        // Registra un usuario completo en una sola llamada:
        // inserta en Personas, Usuarios, Contrasenas e Historico_Contrasenas.
        // La contraseña ya viene encriptada desde el formulario que llama a este método.
        public void SP_InsertarUsuarioCompleto(string nombre, string apellido, string correo, string nombreUsuario, string contrasena)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@Correo", correo),
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@contrasena", contrasena)
            };
            DB.UsarSP_ConParametros("SP_InsertarUsuarioCompleto", parametros);
        }

        // Guarda una contraseña nueva (ya hasheada).
        // validarHistorial = false -> permite repetir contraseñas anteriores (config NoRepetirPass = 0)
        public void SP_GuardarContrasena(string contrasena, int idUsuario, bool validarHistorial = true)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@contrasena", contrasena),
                new SqlParameter("@ID_Usuario", idUsuario),
                new SqlParameter("@ValidarHistorial", validarHistorial)
            };
            DB.UsarSP_ConParametros("SP_GuardarContrasena", parametros);
        }

        // Guarda la respuesta de una pregunta de seguridad para un usuario.
        // Se llama en el primer login por cada pregunta que el usuario responde.
        public void SP_InsertarRespuestaSeguridad(int idPregunta, string respuesta, int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Pregunta", idPregunta),
                new SqlParameter("@Respuesta", respuesta),
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            DB.UsarSP_ConParametros("SP_InsertarRespuestaSeguridad", parametros);
        }

        // Guarda o actualiza una configuración del sistema.
        // Si la Accion ya existe la actualiza; si no, la crea.
        public void SP_GuardarConfiguracion(string accion, string valor)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Accion", accion),
                new SqlParameter("@Valor", valor)
            };
            DB.UsarSP_ConParametros("SP_GuardarConfiguracion", parametros);
        }

        // Asocia una familia con un rol.
        public void SP_InsertarFamiliaRol(int idFamilia, int idRol)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Familia", idFamilia),
                new SqlParameter("@ID_Rol", idRol)
            };
            DB.UsarSP_ConParametros("SP_InsertarFamiliaRol", parametros);
        }

        // Asigna un rol a un usuario por nombre (no por ID).
        // El SP busca internamente los IDs correspondientes.
        // Ignora la operación si el usuario ya tiene ese rol.
        public void SP_AgregarRolUsuario(string Rol, string Usuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Rol", Rol),
                new SqlParameter("@User", Usuario)
            };
            DB.UsarSP_ConParametros("SP_AgregarRolUsuario", parametros);
        }

        // Modifica el nombre de una familia existente.
        public void SP_ModificarFamilia(int idFamilia, string nuevoNombre)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Familia", idFamilia),
                new SqlParameter("@NuevoNombre", nuevoNombre)
            };
            DB.UsarSP_ConParametros("SP_ModificarFamilia", parametros);
        }

        // Modifica el nombre de un rol existente.
        public void SP_ModificarRol(int idRol, string nuevoNombre)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Rol", idRol),
                new SqlParameter("@NuevoNombre", nuevoNombre)
            };
            DB.UsarSP_ConParametros("SP_ModificarRol", parametros);
        }

        // Alterna el estado de una pregunta de seguridad: activa a desactivada y viceversa.
        // El SP hace un UPDATE con NOT Habilitada, por lo que no hace falta indicarle el estado nuevo.
        public void SP_ActualizarEstadoPregunta(string pregunta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@pregunta", pregunta)
            };
            DB.UsarSP_ConParametros("SP_ActualizarEstadoPregunta", parametros);
        }

        // Modifica el texto de una pregunta de seguridad existente.
        // Utiliza preguntaActual para identificar la pregunta a modificarse y nuevaPregunta contiene la nueva pregunta
        public void SP_ModificarPreguntaSeguridad(string nuevaPregunta, string preguntaActual)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nuevaPregunta", nuevaPregunta),
                new SqlParameter("@preguntaActual", preguntaActual)
            };
            DB.UsarSP_ConParametros("SP_ModificarPreguntaSeguridad", parametros);
        }

        // Asocia un permiso con un rol. Ignora si ya existe la relación.
        public void SP_AgregarPermisoRol(int idPermiso, int idRol)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Permiso", idPermiso),
                new SqlParameter("@ID_Rol", idRol)
            };
            DB.UsarSP_ConParametros("SP_AgregarPermisoRol", parametros);
        }

        // Asigna un permiso directamente a un usuario. Ignora si ya existe.
        public void SP_AgregarPermisoUsuario(int idPermiso, int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Permiso", idPermiso),
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            DB.UsarSP_ConParametros("SP_AgregarPermisoUsuario", parametros);
        }

        // Asocia un permiso con una familia. Ignora si ya existe.
        public void SP_AgregarPermisoFamilia(int idPermiso, int idFamilia)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Permiso", idPermiso),
                new SqlParameter("@ID_Familia", idFamilia)
            };
            DB.UsarSP_ConParametros("SP_AgregarPermisoFamilia", parametros);
        }

        // Asocia una familia con un usuario. Ignora si ya existe.
        public void SP_AgregarFamiliaUsuario(int idFamilia, int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Familia", idFamilia),
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            DB.UsarSP_ConParametros("SP_AgregarFamiliaUsuario", parametros);
        }

        // Asocia una familia con un permiso. Ignora si ya existe.
        public void SP_AgregarFamiliaPermiso(int idFamilia, int idPermiso)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@ID_Familia", idFamilia),
                new SqlParameter("@ID_Permiso", idPermiso)
            };
            DB.UsarSP_ConParametros("SP_AgregarFamiliaPermiso", parametros);
        }

        // Quita la asignación de un permiso, familia o rol a un usuario.
        public void SP_QuitarAsignacionUsuario(string tipo, int id, int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@ID", id),
                new SqlParameter("@ID_Usuario", idUsuario)
            };
            DB.UsarSP_ConParametros("SP_QuitarAsignacionUsuario", parametros);
        }
    }
}