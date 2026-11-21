using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PROYECTO_PR_BD_PE.CapaNegocio;

namespace PROYECTO_PR_BD_PE
{
    public partial class Form1Principal : Form
    {
        // Declaración de los Timers
        private System.Windows.Forms.Timer? timerActualizacionClima;
        private System.Windows.Forms.Timer? timerReloj;

        public Form1Principal()
        {
            InitializeComponent();
        }

        // NUEVO MÉTODO: Centraliza la lógica de visibilidad de los botones según el rol
        private void ActualizarBotonesSesion()
        {
            bool sesionActiva = !string.IsNullOrWhiteSpace(SesionActual.Rol);



            // Control de visibilidad según el rol
            if (!sesionActiva)
            {
                btnPanelAdmin.Visible = false;
                btnMiPerfil.Visible = false;
            }
            else if (SesionActual.Rol.Trim().Equals(
                "administrador", StringComparison.OrdinalIgnoreCase))
            {
                btnPanelAdmin.Visible = true;
                btnMiPerfil.Visible = false;
            }
            else
            {
                btnPanelAdmin.Visible = false;
                btnMiPerfil.Visible = true;
            }
        }

        // Evento del botón INICIAR SESION
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Si ya hay alguien conectado, da la opción de cerrar sesión
            if (!string.IsNullOrEmpty(SesionActual.Rol))
            {
                DialogResult salir = MessageBox.Show(
                    $"Sesión activa: {SesionActual.Nombre} ({SesionActual.Rol})\n\n¿Deseas cerrar sesión?",
                    "Cerrar Sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (salir == DialogResult.Yes)
                {
                    SesionActual.IdUsuario = 0;
                    SesionActual.Nombre = "";
                    SesionActual.Nickname = "";
                    SesionActual.Rol = "";
                    MessageBox.Show("Sesión finalizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnIniciarSesion.Text = "INICIAR SESION";
                    lblBienvenida.Text = ""; // Limpiamos el saludo
                    ActualizarBotonesSesion();
                }
                return;
            }

            // Si no hay sesión, abrimos el Login de forma modal
            Form8UsuarioLogin login = new Form8UsuarioLogin();
            login.ShowDialog();

            // Al cerrar el Login, revisamos si el usuario entró con éxito
            if (!string.IsNullOrEmpty(SesionActual.Rol))
            {
                btnIniciarSesion.Text = "CERRAR SESION";

                // Actualizamos el texto y forzamos su visualización
                lblBienvenida.Text = $"Hola {SesionActual.Nickname}";
                lblBienvenida.BringToFront();
                lblBienvenida.Visible = true;

                // Actualizamos la visibilidad de los botones de perfil y admin según el rol
                ActualizarBotonesSesion();
            }

            // Al cerrar el Login, evaluamos si entró como Administrador para mostrar su sub-menú automático
            if (SesionActual.Rol.Trim().Equals("administrador", StringComparison.OrdinalIgnoreCase) || SesionActual.Rol.Trim() == "Administrador")
            {
                // Creamos una ventana de menú personalizada mediante código
                Form menuAdmin = new Form();
                menuAdmin.Text = "Panel de Administración";
                menuAdmin.Size = new System.Drawing.Size(350, 220);
                menuAdmin.StartPosition = FormStartPosition.CenterScreen;
                menuAdmin.FormBorderStyle = FormBorderStyle.FixedDialog;
                menuAdmin.MaximizeBox = false;
                menuAdmin.MinimizeBox = false;
                menuAdmin.BackColor = System.Drawing.Color.WhiteSmoke;

                Label lbl = new Label();
                lbl.Text = $"Bienvenido Administrador: {SesionActual.Nombre}\n\nSeleccione el panel que desea abrir:";
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(30, 20);
                lbl.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                menuAdmin.Controls.Add(lbl);

                Button btnEstaciones = new Button();
                btnEstaciones.Text = "Gestión de Estaciones";
                btnEstaciones.Size = new System.Drawing.Size(270, 40);
                btnEstaciones.Location = new System.Drawing.Point(30, 70);
                btnEstaciones.BackColor = System.Drawing.Color.LightSkyBlue;
                btnEstaciones.FlatStyle = FlatStyle.Flat;
                btnEstaciones.Cursor = Cursors.Hand;
                // Evento al hacer clic en Estaciones
                btnEstaciones.Click += (s, args) =>
                {
                    menuAdmin.Hide();
                    new Form6GestionEstaciones().ShowDialog();
                    menuAdmin.Close();
                };
                menuAdmin.Controls.Add(btnEstaciones);

                Button btnUsuarios = new Button();
                btnUsuarios.Text = "Gestión de Usuarios";
                btnUsuarios.Size = new System.Drawing.Size(270, 40);
                btnUsuarios.Location = new System.Drawing.Point(30, 120);
                btnUsuarios.BackColor = System.Drawing.Color.LightSkyBlue;
                btnUsuarios.FlatStyle = FlatStyle.Flat;
                btnUsuarios.Cursor = Cursors.Hand;
                // Evento al hacer clic en Usuarios
                btnUsuarios.Click += (s, args) =>
                {
                    menuAdmin.Hide();
                    new Form7GestionUsuario().ShowDialog();
                    menuAdmin.Close();
                };
                menuAdmin.Controls.Add(btnUsuarios);

                // Mostramos nuestra nueva ventana emergente
                menuAdmin.ShowDialog();
            }
        }

        // OTROS MÉTODOS DE NAVEGACIÓN Y MENÚS ADMIN
        private void button1_Click(object sender, EventArgs e)
        {
            if (!VerificarSesion())
            {
                return;
            }
            AbrirFormulario(new Form2TiempoDiario(this));

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!VerificarSesion())
            {
                return;
            }
            AbrirFormulario(new Form3TiempoHora(this));
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!VerificarSesion())
            {
                return;
            }
            AbrirFormulario(new Form4Metricas(this));
        }
        private void button8_Click(object sender, EventArgs e) { Application.Exit(); }
        private void button2_Click(object sender, EventArgs e) { AbrirFormulario(new Form2TiempoDiario(this)); }
        private void button6_Click(object sender, EventArgs e) { AbrirFormulario(new Form3TiempoHora(this)); }
        private void button5_Click(object sender, EventArgs e) { AbrirFormulario(new Form4Metricas(this)); }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = this.Location;
            frm.Size = this.Size;
            frm.WindowState = this.WindowState;
            frm.Show();
            this.Hide();
        }

        private void linkLluvia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!VerificarSesion())
            {
                return;
            }
            Form3TiempoHora frmHoras = new Form3TiempoHora(this);
            frmHoras.Show();
        }

        private void linkLluvia2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3TiempoHora frmHoras = new Form3TiempoHora(this);
            frmHoras.Show();
        }

        private void btnPanelAdmin_Click(object sender, EventArgs e)
        {
            Form menuAdmin = new Form();
            menuAdmin.Text = "Panel de Administración";
            menuAdmin.Size = new System.Drawing.Size(350, 220);
            menuAdmin.StartPosition = FormStartPosition.CenterScreen;
            menuAdmin.FormBorderStyle = FormBorderStyle.FixedDialog;
            menuAdmin.MaximizeBox = false;
            menuAdmin.MinimizeBox = false;
            menuAdmin.BackColor = System.Drawing.Color.WhiteSmoke;

            Label lbl = new Label();
            lbl.Text = "¿Qué sección deseas gestionar?";
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(30, 20);
            lbl.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            menuAdmin.Controls.Add(lbl);

            Button btnEstaciones = new Button();
            btnEstaciones.Text = "Gestión de Estaciones";
            btnEstaciones.Size = new System.Drawing.Size(270, 40);
            btnEstaciones.Location = new System.Drawing.Point(30, 60);
            btnEstaciones.BackColor = System.Drawing.Color.LightSkyBlue;
            btnEstaciones.FlatStyle = FlatStyle.Flat;
            btnEstaciones.Cursor = Cursors.Hand;
            btnEstaciones.Click += (s, args) =>
            {
                menuAdmin.Close();
                new Form6GestionEstaciones().ShowDialog();
            };
            menuAdmin.Controls.Add(btnEstaciones);

            Button btnUsuarios = new Button();
            btnUsuarios.Text = "Gestión de Usuarios";
            btnUsuarios.Size = new System.Drawing.Size(270, 40);
            btnUsuarios.Location = new System.Drawing.Point(30, 110);
            btnUsuarios.BackColor = System.Drawing.Color.LightSkyBlue;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.Click += (s, args) =>
            {
                menuAdmin.Close();
                new Form7GestionUsuario().ShowDialog();
            };
            menuAdmin.Controls.Add(btnUsuarios);

            menuAdmin.ShowDialog();
        }

        private void Form1Principal_Load(object sender, EventArgs e)
        {
            // Validamos si hay sesión para mostrar el saludo inicial
            if (!string.IsNullOrEmpty(SesionActual.Nombre))
            {
                lblBienvenida.Text = $"Hola {SesionActual.Nickname}";
            }
            else
            {
                lblBienvenida.Text = ""; // O un texto por defecto como "Bienvenido"
            }

            ActualizarBotonesSesion();

            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();

            timerActualizacionClima = new System.Windows.Forms.Timer();
            timerActualizacionClima.Interval = 60000;
            timerActualizacionClima.Tick += TimerActualizacionClima_Tick;
            timerActualizacionClima.Start();

            ActualizarDashboard();
        }

        private void TimerReloj_Tick(object? sender, EventArgs e)
        {
            lblFechaHoraCentral.Text = DateTime.Now.ToString("dd/MM/yyyy   HH:mm");
        }

        private void TimerActualizacionClima_Tick(object? sender, EventArgs e)
        {
            ActualizarDashboard();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ActualizarDashboard()
        {
            try
            {
                CN_Lectura negocio = new CN_Lectura();
                var lecturaCentral = negocio.ObtenerUltimaLectura(1);

                if (lecturaCentral != null && lecturaCentral.Temperatura != 0)
                {
                    lblTempCentral.Text = $"{lecturaCentral.Temperatura}° C";
                    lblHumedadCentral.Text = $"{lecturaCentral.Humedad}%";
                    lblMaxMinCentral.Text = $"{lecturaCentral.TempMax}° C / {lecturaCentral.TempMin}° C";

                    // Calculamos si es de día (entre 6:00 y 18:59)
                    int horaActual = DateTime.Now.Hour;
                    bool esDeDia = (horaActual >= 6 && horaActual < 19);

                    // Evaluamos la humedad para setear la condición climática e imagen
                    if (lecturaCentral.Humedad >= 85)
                    {
                        lblCondicionCentral.Text = "▶ Lluvia";
                        picIconoCentral.Image = Properties.Resources.Lluvia;
                    }
                    else if (lecturaCentral.Humedad >= 70)
                    {
                        lblCondicionCentral.Text = "▶ Nublado";
                        picIconoCentral.Image = Properties.Resources.Nublado;
                    }
                    else if (lecturaCentral.Humedad >= 50)
                    {
                        lblCondicionCentral.Text = "▶ Semi Nublado";
                        picIconoCentral.Image = esDeDia ? Properties.Resources.DiaSemiNublado : Properties.Resources.NocheSemiNublada;
                    }
                    else
                    {
                        lblCondicionCentral.Text = "▶ Despejado";
                        picIconoCentral.Image = esDeDia ? Properties.Resources.DiaDespejado : Properties.Resources.NocheDespejada;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar Dashboard: " + ex.Message);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!VerificarSesion())
            {
                return;
            }

            Form9Reportes nuevoFormulario = new Form9Reportes();

            // 1. Ocultas el menú principal primero
            this.Hide();

            // 2. Abres los reportes
            nuevoFormulario.ShowDialog();

            // 3. Vuelves a mostrar el menú principal al cerrar reportes
            this.Show();
        }
        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Form111Perfil formPerfil = new Form111Perfil();
            formPerfil.ShowDialog();

            // Al cerrar el perfil, verificamos si el usuario eliminó su cuenta (sesión vacía)
            if (string.IsNullOrEmpty(SesionActual.Rol))
            {
                btnIniciarSesion.Text = "INICIAR SESION";
                lblBienvenida.Text = "";
                ActualizarBotonesSesion();
            }
            else
            {
                // Si no la eliminó pero cambió su nickname, actualizamos el saludo
                lblBienvenida.Text = $"Hola {SesionActual.Nickname}";
            }
        }
        private bool VerificarSesion()
        {
            if (string.IsNullOrWhiteSpace(SesionActual.Rol))
            {
                MessageBox.Show(
                    "Para acceder a esta función, primero debes iniciar sesión.",
                    "Inicio de sesión requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return false;
            }

            return true;
        }
    }
}