///ClassBD.cs es el unico punto donde se conecta todo el sistema con SQL Server
///Todos los formularios y clases usan estos metodos a traves de ClassSP_Methods
///Y nunca escriben SQL directamente

using System;
using System.Configuration;   // Para leer el archivo de configuración (App.config)
using System.Data;  
using System.Data.SqlClient;   // Para conectarse a SQL Server
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Usuario.Clases
{
    public class ClassBD
    {
        // "readonly" significa que solo puede asignarse en el constructor, nunca después.
        private readonly string conexionString;

        // -- Constructor
        // Se ejecuta una sola vez cuando se hace "new ClassBD()".
        // Lee la cadena de conexión del archivo de configuración del proyecto.
        public ClassBD()
        {
            // ConfigurationManager busca la sección <connectionStrings> en App.config
            // y devuelve la entrada llamada "DefaultConnection".
            conexionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            // El operador "?" (null-condicional) evita un crash si la clave no existe.
            // En este caso conexionString queda en null y el if de abajo lo detecta.
            if (string.IsNullOrEmpty(conexionString))
            {
                throw new InvalidOperationException("La cadena de conexión no está configurada en App.config");
            }
        }

        // -- Método de prueba de conexión
        // Útil para verificar al iniciar la app que la base de datos es alcanzable.
        // Retorna true si la conexión se abre correctamente, false si falla.
        public bool ProbarConexion()
        {
            try
            {
                // "using" garantiza que la conexión se cierre y libere aunque ocurra un error.
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  MÉTODOS PARA STORED PROCEDURES
        // ══════════════════════════════════════════════════════════════════════

        // -- UsarSP_SinParametros
        // Ejecuta un stored procedure que no recibe parámetros y devuelve filas.
        // Ejemplo de uso: SP_CargaRoles, SP_CargaPreguntasSeguridad.
        // Retorna: DataTable - tabla en memoria con todas las filas del resultado.
        // Si falla, retorna una tabla vacía (no null).
        public DataTable UsarSP_SinParametros(string nombreSP)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand command = new SqlCommand(nombreSP, conexion))
                    {
                        // Le indica a SqlCommand que el texto es un SP, no un SELECT directo.
                        command.CommandType = CommandType.StoredProcedure;

                        // SqlDataAdapter conecta el SP con la DataTable,
                        // luego abre la conexión, ejecuta el SP y vuelca el resultado en dataTable.
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el stored procedure: {ex.Message}");
            }

            return dataTable;
        }

        // -- UsarSP_ConParametros
        // Igual que el anterior pero acepta un arreglo de SqlParameter[].
        // Los parámetros son los "@Nombre", "@ID_Usuario", etc. que define el SP.
        public DataTable UsarSP_ConParametros(string nombreSP, SqlParameter[] parametros)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand command = new SqlCommand(nombreSP, conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            // AddRange agrega todos los parámetros de golpe al comando.
                            command.Parameters.AddRange(parametros);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el stored procedure: {ex.Message}");
            }

            return dataTable;
        }

        // ══════════════════════════════════════════════════════════════════════
        //  MÉTODOS PARA SQL DIRECTO (queries sin stored procedure)
        // ══════════════════════════════════════════════════════════════════════

        // -- EjecutarSP_ConRetorno 
        // Para SPs que usan la instrucción "RETURN <número>" en vez de SELECT.
        // En SQL Server, RETURN transmite un int especial que no aparece en el
        // resultado normal. Hay que capturarlo con un parámetro de dirección
        // ParameterDirection.ReturnValue.
        public int EjecutarSP_ConRetorno(string nombreSP, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand command = new SqlCommand(nombreSP, conexion))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                            command.Parameters.AddRange(parametros);

                        // Parámetro especial que captura el valor del RETURN del SP.
                        SqlParameter returnParam = new SqlParameter("@ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParam);

                        conexion.Open();
                        command.ExecuteNonQuery();

                        // El valor del RETURN queda en returnParam.Value después de ejecutar.
                        return (int)returnParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el stored procedure: {ex.Message}");
                return -1; // -1 indica error
            }
        }
    }
}