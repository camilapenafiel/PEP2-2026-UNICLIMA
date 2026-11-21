namespace PROYECTO_PR_BD_PE
{
    partial class Form9Reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9Reportes));
            cmbEstacion = new ComboBox();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            btnGenerarReporte = new Button();
            cmbTipoReporte = new ComboBox();
            btnExportarExcel = new Button();
            btnAtras = new Button();
            btnExportarPDF = new Button();
            btnExportarWord = new Button();
            SuspendLayout();
            // 
            // cmbEstacion
            // 
            cmbEstacion.BackColor = Color.FromArgb(200, 209, 217);
            cmbEstacion.FormattingEnabled = true;
            cmbEstacion.Items.AddRange(new object[] { "CAMPUS CENTRAL", "CAMPUS \"CALA CALA\"" });
            cmbEstacion.Location = new Point(182, 174);
            cmbEstacion.Name = "cmbEstacion";
            cmbEstacion.Size = new Size(289, 28);
            cmbEstacion.TabIndex = 2;
            // 
            // dtpInicio
            // 
            dtpInicio.CalendarFont = new Font("Arial Rounded MT Bold", 9F);
            dtpInicio.Location = new Point(201, 382);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(250, 27);
            dtpInicio.TabIndex = 3;
            // 
            // dtpFin
            // 
            dtpFin.CalendarFont = new Font("Arial Rounded MT Bold", 9F);
            dtpFin.Location = new Point(182, 442);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(250, 27);
            dtpFin.TabIndex = 4;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.FromArgb(255, 128, 0);
            btnGenerarReporte.FlatStyle = FlatStyle.Popup;
            btnGenerarReporte.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Location = new Point(73, 530);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(414, 31);
            btnGenerarReporte.TabIndex = 5;
            btnGenerarReporte.Text = "GENERAR REPORTE";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.BackColor = Color.FromArgb(220, 238, 255);
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Items.AddRange(new object[] { "Histórico General", "", "Comparativo de Estaciones", "", "Alertas Climatológicas", "", "Tendencias Mensuales", "", "Mantenimiento IoT" });
            cmbTipoReporte.Location = new Point(253, 227);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(216, 28);
            cmbTipoReporte.TabIndex = 18;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.Green;
            btnExportarExcel.FlatStyle = FlatStyle.Popup;
            btnExportarExcel.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(247, 712);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(79, 29);
            btnExportarExcel.TabIndex = 11;
            btnExportarExcel.Text = "EXCEL";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnAtras
            // 
            btnAtras.BackColor = Color.Red;
            btnAtras.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtras.ForeColor = SystemColors.ButtonHighlight;
            btnAtras.Location = new Point(1155, 0);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(46, 33);
            btnAtras.TabIndex = 1;
            btnAtras.Text = "X";
            btnAtras.UseVisualStyleBackColor = false;
            btnAtras.Click += btnAtras_Click;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.Red;
            btnExportarPDF.FlatStyle = FlatStyle.Popup;
            btnExportarPDF.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.Location = new Point(84, 712);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(94, 29);
            btnExportarPDF.TabIndex = 19;
            btnExportarPDF.Text = "PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnExportarWord
            // 
            btnExportarWord.BackColor = Color.FromArgb(0, 0, 192);
            btnExportarWord.FlatStyle = FlatStyle.Popup;
            btnExportarWord.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarWord.ForeColor = Color.White;
            btnExportarWord.Location = new Point(393, 712);
            btnExportarWord.Name = "btnExportarWord";
            btnExportarWord.Size = new Size(94, 29);
            btnExportarWord.TabIndex = 20;
            btnExportarWord.Text = "WORD";
            btnExportarWord.UseVisualStyleBackColor = false;
            // 
            // Form9Reportes
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(btnExportarWord);
            Controls.Add(btnExportarPDF);
            Controls.Add(cmbTipoReporte);
            Controls.Add(btnAtras);
            Controls.Add(btnExportarExcel);
            Controls.Add(cmbEstacion);
            Controls.Add(dtpInicio);
            Controls.Add(dtpFin);
            Controls.Add(btnGenerarReporte);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form9Reportes";
            Text = "Form9Reportes";
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbEstacion;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Button btnGenerarReporte;
        private Button btnExportarExcel;
        private ComboBox cmbTipoReporte;
        private Button btnAtras;
        private Button btnExportarPDF;
        private Button btnExportarWord;
    }
}