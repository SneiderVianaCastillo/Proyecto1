namespace PlayerUI
{
    partial class FrmConsultarVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarVentas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNumeroFactura = new System.Windows.Forms.TextBox();
            this.btnBuscarNumFactura = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarPorFechas = new System.Windows.Forms.Button();
            this.dtgFacturas = new System.Windows.Forms.DataGridView();
            this.btnOcultarDetalle = new System.Windows.Forms.Button();
            this.DtgDetallesFacturas = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetallesFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(238, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "CONSULTAR VENTAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(108, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "# De Factura";
            // 
            // textNumeroFactura
            // 
            this.textNumeroFactura.Location = new System.Drawing.Point(111, 79);
            this.textNumeroFactura.Name = "textNumeroFactura";
            this.textNumeroFactura.Size = new System.Drawing.Size(127, 20);
            this.textNumeroFactura.TabIndex = 4;
            // 
            // btnBuscarNumFactura
            // 
            this.btnBuscarNumFactura.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarNumFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarNumFactura.Image")));
            this.btnBuscarNumFactura.Location = new System.Drawing.Point(254, 62);
            this.btnBuscarNumFactura.Name = "btnBuscarNumFactura";
            this.btnBuscarNumFactura.Size = new System.Drawing.Size(48, 37);
            this.btnBuscarNumFactura.TabIndex = 5;
            this.btnBuscarNumFactura.UseVisualStyleBackColor = false;
            this.btnBuscarNumFactura.Click += new System.EventHandler(this.btnBuscarNumFactura_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(347, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "DESDE:";
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.Location = new System.Drawing.Point(326, 79);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(94, 20);
            this.dateTimeDesde.TabIndex = 7;
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Location = new System.Drawing.Point(442, 79);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(94, 20);
            this.dateTimeHasta.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(465, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "HASTA:";
            // 
            // btnBuscarPorFechas
            // 
            this.btnBuscarPorFechas.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPorFechas.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPorFechas.Image")));
            this.btnBuscarPorFechas.Location = new System.Drawing.Point(552, 62);
            this.btnBuscarPorFechas.Name = "btnBuscarPorFechas";
            this.btnBuscarPorFechas.Size = new System.Drawing.Size(48, 37);
            this.btnBuscarPorFechas.TabIndex = 10;
            this.btnBuscarPorFechas.UseVisualStyleBackColor = false;
            // 
            // dtgFacturas
            // 
            this.dtgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFacturas.Location = new System.Drawing.Point(45, 121);
            this.dtgFacturas.Name = "dtgFacturas";
            this.dtgFacturas.Size = new System.Drawing.Size(618, 150);
            this.dtgFacturas.TabIndex = 11;
            // 
            // btnOcultarDetalle
            // 
            this.btnOcultarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnOcultarDetalle.Image")));
            this.btnOcultarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOcultarDetalle.Location = new System.Drawing.Point(498, 277);
            this.btnOcultarDetalle.Name = "btnOcultarDetalle";
            this.btnOcultarDetalle.Size = new System.Drawing.Size(165, 46);
            this.btnOcultarDetalle.TabIndex = 12;
            this.btnOcultarDetalle.Text = "Ocultar Detalles";
            this.btnOcultarDetalle.UseVisualStyleBackColor = true;
            this.btnOcultarDetalle.Click += new System.EventHandler(this.btnOcultarDetalle_Click);
            // 
            // DtgDetallesFacturas
            // 
            this.DtgDetallesFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetallesFacturas.Location = new System.Drawing.Point(45, 329);
            this.DtgDetallesFacturas.Name = "DtgDetallesFacturas";
            this.DtgDetallesFacturas.Size = new System.Drawing.Size(618, 97);
            this.DtgDetallesFacturas.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(12, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FrmConsultarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(704, 438);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.DtgDetallesFacturas);
            this.Controls.Add(this.btnOcultarDetalle);
            this.Controls.Add(this.dtgFacturas);
            this.Controls.Add(this.btnBuscarPorFechas);
            this.Controls.Add(this.dateTimeHasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarNumFactura);
            this.Controls.Add(this.textNumeroFactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Name = "FrmConsultarVentas";
            this.Text = "FrmConsultarVentas";
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetallesFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNumeroFactura;
        private System.Windows.Forms.Button btnBuscarNumFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarPorFechas;
        private System.Windows.Forms.DataGridView dtgFacturas;
        private System.Windows.Forms.Button btnOcultarDetalle;
        private System.Windows.Forms.DataGridView DtgDetallesFacturas;
        private System.Windows.Forms.Button button5;
    }
}