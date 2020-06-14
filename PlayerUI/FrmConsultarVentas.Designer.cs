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
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnBuscarNumFactura = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarPorFechas = new System.Windows.Forms.Button();
            this.dtgFacturas = new System.Windows.Forms.DataGridView();
            this.btnOcultarDetalle = new System.Windows.Forms.Button();
            this.DtgDetallesFacturas = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.fechaDatetime = new System.Windows.Forms.DateTimePicker();
            this.buttonMostrar = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(265, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "CONSULTAR VENTAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(257, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(226, 79);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(77, 20);
            this.txtID.TabIndex = 4;
            // 
            // btnBuscarNumFactura
            // 
            this.btnBuscarNumFactura.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarNumFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarNumFactura.Image")));
            this.btnBuscarNumFactura.Location = new System.Drawing.Point(318, 62);
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
            this.label3.Location = new System.Drawing.Point(430, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "CONSULTAR X FECHA";
            // 
            // btnBuscarPorFechas
            // 
            this.btnBuscarPorFechas.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPorFechas.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPorFechas.Image")));
            this.btnBuscarPorFechas.Location = new System.Drawing.Point(587, 63);
            this.btnBuscarPorFechas.Name = "btnBuscarPorFechas";
            this.btnBuscarPorFechas.Size = new System.Drawing.Size(48, 37);
            this.btnBuscarPorFechas.TabIndex = 10;
            this.btnBuscarPorFechas.UseVisualStyleBackColor = false;
            this.btnBuscarPorFechas.Click += new System.EventHandler(this.btnBuscarPorFechas_Click);
            // 
            // dtgFacturas
            // 
            this.dtgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFacturas.Location = new System.Drawing.Point(154, 121);
            this.dtgFacturas.Name = "dtgFacturas";
            this.dtgFacturas.Size = new System.Drawing.Size(424, 169);
            this.dtgFacturas.TabIndex = 11;
            // 
            // btnOcultarDetalle
            // 
            this.btnOcultarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnOcultarDetalle.Image")));
            this.btnOcultarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOcultarDetalle.Location = new System.Drawing.Point(587, 322);
            this.btnOcultarDetalle.Name = "btnOcultarDetalle";
            this.btnOcultarDetalle.Size = new System.Drawing.Size(125, 46);
            this.btnOcultarDetalle.TabIndex = 12;
            this.btnOcultarDetalle.Text = "Ocultar Detalles";
            this.btnOcultarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOcultarDetalle.UseVisualStyleBackColor = true;
            this.btnOcultarDetalle.Click += new System.EventHandler(this.btnOcultarDetalle_Click);
            // 
            // DtgDetallesFacturas
            // 
            this.DtgDetallesFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDetallesFacturas.Location = new System.Drawing.Point(68, 374);
            this.DtgDetallesFacturas.Name = "DtgDetallesFacturas";
            this.DtgDetallesFacturas.Size = new System.Drawing.Size(644, 192);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(112, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "CONSULTAR";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "...",
            "Todo",
            "#De Factura",
            "Cliente"});
            this.comboTipo.Location = new System.Drawing.Point(99, 77);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(101, 21);
            this.comboTipo.TabIndex = 16;
            // 
            // fechaDatetime
            // 
            this.fechaDatetime.CustomFormat = "dd - MM - yyyy";
            this.fechaDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaDatetime.Location = new System.Drawing.Point(417, 79);
            this.fechaDatetime.Name = "fechaDatetime";
            this.fechaDatetime.Size = new System.Drawing.Size(151, 20);
            this.fechaDatetime.TabIndex = 30;
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonMostrar.Image")));
            this.buttonMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMostrar.Location = new System.Drawing.Point(453, 322);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(125, 46);
            this.buttonMostrar.TabIndex = 17;
            this.buttonMostrar.Text = "Mostrar Detalles";
            this.buttonMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMostrar.UseVisualStyleBackColor = true;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click_1);
            // 
            // FrmConsultarVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(759, 588);
            this.Controls.Add(this.fechaDatetime);
            this.Controls.Add(this.buttonMostrar);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.DtgDetallesFacturas);
            this.Controls.Add(this.btnOcultarDetalle);
            this.Controls.Add(this.dtgFacturas);
            this.Controls.Add(this.btnBuscarPorFechas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarNumFactura);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Name = "FrmConsultarVentas";
            this.Text = "FrmConsultarVentas";
            this.Load += new System.EventHandler(this.FrmConsultarVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDetallesFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnBuscarNumFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarPorFechas;
        private System.Windows.Forms.DataGridView dtgFacturas;
        private System.Windows.Forms.Button btnOcultarDetalle;
        private System.Windows.Forms.DataGridView DtgDetallesFacturas;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.DateTimePicker fechaDatetime;
        private System.Windows.Forms.Button buttonMostrar;
    }
}