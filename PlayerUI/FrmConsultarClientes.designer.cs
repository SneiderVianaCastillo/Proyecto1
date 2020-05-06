namespace PlayerUI
{
    partial class FrmConsultarClientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnConsultarClientes = new System.Windows.Forms.Button();
            this.dtgConsultarClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarClientes)).BeginInit();
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
            this.BtnConsultarClientes.Location = new System.Drawing.Point(54, 95);
            this.BtnConsultarClientes.Name = "BtnConsultarClientes";
            this.BtnConsultarClientes.Size = new System.Drawing.Size(150, 40);
            this.BtnConsultarClientes.TabIndex = 18;
            this.BtnConsultarClientes.Text = "CONSULTAR";
            this.BtnConsultarClientes.UseVisualStyleBackColor = false;
            // 
            // dtgConsultarClientes
            // 
            this.dtgConsultarClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsultarClientes.Location = new System.Drawing.Point(54, 163);
            this.dtgConsultarClientes.Name = "dtgConsultarClientes";
            this.dtgConsultarClientes.Size = new System.Drawing.Size(618, 150);
            this.dtgConsultarClientes.TabIndex = 19;
            // 
            // FrmConsultarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(795, 431);
            this.Controls.Add(this.dtgConsultarClientes);
            this.Controls.Add(this.BtnConsultarClientes);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Name = "FrmConsultarClientes";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button BtnConsultarClientes;
        private System.Windows.Forms.DataGridView dtgConsultarClientes;
    }
}