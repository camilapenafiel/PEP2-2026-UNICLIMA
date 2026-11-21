namespace PROYECTO_PR_BD_PE
{
    partial class Form6GestionEstaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6GestionEstaciones));
            dgvEstaciones = new DataGridView();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            cmbUbicacion = new ComboBox();
            cmbEstado = new ComboBox();
            txtModelo = new TextBox();
            txtNombreEstacion = new TextBox();
            btnAtrasGE = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEstaciones).BeginInit();
            SuspendLayout();
            // 
            // dgvEstaciones
            // 
            dgvEstaciones.BackgroundColor = Color.FromArgb(200, 209, 217);
            dgvEstaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstaciones.Location = new Point(66, 426);
            dgvEstaciones.Name = "dgvEstaciones";
            dgvEstaciones.RowHeadersWidth = 51;
            dgvEstaciones.Size = new Size(1061, 298);
            dgvEstaciones.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Black;
            btnLimpiar.FlatStyle = FlatStyle.Popup;
            btnLimpiar.Font = new Font("Arial Rounded MT Bold", 9F);
            btnLimpiar.ForeColor = SystemColors.ButtonHighlight;
            btnLimpiar.Location = new Point(621, 318);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(209, 29);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 9F);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(311, 318);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(215, 29);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.BackColor = Color.FromArgb(200, 209, 217);
            cmbUbicacion.FlatStyle = FlatStyle.Popup;
            cmbUbicacion.Font = new Font("Arial", 9F);
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Items.AddRange(new object[] { "Campus \"Central\"", "Campus \"Cala Cala\"" });
            cmbUbicacion.Location = new Point(912, 171);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(185, 25);
            cmbUbicacion.TabIndex = 9;
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = Color.FromArgb(200, 209, 217);
            cmbEstado.FlatStyle = FlatStyle.Popup;
            cmbEstado.Font = new Font("Arial", 9F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "ACTIVO ", "INACTIVO" });
            cmbEstado.Location = new Point(785, 254);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(306, 25);
            cmbEstado.TabIndex = 8;
            // 
            // txtModelo
            // 
            txtModelo.BackColor = Color.FromArgb(200, 209, 217);
            txtModelo.BorderStyle = BorderStyle.None;
            txtModelo.Font = new Font("Arial", 9F);
            txtModelo.Location = new Point(353, 260);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(246, 18);
            txtModelo.TabIndex = 6;
            // 
            // txtNombreEstacion
            // 
            txtNombreEstacion.BackColor = Color.FromArgb(200, 209, 217);
            txtNombreEstacion.BorderStyle = BorderStyle.None;
            txtNombreEstacion.Font = new Font("Arial", 9F);
            txtNombreEstacion.Location = new Point(353, 175);
            txtNombreEstacion.Name = "txtNombreEstacion";
            txtNombreEstacion.Size = new Size(246, 18);
            txtNombreEstacion.TabIndex = 4;
            // 
            // btnAtrasGE
            // 
            btnAtrasGE.BackColor = Color.Red;
            btnAtrasGE.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtrasGE.ForeColor = Color.White;
            btnAtrasGE.Location = new Point(1150, -2);
            btnAtrasGE.Name = "btnAtrasGE";
            btnAtrasGE.Size = new Size(52, 33);
            btnAtrasGE.TabIndex = 11;
            btnAtrasGE.Text = "X";
            btnAtrasGE.UseVisualStyleBackColor = false;
            btnAtrasGE.Click += btnAtrasGE_Click;
            // 
            // Form6GestionEstaciones
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(18, 59, 99);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(dgvEstaciones);
            Controls.Add(btnAtrasGE);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombreEstacion);
            Controls.Add(cmbEstado);
            Controls.Add(cmbUbicacion);
            Controls.Add(txtModelo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form6GestionEstaciones";
            Text = "Form6GestionEstaciones";
            Load += Form6GestionEstaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEstaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtModelo;
        private TextBox txtNombreEstacion;
        private ComboBox cmbUbicacion;
        private ComboBox cmbEstado;
        private Button btnLimpiar;
        private Button btnGuardar;
        private DataGridView dgvEstaciones;
        private Button btnAtrasGE;
    }
}