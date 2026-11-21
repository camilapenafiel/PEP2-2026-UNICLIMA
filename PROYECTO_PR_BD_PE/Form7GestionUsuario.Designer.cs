namespace PROYECTO_PR_BD_PE
{
    partial class Form7GestionUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7GestionUsuario));
            btnEliminarUsuario = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            cmbRol = new ComboBox();
            txtNombreCompleto = new TextBox();
            txtIdUsuario = new TextBox();
            dgvUsuarios = new DataGridView();
            btnActualizar = new Button();
            btnAtrasGU = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.BackColor = Color.Red;
            btnEliminarUsuario.FlatStyle = FlatStyle.Popup;
            btnEliminarUsuario.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarUsuario.ForeColor = Color.White;
            btnEliminarUsuario.Location = new Point(812, 562);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(224, 29);
            btnEliminarUsuario.TabIndex = 8;
            btnEliminarUsuario.Text = "ELIMINAR USUARIO";
            btnEliminarUsuario.UseVisualStyleBackColor = false;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 128, 0);
            btnLimpiar.FlatStyle = FlatStyle.Popup;
            btnLimpiar.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(943, 514);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(218, 29);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 128, 0);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(692, 514);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(218, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "APLICAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbRol
            // 
            cmbRol.BackColor = Color.Black;
            cmbRol.FlatStyle = FlatStyle.Popup;
            cmbRol.Font = new Font("Arial", 9F);
            cmbRol.ForeColor = Color.White;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(890, 414);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(243, 25);
            cmbRol.TabIndex = 5;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.BackColor = Color.Black;
            txtNombreCompleto.BorderStyle = BorderStyle.None;
            txtNombreCompleto.Font = new Font("Arial", 9F);
            txtNombreCompleto.ForeColor = Color.White;
            txtNombreCompleto.Location = new Point(937, 313);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.ReadOnly = true;
            txtNombreCompleto.Size = new Size(196, 18);
            txtNombreCompleto.TabIndex = 4;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.BackColor = Color.Black;
            txtIdUsuario.BorderStyle = BorderStyle.None;
            txtIdUsuario.Font = new Font("Arial", 9F);
            txtIdUsuario.ForeColor = Color.White;
            txtIdUsuario.Location = new Point(892, 222);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.Size = new Size(243, 18);
            txtIdUsuario.TabIndex = 3;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.BackgroundColor = Color.FromArgb(200, 209, 217);
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(58, 233);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(562, 425);
            dgvUsuarios.TabIndex = 6;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 128, 0);
            btnActualizar.FlatStyle = FlatStyle.Popup;
            btnActualizar.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(66, 693);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(554, 29);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "ACTUALIZAR TABLA";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAtrasGU
            // 
            btnAtrasGU.BackColor = Color.Red;
            btnAtrasGU.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtrasGU.ForeColor = SystemColors.ButtonHighlight;
            btnAtrasGU.Location = new Point(1150, -1);
            btnAtrasGU.Name = "btnAtrasGU";
            btnAtrasGU.Size = new Size(52, 33);
            btnAtrasGU.TabIndex = 8;
            btnAtrasGU.Text = "X";
            btnAtrasGU.UseVisualStyleBackColor = false;
            btnAtrasGU.Click += btnAtrasGU_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(200, 209, 217);
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Location = new Point(338, 176);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(279, 20);
            txtBuscar.TabIndex = 10;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // Form7GestionUsuario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(18, 59, 99);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAtrasGU);
            Controls.Add(btnActualizar);
            Controls.Add(cmbRol);
            Controls.Add(dgvUsuarios);
            Controls.Add(txtNombreCompleto);
            Controls.Add(txtIdUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form7GestionUsuario";
            Text = "Form7GestionUsuario";
            Load += Form7GestionUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvUsuarios;
        private Button btnLimpiar;
        private Button btnGuardar;
        private ComboBox cmbRol;
        private TextBox txtNombreCompleto;
        private TextBox txtIdUsuario;
        private Button btnActualizar;
        private Button btnAtrasGU;
        private TextBox txtBuscar;
        private Button btnEliminarUsuario;
    }
}