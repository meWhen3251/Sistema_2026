using Capa_Datos;
using Capa_Sesion;
using System.Data;

namespace Capa_Vista
{
    public partial class formConfiguraciones : Form
    {
        claseSP claseSP = new claseSP();

        // Nombre con el que se guarda cada opción en la base de datos (columna Accion)
        private const string MIN_CARACTERES = "MinCaracteres";
        private const string CANTIDAD_PREGUNTAS = "CantidadPreguntas";
        private const string MAYUS_MINUS = "MayusMinus";
        private const string NUMEROS_LETRAS = "NumerosLetras";
        private const string CARACTER_ESPECIAL = "CaracterEspecial";
        private const string AUTH_2FA = "Auth2FA";
        private const string NO_REPETIR_PASS = "NoRepetirPass";
        private const string NO_DATOS_PERSONALES = "NoDatosPersonales";

        // Límites de los selectores numéricos
        private const int MIN_CARACTERES_DESDE = 4;
        private const int MIN_CARACTERES_HASTA = 32;
        private const int PREGUNTAS_DESDE = 1;

        // Número que aparece al marcar una casilla que estaba desmarcada
        private const int MIN_CARACTERES_SUGERIDO = 8;
        private const int PREGUNTAS_SUGERIDAS = 3;

        // Resumen de lo que está guardado, en forma de texto. Sirve para saber si hay cambios sin guardar.
        private string resumenGuardado = "";
        public formConfiguraciones()
        {
            InitializeComponent();
        }

        private void formConfiguraciones_Load(object sender, EventArgs e)
        {
            // Solo el administrador puede entrar a esta pantalla
            if (!claseVar.esAdmin)
            {
                MessageBox.Show("No tenés permisos para acceder a esta sección.");
                BeginInvoke(new Action(Close));   // se cierra un instante después: un formulario no puede cerrarse dentro de su propio Load
                return;
            }

            CargarConfiguracion();
        }

        // El selector numérico solo se ve si su casilla está marcada
        private void chk_MinContra_CheckedChanged(object sender, EventArgs e)
        {
            nud_CantMinContra.Visible = chk_MinContra.Checked;
        }

        private void chk_CantPreguntas_CheckedChanged(object sender, EventArgs e)
        {
            nud_CantPreguntas.Visible = chk_CantPreguntas.Checked;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Cada línea guarda una opción (si no existía en la tabla, el SP la crea)

                // El primer argumento especifica que configuracion se selecciona primero antes de modificar el valor
                // El segundo argumento hay 2 diferencias:
                // - ValorNumerico (Min_Caracteres y Cant_Preguntas): Si el checkbox esta seleccionado, devuelve el numero seleccionado en el NumericUpDown, sino, devuelve 0
                claseSP.SP_GuardarConfiguracion(MIN_CARACTERES, ValorNumerico(chk_MinContra, nud_CantMinContra));
                claseSP.SP_GuardarConfiguracion(CANTIDAD_PREGUNTAS, ValorNumerico(chk_CantPreguntas, nud_CantPreguntas));
                // - ValorCasilla(El resto de configuraciones sin NUD): simplemente devuelve 1 si esta marcado el checkbox y 0 si no lo esta
                claseSP.SP_GuardarConfiguracion(MAYUS_MINUS, ValorCasilla(chk_MayusMinus));
                claseSP.SP_GuardarConfiguracion(NUMEROS_LETRAS, ValorCasilla(chk_NumCaracteres));
                claseSP.SP_GuardarConfiguracion(CARACTER_ESPECIAL, ValorCasilla(chk_CaracteresEsp));
                claseSP.SP_GuardarConfiguracion(AUTH_2FA, ValorCasilla(chk_2FA));
                claseSP.SP_GuardarConfiguracion(NO_REPETIR_PASS, ValorCasilla(chk_RepetirContra));
                claseSP.SP_GuardarConfiguracion(NO_DATOS_PERSONALES, ValorCasilla(chk_DatosPersonales));

                // Ahora lo que hay en pantalla es lo que está guardado, por lo que se añade al resumen
                resumenGuardado = ObtenerResumen();

                MessageBox.Show("Configuración guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message);
            }
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formConfiguraciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solo importa cuando cierra el usuario (la X) o el botón Volver
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.None)
            {
                return;
            }

            // Hay cambios sin guardar si el resumen de ahora es distinta de la guardada
            // (si el resumen guardado está vacío, es que todavía no se cargó nada)
            bool hayCambios = resumenGuardado != "" && ObtenerResumen() != resumenGuardado;

