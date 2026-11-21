namespace PROYECTO_PR_BD_PE
{
    partial class Form8UsuarioLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8UsuarioLogin));
            lnkOlvidaste = new LinkLabel();
            lnkRegistrarse = new LinkLabel();
            btsSalirLogin = new Button();
            btnIngresarLogin = new Button();
            txtContrasenaLogin = new TextBox();
            txtCorreoLogin = new TextBox();
            SuspendLayout();
            // 
            // lnkOlvidaste
            // 
            lnkOlvidaste.AutoSize = true;
            lnkOlvidaste.BackColor = Color.Transparent;
            lnkOlvidaste.LinkColor = Color.White;
            lnkOlvidaste.Location = new Point(630, 586);
            lnkOlvidaste.Name = "lnkOlvidaste";
            lnkOlvidaste.Size = new Size(173, 20);
            lnkOlvidaste.TabIndex = 8;
            lnkOlvidaste.TabStop = true;
            lnkOlvidaste.Text = "Olvideste tu Contraseña?";
            lnkOlvidaste.LinkClicked += lnkOlvidaste_LinkClicked;
            // 
            // lnkRegistrarse
            // 
            lnkRegistrarse.AutoSize = true;
            lnkRegistrarse.BackColor = Color.Transparent;
            lnkRegistrarse.LinkColor = Color.White;
            lnkRegistrarse.Location = new Point(414, 586);
            lnkRegistrarse.Name = "lnkRegistrarse";
            lnkRegistrarse.Size = new Size(145, 20);
            lnkRegistrarse.TabIndex = 7;
            lnkRegistrarse.TabStop = true;
            lnkRegistrarse.Text = "Crear Nuevo Usuario";
            lnkRegistrarse.LinkClicked += lnkRegistrarse_LinkClicked;
            // 
            // btsSalirLogin
            // 
            btsSalirLogin.BackColor = Color.Red;
            btsSalirLogin.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Bold);
            btsSalirLogin.ForeColor = Color.White;
            btsSalirLogin.Location = new Point(1149, -1);
            btsSalirLogin.Name = "btsSalirLogin";
            btsSalirLogin.Size = new Size(52, 33);
            btsSalirLogin.TabIndex = 6;
            btsSalirLogin.Text = "X";
            btsSalirLogin.UseVisualStyleBackColor = false;
            btsSalirLogin.Click += btsSalirLogin_Click;
            // 
            // btnIngresarLogin
            // 
            btnIngresarLogin.BackColor = Color.FromArgb(255, 128, 0);
            btnIngresarLogin.FlatStyle = FlatStyle.Popup;
            btnIngresarLogin.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresarLogin.ForeColor = Color.White;
            btnIngresarLogin.Location = new Point(414, 513);
            btnIngresarLogin.Name = "btnIngresarLogin";
            btnIngresarLogin.Size = new Size(389, 29);
            btnIngresarLogin.TabIndex = 5;
            btnIngresarLogin.Text = "INGRESAR";
            btnIngresarLogin.UseVisualStyleBackColor = false;
            btnIngresarLogin.Click += btnIngresarLogin_Click;
            // 
            // txtContrasenaLogin
            // 
            txtContrasenaLogin.BackColor = Color.White;
            txtContrasenaLogin.BorderStyle = BorderStyle.None;
            txtContrasenaLogin.Font = new Font("Arial", 9F);
            txtContrasenaLogin.Location = new Point(574, 415);
            txtContrasenaLogin.Name = "txtContrasenaLogin";
            txtContrasenaLogin.PasswordChar = '*';
            txtContrasenaLogin.Size = new Size(270, 18);
            txtContrasenaLogin.TabIndex = 4;
            txtContrasenaLogin.TextChanged += txtContrasenaLogin_TextChanged;
            // 
            // txtCorreoLogin
            // 
            txtCorreoLogin.BackColor = Color.White;
            txtCorreoLogin.BorderStyle = BorderStyle.None;
            txtCorreoLogin.Font = new Font("Arial", 9F);
            txtCorreoLogin.Location = new Point(504, 354);
            txtCorreoLogin.Name = "txtCorreoLogin";
            txtCorreoLogin.Size = new Size(341, 18);
            txtCorreoLogin.TabIndex = 3;
            // 
            // Form8UsuarioLogin
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(8, 124, 193);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(lnkOlvidaste);
            Controls.Add(lnkRegistrarse);
            Controls.Add(btsSalirLogin);
            Controls.Add(btnIngresarLogin);
            Controls.Add(txtCorreoLogin);
            Controls.Add(txtContrasenaLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form8UsuarioLogin";
            Text = "Form8UsuarioLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btsSalirLogin;
        private Button btnIngresarLogin;
        private TextBox txtContrasenaLogin;
        private TextBox txtCorreoLogin;
        private LinkLabel lnkRegistrarse;
        private LinkLabel lnkOlvidaste;
    }
}