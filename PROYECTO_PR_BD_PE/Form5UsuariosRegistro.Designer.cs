namespace PROYECTO_PR_BD_PE
{
    partial class Form5UsuariosRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5UsuariosRegistro));
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtContrasena = new TextBox();
            btnRegistrarme = new Button();
            btnVolver = new Button();
            cmbPreguntaSeguridad = new ComboBox();
            txtNickname = new TextBox();
            txtRespuestaSeguridad = new TextBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(26, 54, 93);
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.ForeColor = Color.White;
            txtNombre.Location = new Point(695, 167);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(198, 20);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(26, 54, 93);
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.ForeColor = Color.White;
            txtApellido.Location = new Point(959, 168);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(221, 20);
            txtApellido.TabIndex = 4;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CalendarMonthBackground = Color.FromArgb(26, 54, 93);
            dtpFechaNacimiento.Location = new Point(961, 247);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(218, 27);
            dtpFechaNacimiento.TabIndex = 12;
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.FromArgb(26, 54, 93);
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.ForeColor = Color.White;
            txtCorreo.Location = new Point(695, 335);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(481, 20);
            txtCorreo.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(26, 54, 93);
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.ForeColor = Color.White;
            txtTelefono.Location = new Point(958, 415);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(217, 20);
            txtTelefono.TabIndex = 15;
            // 
            // txtContrasena
            // 
            txtContrasena.BackColor = Color.FromArgb(26, 54, 93);
            txtContrasena.BorderStyle = BorderStyle.None;
            txtContrasena.ForeColor = Color.White;
            txtContrasena.Location = new Point(697, 416);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(196, 20);
            txtContrasena.TabIndex = 16;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // btnRegistrarme
            // 
            btnRegistrarme.BackColor = Color.FromArgb(255, 128, 0);
            btnRegistrarme.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnRegistrarme.ForeColor = Color.White;
            btnRegistrarme.Location = new Point(685, 672);
            btnRegistrarme.Name = "btnRegistrarme";
            btnRegistrarme.Size = new Size(224, 29);
            btnRegistrarme.TabIndex = 17;
            btnRegistrarme.Text = "REGISTRARME";
            btnRegistrarme.UseVisualStyleBackColor = false;
            btnRegistrarme.Click += btnRegistrarme_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(255, 128, 0);
            btnVolver.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(926, 671);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(253, 31);
            btnVolver.TabIndex = 18;
            btnVolver.Text = "ATRAS";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // cmbPreguntaSeguridad
            // 
            cmbPreguntaSeguridad.BackColor = Color.FromArgb(26, 54, 93);
            cmbPreguntaSeguridad.ForeColor = Color.White;
            cmbPreguntaSeguridad.FormattingEnabled = true;
            cmbPreguntaSeguridad.Items.AddRange(new object[] { "Nombre de tu mascota favorita?", "Cantante/Banda preferida?", "Nombre de tu primer mejor amigo/a?", "Videojuego Favorito?", "Pais que sueñas visitar?", "" });
            cmbPreguntaSeguridad.Location = new Point(694, 498);
            cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            cmbPreguntaSeguridad.Size = new Size(299, 28);
            cmbPreguntaSeguridad.TabIndex = 22;
            // 
            // txtNickname
            // 
            txtNickname.BackColor = Color.FromArgb(26, 54, 93);
            txtNickname.BorderStyle = BorderStyle.None;
            txtNickname.ForeColor = Color.White;
            txtNickname.Location = new Point(695, 251);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(198, 20);
            txtNickname.TabIndex = 24;
            // 
            // txtRespuestaSeguridad
            // 
            txtRespuestaSeguridad.BackColor = Color.FromArgb(26, 54, 93);
            txtRespuestaSeguridad.BorderStyle = BorderStyle.None;
            txtRespuestaSeguridad.ForeColor = Color.White;
            txtRespuestaSeguridad.Location = new Point(694, 580);
            txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            txtRespuestaSeguridad.Size = new Size(299, 20);
            txtRespuestaSeguridad.TabIndex = 26;
            // 
            // Form5UsuariosRegistro
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(txtRespuestaSeguridad);
            Controls.Add(txtNickname);
            Controls.Add(cmbPreguntaSeguridad);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarme);
            Controls.Add(txtContrasena);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form5UsuariosRegistro";
            Text = "Form5Usuarios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtApellido;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtContrasena;
        private Button btnRegistrarme;
        private Button btnVolver;
        private ComboBox cmbPreguntaSeguridad;
        private TextBox txtNickname;
        private TextBox txtRespuestaSeguridad;
    }
}