namespace PlayerUI
{
    partial class FrmConsultarTerceros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarTerceros));
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnConsultarClientes = new System.Windows.Forms.Button();
            this.dtgConsultarTerceros = new System.Windows.Forms.DataGridView();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarTerceros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(315, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "CONSULTAR";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnConsultarClientes
            // 
            this.BtnConsultarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.BtnConsultarClientes.FlatAppearance.BorderSize = 0;
            this.BtnConsultarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConsultarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultarClientes.ForeColor = System.Drawing.Color.LightGray;
            this.BtnConsultarClientes.Location = new System.Drawing.Point(278, 90);
            this.BtnConsultarClientes.Name = "BtnConsultarClientes";
            this.BtnConsultarClientes.Size = new System.Drawing.Size(150, 40);
            this.BtnConsultarClientes.TabIndex = 18;
            this.BtnConsultarClientes.Text = "CONSULTAR";
            this.BtnConsultarClientes.UseVisualStyleBackColor = false;
            this.BtnConsultarClientes.Click += new System.EventHandler(this.BtnConsultarClientes_Click);
            // 
            // dtgConsultarTerceros
            // 
            this.dtgConsultarTerceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsultarTerceros.Location = new System.Drawing.Point(12, 163);
            this.dtgConsultarTerceros.Name = "dtgConsultarTerceros";
            this.dtgConsultarTerceros.Size = new System.Drawing.Size(771, 329);
            this.dtgConsultarTerceros.TabIndex = 19;
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "...",
            "Cliente",
            "Trabajador"});
            this.comboTipo.Location = new System.Drawing.Point(113, 101);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(139, 21);
            this.comboTipo.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(71, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Tipo";
            // 
            // buttonPdf
            // 
            this.buttonPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.buttonPdf.FlatAppearance.BorderSize = 0;
            this.buttonPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPdf.ForeColor = System.Drawing.Color.LightGray;
            this.buttonPdf.Image = ((System.Drawing.Image)(resources.GetObject("buttonPdf.Image")));
            this.buttonPdf.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPdf.Location = new System.Drawing.Point(462, 72);
            this.buttonPdf.Name = "buttonPdf";
            this.buttonPdf.Size = new System.Drawing.Size(61, 58);
            this.buttonPdf.TabIndex = 64;
            this.buttonPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPdf.UseVisualStyleBackColor = false;
            this.buttonPdf.UseWaitCursor = true;
            this.buttonPdf.Click += new System.EventHandler(this.buttonPdf_Click);
            // 
            // FrmConsultarTerceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(795, 512);
            this.Controls.Add(this.buttonPdf);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtgConsultarTerceros);
            this.Controls.Add(this.BtnConsultarClientes);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Name = "FrmConsultarTerceros";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarTerceros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button BtnConsultarClientes;
        private System.Windows.Forms.DataGridView dtgConsultarTerceros;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonPdf;
    }
}