            if (hayCambios)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay cambios sin guardar. ¿Descartar los cambios?",
                    "Configuración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;   // cancela el cierre: el administrador sigue en esta pantalla
                }
            }

        }
        private void CargarConfiguracion()
        {
            try
            {

                // Paso 1: contar cuántas preguntas de seguridad están activas (es el máximo que se puede pedir)
                DataTable preguntas = claseSP.SP_CargaPreguntasSeguridad();
                int preguntasActivas = 0;

                foreach (DataRow fila in preguntas.Rows)
                {
                    if (Convert.ToInt32(fila["Habilitada"]) == 1)
                    {
                        preguntasActivas++;
                    }
                }

                if (preguntasActivas < 1)
                {
                    preguntasActivas = 1;
                }

                // Paso 2: límites de los selectores numéricos
                nud_CantMinContra.Minimum = MIN_CARACTERES_DESDE;
                nud_CantMinContra.Maximum = MIN_CARACTERES_HASTA;
                nud_CantPreguntas.Minimum = PREGUNTAS_DESDE;
                nud_CantPreguntas.Maximum = preguntasActivas;

                // Paso 3: leer lo que hay guardado en la base de datos
                DataTable config = claseSP.SP_CargarConfiguraciones();

                // Paso 4: mostrarlo en pantalla. Primero las dos opciones que tienen número
                int.TryParse(LeerValor(config, MIN_CARACTERES), out int minCaracteres); //int.TryParse junto a out int minCaracteres
                                                                                        //intenta conseguir un numero entero, si tiene exito, devuelve el numero buscado
                                                                                        //si no tiene exito, devuelve 0
                chk_MinContra.Checked = minCaracteres > 0;

                if (minCaracteres <= 0)
                {
                    minCaracteres = MIN_CARACTERES_SUGERIDO;   // número que se ve al marcar la casilla
                }

                // Math.Clamp deja el número dentro de los límites, evitando errores si el valor guardado quedó fuera
                nud_CantMinContra.Value = Math.Clamp(minCaracteres, MIN_CARACTERES_DESDE, MIN_CARACTERES_HASTA);

                int.TryParse(LeerValor(config, CANTIDAD_PREGUNTAS), out int cantidadPreguntas);
                chk_CantPreguntas.Checked = cantidadPreguntas > 0;

                if (cantidadPreguntas <= 0)
                {
                    cantidadPreguntas = PREGUNTAS_SUGERIDAS;

                }

                nud_CantPreguntas.Value = Math.Clamp(cantidadPreguntas, PREGUNTAS_DESDE, preguntasActivas);

                // Cada selector numérico solo se ve si su casilla está marcada
                nud_CantMinContra.Visible = chk_MinContra.Checked;
                nud_CantPreguntas.Visible = chk_CantPreguntas.Checked;

                // y después las casillas simples (marcada si el valor guardado es "1")
                chk_MayusMinus.Checked = LeerValor(config, MAYUS_MINUS) == "1";
                chk_NumCaracteres.Checked = LeerValor(config, NUMEROS_LETRAS) == "1";
                chk_CaracteresEsp.Checked = LeerValor(config, CARACTER_ESPECIAL) == "1";
                chk_2FA.Checked = LeerValor(config, AUTH_2FA) == "1";
                chk_RepetirContra.Checked = LeerValor(config, NO_REPETIR_PASS) == "1";
                chk_DatosPersonales.Checked = LeerValor(config, NO_DATOS_PERSONALES) == "1";

                // Paso 5: Se guarda en resumen lo que quedó cargado
                resumenGuardado = ObtenerResumen();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración: " + ex.Message);
            }

        }

        // Busca una opción por su nombre en lo leído de la base de datos y devuelve su valor como texto.
        // Si la opción no existe en la tabla, devuelve "0" (desactivada).
        private string LeerValor(DataTable config, string nombre)
        {
            foreach (DataRow fila in config.Rows)
            {
                if (fila["Accion"].ToString().Trim() == nombre)
                {
                    return fila["Valor"].ToString().Trim();
                }
            }
            return "0";
        }

        // Casilla simple: devuelve "1" si está marcada y "0" si no
        private string ValorCasilla(CheckBox casilla)
        {
            if (casilla.Checked)
            {
                return "1";
            }
            return "0";
        }

        // Casilla con número: devuelve el número elegido si está marcada y "0" si no
        private string ValorNumerico(CheckBox casilla, NumericUpDown selector)
        {
            if (casilla.Checked)
            {
                return selector.Value.ToString("0");
            }
            return "0";
        }

        // Arma un texto con el estado de toda la pantalla. Ejemplo: "8|3|1|1|1|0|1|1"
        // Si el texto cambia, es porque el administrador cambió algo.
        private string ObtenerResumen()
        {
            string resumen = "";
            resumen += ValorNumerico(chk_MinContra, nud_CantMinContra) + "|";
            resumen += ValorNumerico(chk_CantPreguntas, nud_CantPreguntas) + "|";
            resumen += ValorCasilla(chk_MayusMinus) + "|";
            resumen += ValorCasilla(chk_NumCaracteres) + "|";
            resumen += ValorCasilla(chk_CaracteresEsp) + "|";
            resumen += ValorCasilla(chk_2FA) + "|";
            resumen += ValorCasilla(chk_RepetirContra) + "|";
            resumen += ValorCasilla(chk_DatosPersonales);
            return resumen;
        }
    }
}
