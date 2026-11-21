namespace PROYECTO_PR_BD_PE
{
    partial class Form111Perfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form111Perfil));
            txtNombreP = new TextBox();
            txtApellidoP = new TextBox();
            txtNickP = new TextBox();
            txtEmailAp = new TextBox();
            txtEmailNp = new TextBox();
            txtContraAp = new TextBox();
            txtContraNp = new TextBox();
            btnEliminarP = new Button();
            btnGuardarP = new Button();
            btnVolverP = new Button();
            SuspendLayout();
            // 
            // txtNombreP
            // 
            txtNombreP.BackColor = Color.FromArgb(224, 189, 189);
            txtNombreP.BorderStyle = BorderStyle.None;
            txtNombreP.Location = new Point(77, 352);
            txtNombreP.Name = "txtNombreP";
            txtNombreP.Size = new Size(419, 20);
            txtNombreP.TabIndex = 0;
            // 
            // txtApellidoP
            // 
            txtApellidoP.BackColor = Color.FromArgb(224, 189, 189);
            txtApellidoP.BorderStyle = BorderStyle.None;
            txtApellidoP.Location = new Point(701, 353);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.Size = new Size(419, 20);
            txtApellidoP.TabIndex = 1;
            // 
            // txtNickP
            // 
            txtNickP.BackColor = Color.FromArgb(224, 189, 189);
            txtNickP.BorderStyle = BorderStyle.None;
            txtNickP.Location = new Point(79, 433);
            txtNickP.Name = "txtNickP";
            txtNickP.Size = new Size(419, 20);
            txtNickP.TabIndex = 2;
            // 
            // txtEmailAp
            // 
            txtEmailAp.BackColor = Color.FromArgb(224, 189, 189);
            txtEmailAp.BorderStyle = BorderStyle.None;
            txtEmailAp.Location = new Point(303, 530);
            txtEmailAp.Name = "txtEmailAp";
            txtEmailAp.Size = new Size(293, 20);
            txtEmailAp.TabIndex = 3;
            // 
            // txtEmailNp
            // 
            txtEmailNp.BackColor = Color.FromArgb(224, 189, 189);
            txtEmailNp.BorderStyle = BorderStyle.None;
            txtEmailNp.Location = new Point(853, 530);
            txtEmailNp.Name = "txtEmailNp";
            txtEmailNp.Size = new Size(267, 20);
            txtEmailNp.TabIndex = 4;
            // 
            // txtContraAp
            // 
            txtContraAp.BackColor = Color.FromArgb(224, 189, 189);
            txtContraAp.BorderStyle = BorderStyle.None;
            txtContraAp.Location = new Point(390, 631);
            txtContraAp.Name = "txtContraAp";
            txtContraAp.Size = new Size(206, 20);
            txtContraAp.TabIndex = 5;
            // 
            // txtContraNp
            // 
            txtContraNp.BackColor = Color.FromArgb(224, 189, 189);
            txtContraNp.BorderStyle = BorderStyle.None;
            txtContraNp.Location = new Point(925, 631);
            txtContraNp.Name = "txtContraNp";
            txtContraNp.Size = new Size(201, 20);
            txtContraNp.TabIndex = 6;
            // 
            // btnEliminarP
            // 
            btnEliminarP.BackColor = Color.White;
            btnEliminarP.FlatStyle = FlatStyle.Popup;
            btnEliminarP.Font = new Font("Arial Rounded MT Bold", 12F);
            btnEliminarP.ForeColor = Color.FromArgb(255, 128, 0);
            btnEliminarP.Location = new Point(236, 687);
            btnEliminarP.Name = "btnEliminarP";
            btnEliminarP.Size = new Size(344, 38);
            btnEliminarP.TabIndex = 7;
            btnEliminarP.Text = "ELIMINAR CUENTA";
            btnEliminarP.UseVisualStyleBackColor = false;
            btnEliminarP.Click += btnEliminarP_Click;
            // 
            // btnGuardarP
            // 
            btnGuardarP.BackColor = Color.White;
            btnGuardarP.FlatStyle = FlatStyle.Popup;
            btnGuardarP.Font = new Font("Arial Rounded MT Bold", 12F);
            btnGuardarP.ForeColor = Color.FromArgb(255, 128, 0);
            btnGuardarP.Location = new Point(661, 686);
            btnGuardarP.Name = "btnGuardarP";
            btnGuardarP.Size = new Size(338, 38);
            btnGuardarP.TabIndex = 8;
            btnGuardarP.Text = "GUARDAR CAMBIOS";
            btnGuardarP.UseVisualStyleBackColor = false;
            btnGuardarP.Click += btnGuardarP_Click;
            // 
            // btnVolverP
            // 
            btnVolverP.BackColor = Color.Red;
            btnVolverP.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVolverP.ForeColor = Color.White;
            btnVolverP.Location = new Point(1160, -1);
            btnVolverP.Name = "btnVolverP";
            btnVolverP.Size = new Size(41, 40);
            btnVolverP.TabIndex = 9;
            btnVolverP.Text = "X";
            btnVolverP.UseVisualStyleBackColor = false;
            btnVolverP.Click += btnVolverP_Click;
            // 
            // Form111Perfil
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1201, 753);
            Controls.Add(btnVolverP);
            Controls.Add(btnGuardarP);
            Controls.Add(btnEliminarP);
            Controls.Add(txtContraNp);
            Controls.Add(txtContraAp);
            Controls.Add(txtEmailNp);
            Controls.Add(txtEmailAp);
            Controls.Add(txtNickP);
            Controls.Add(txtApellidoP);
            Controls.Add(txtNombreP);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form111Perfil";
            Text = "Form12Sedes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreP;
        private TextBox txtApellidoP;
        private TextBox txtNickP;
        private TextBox txtEmailAp;
        private TextBox txtEmailNp;
        private TextBox txtContraAp;
        private TextBox txtContraNp;
        private Button btnEliminarP;
        private Button btnGuardarP;
        private Button btnVolverP;
    }
}