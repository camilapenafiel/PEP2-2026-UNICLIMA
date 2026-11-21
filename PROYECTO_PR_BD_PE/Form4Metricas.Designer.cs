namespace PROYECTO_PR_BD_PE
{
    partial class Form4Metricas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4Metricas));
            button2 = new Button();
            button1 = new Button();
            lblValorTemp = new Label();
            lblValorHumedad = new Label();
            lblValorUV = new Label();
            lblValorPresion = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panelGrafico = new Panel();
            panel2 = new Panel();
            lblEstadisticaClima = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
            button2.Location = new Point(1142, 0);
            button2.Name = "button2";
            button2.Size = new Size(59, 32);
            button2.TabIndex = 3;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.White;
            button1.Location = new Point(-1, 0);
            button1.Name = "button1";
            button1.Size = new Size(55, 32);
            button1.TabIndex = 0;
            button1.Text = "↩";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblValorTemp
            // 
            lblValorTemp.AutoSize = true;
            lblValorTemp.BackColor = Color.Transparent;
            lblValorTemp.Font = new Font("Arial Rounded MT Bold", 13.8F);
            lblValorTemp.Location = new Point(829, 532);
            lblValorTemp.Name = "lblValorTemp";
            lblValorTemp.Size = new Size(78, 27);
            lblValorTemp.TabIndex = 42;
            lblValorTemp.Text = "28° C ";
            // 
            // lblValorHumedad
            // 
            lblValorHumedad.AutoSize = true;
            lblValorHumedad.BackColor = Color.Transparent;
            lblValorHumedad.Font = new Font("Arial Rounded MT Bold", 13.8F);
            lblValorHumedad.Location = new Point(828, 586);
            lblValorHumedad.Name = "lblValorHumedad";
            lblValorHumedad.Size = new Size(66, 27);
            lblValorHumedad.TabIndex = 43;
            lblValorHumedad.Text = "18 %";
            // 
            // lblValorUV
            // 
            lblValorUV.AutoSize = true;
            lblValorUV.BackColor = Color.Transparent;
            lblValorUV.Font = new Font("Arial Rounded MT Bold", 13.8F);
            lblValorUV.Location = new Point(833, 643);
            lblValorUV.Name = "lblValorUV";
            lblValorUV.Size = new Size(26, 27);
            lblValorUV.TabIndex = 44;
            lblValorUV.Text = "4";
            // 
            // lblValorPresion
            // 
            lblValorPresion.AutoSize = true;
            lblValorPresion.BackColor = Color.Transparent;
            lblValorPresion.Font = new Font("Arial Rounded MT Bold", 13.8F);
            lblValorPresion.Location = new Point(831, 700);
            lblValorPresion.Name = "lblValorPresion";
            lblValorPresion.Size = new Size(47, 27);
            lblValorPresion.TabIndex = 45;
            lblValorPresion.Text = ".....";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 0);
            button3.Font = new Font("Arial Rounded MT Bold", 10.8F);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(496, 526);
            button3.Name = "button3";
            button3.Size = new Size(155, 29);
            button3.TabIndex = 47;
            button3.Text = "VER GRAFICA";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnVerGraficaTemp_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 128, 0);
            button4.Font = new Font("Arial Rounded MT Bold", 10.8F);
            button4.ForeColor = Color.Transparent;
            button4.Location = new Point(496, 585);
            button4.Name = "button4";
            button4.Size = new Size(155, 29);
            button4.TabIndex = 48;
            button4.Text = "VER GRAFICA";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnVerGraficaHumedad_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 128, 0);
            button5.Font = new Font("Arial Rounded MT Bold", 10.8F);
            button5.ForeColor = Color.Transparent;
            button5.Location = new Point(496, 641);
            button5.Name = "button5";
            button5.Size = new Size(155, 29);
            button5.TabIndex = 49;
            button5.Text = "VER GRAFICA";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnVerGraficaUV_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(255, 128, 0);
            button6.Font = new Font("Arial Rounded MT Bold", 10.8F);
            button6.ForeColor = Color.Transparent;
            button6.Location = new Point(496, 696);
            button6.Name = "button6";
            button6.Size = new Size(155, 29);
            button6.TabIndex = 50;
            button6.Text = "VER GRAFICA";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnVerGraficaPresion_Click;
            // 
            // panelGrafico
            // 
            panelGrafico.BackColor = Color.Transparent;
            panelGrafico.Location = new Point(70, 134);
            panelGrafico.Margin = new Padding(3, 4, 3, 4);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Size = new Size(1058, 273);
            panelGrafico.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DeepSkyBlue;
            panel2.Location = new Point(-2, 763);
            panel2.Name = "panel2";
            panel2.Size = new Size(1186, 32);
            panel2.TabIndex = 29;
            // 
            // lblEstadisticaClima
            // 
            lblEstadisticaClima.Location = new Point(58, 434);
            lblEstadisticaClima.Name = "lblEstadisticaClima";
            lblEstadisticaClima.Size = new Size(1085, 57);
            lblEstadisticaClima.TabIndex = 52;
            lblEstadisticaClima.Text = "Cargando resumen...";
            // 
            // Form4Metricas
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(lblEstadisticaClima);
            Controls.Add(button2);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(panelGrafico);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(lblValorPresion);
            Controls.Add(lblValorUV);
            Controls.Add(lblValorHumedad);
            Controls.Add(lblValorTemp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4Metricas";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private Label lblValorTemp;
        private Label lblValorHumedad;
        private Label lblValorUV;
        private Label lblValorPresion;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel panelGrafico;
        private Panel panel2;
        private Label lblEstadisticaClima;
    }
}