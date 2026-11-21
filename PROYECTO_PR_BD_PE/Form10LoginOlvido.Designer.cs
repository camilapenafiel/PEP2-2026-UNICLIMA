namespace PROYECTO_PR_BD_PE
{
    partial class Form10LoginOlvido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10LoginOlvido));
            lblPreguntaOlvido = new Label();
            txtRespuestaOlvido = new TextBox();
            txtNuevaContrasena2 = new TextBox();
            txtNuevaContrasena = new TextBox();
            btnCancelarOlvido = new Button();
            btnConfirmarOlvido = new Button();
            dtpFechaOlvido = new DateTimePicker();
            txtCorreoOlvido = new TextBox();
            SuspendLayout();
            // 
            // lblPreguntaOlvido
            // 
            lblPreguntaOlvido.AutoSize = true;
            lblPreguntaOlvido.BackColor = Color.White;
            lblPreguntaOlvido.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreguntaOlvido.Location = new Point(432, 488);
            lblPreguntaOlvido.Name = "lblPreguntaOlvido";
            lblPreguntaOlvido.Size = new Size(318, 20);
            lblPreguntaOlvido.TabIndex = 16;
            lblPreguntaOlvido.Text = "-------PREGUNTA DE SEGURIDAD------";
            // 
            // txtRespuestaOlvido
            // 
            txtRespuestaOlvido.BackColor = Color.White;
            txtRespuestaOlvido.BorderStyle = BorderStyle.None;
            txtRespuestaOlvido.Location = new Point(342, 603);
            txtRespuestaOlvido.Name = "txtRespuestaOlvido";
            txtRespuestaOlvido.Size = new Size(519, 20);
            txtRespuestaOlvido.TabIndex = 19;
            // 
            // txtNuevaContrasena2
            // 
            txtNuevaContrasena2.BackColor = Color.White;
            txtNuevaContrasena2.BorderStyle = BorderStyle.None;
            txtNuevaContrasena2.Font = new Font("Arial", 9F);
            txtNuevaContrasena2.Location = new Point(929, 272);
            txtNuevaContrasena2.Name = "txtNuevaContrasena2";
            txtNuevaContrasena2.Size = new Size(219, 18);
            txtNuevaContrasena2.TabIndex = 26;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BackColor = Color.White;
            txtNuevaContrasena.BorderStyle = BorderStyle.None;
            txtNuevaContrasena.Font = new Font("Arial", 9F);
            txtNuevaContrasena.Location = new Point(882, 219);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.Size = new Size(261, 18);
            txtNuevaContrasena.TabIndex = 24;
            // 
            // btnCancelarOlvido
            // 
            btnCancelarOlvido.BackColor = Color.Transparent;
            btnCancelarOlvido.FlatStyle = FlatStyle.Popup;
            btnCancelarOlvido.Font = new Font("Arial Rounded MT Bold", 12F);
            btnCancelarOlvido.ForeColor = Color.White;
            btnCancelarOlvido.Location = new Point(659, 690);
            btnCancelarOlvido.Name = "btnCancelarOlvido";
            btnCancelarOlvido.Size = new Size(307, 37);
            btnCancelarOlvido.TabIndex = 22;
            btnCancelarOlvido.Text = "CANCELAR";
            btnCancelarOlvido.UseVisualStyleBackColor = false;
            btnCancelarOlvido.Click += btnCancelarOlvido_Click;
            // 
            // btnConfirmarOlvido
            // 
            btnConfirmarOlvido.BackColor = Color.Transparent;
            btnConfirmarOlvido.FlatStyle = FlatStyle.Popup;
            btnConfirmarOlvido.Font = new Font("Arial Rounded MT Bold", 12F);
            btnConfirmarOlvido.ForeColor = Color.White;
            btnConfirmarOlvido.Location = new Point(226, 691);
            btnConfirmarOlvido.Name = "btnConfirmarOlvido";
            btnConfirmarOlvido.Size = new Size(313, 36);
            btnConfirmarOlvido.TabIndex = 21;
            btnConfirmarOlvido.Text = "CONFIRMAR ";
            btnConfirmarOlvido.UseVisualStyleBackColor = false;
            btnConfirmarOlvido.Click += btnConfirmarOlvido_Click;
            // 
            // dtpFechaOlvido
            // 
            dtpFechaOlvido.CalendarFont = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaOlvido.CalendarMonthBackground = Color.White;
            dtpFechaOlvido.Location = new Point(327, 273);
            dtpFechaOlvido.Name = "dtpFechaOlvido";
            dtpFechaOlvido.Size = new Size(214, 27);
            dtpFechaOlvido.TabIndex = 18;
            // 
            // txtCorreoOlvido
            // 
            txtCorreoOlvido.BackColor = Color.White;
            txtCorreoOlvido.BorderStyle = BorderStyle.None;
            txtCorreoOlvido.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreoOlvido.Location = new Point(170, 217);
            txtCorreoOlvido.Name = "txtCorreoOlvido";
            txtCorreoOlvido.Size = new Size(371, 18);
            txtCorreoOlvido.TabIndex = 13;
            txtCorreoOlvido.Leave += txtCorreoOlvido_Leave;
            // 
            // Form10LoginOlvido
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(txtNuevaContrasena2);
            Controls.Add(lblPreguntaOlvido);
            Controls.Add(txtNuevaContrasena);
            Controls.Add(btnConfirmarOlvido);
            Controls.Add(txtRespuestaOlvido);
            Controls.Add(dtpFechaOlvido);
            Controls.Add(btnCancelarOlvido);
            Controls.Add(txtCorreoOlvido);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form10LoginOlvido";
            Text = "Form10LoginOlvido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPreguntaOlvido;
        private TextBox txtCorreoOlvido;
        private DateTimePicker dtpFechaOlvido;
        private Button btnCancelarOlvido;
        private Button btnConfirmarOlvido;
        private TextBox txtRespuestaOlvido;
        private TextBox txtNuevaContrasena2;
        private TextBox txtNuevaContrasena;
    }
}