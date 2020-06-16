namespace PlayerUI
{
    partial class FrmRegistrarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarVenta));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fechaDatetime = new System.Windows.Forms.DateTimePicker();
            this.comboFPago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonBuscarProducto = new System.Windows.Forms.Button();
            this.buttonAñadir = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dtgFactura = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNFactura = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIvaTotall = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(416, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "VENTAS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.fechaDatetime);
            this.panel1.Controls.Add(this.comboFPago);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtIva);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.buttonBuscarProducto);
            this.panel1.Controls.Add(this.buttonAñadir);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtNombreProducto);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNombreCliente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonBuscarCliente);
            this.panel1.Controls.Add(this.txtIdentificacion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 219);
            this.panel1.TabIndex = 2;
            // 
            // fechaDatetime
            // 
            this.fechaDatetime.CustomFormat = "dd - MM - yyyy";
            this.fechaDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaDatetime.Location = new System.Drawing.Point(350, 51);
            this.fechaDatetime.Name = "fechaDatetime";
            this.fechaDatetime.Size = new System.Drawing.Size(134, 20);
            this.fechaDatetime.TabIndex = 29;
            // 
            // comboFPago
            // 
            this.comboFPago.FormattingEnabled = true;
            this.comboFPago.Items.AddRange(new object[] {
            "...",
            "Efectivo",
            "Tarjeta"});
            this.comboFPago.Location = new System.Drawing.Point(211, 123);
            this.comboFPago.Name = "comboFPago";
            this.comboFPago.Size = new System.Drawing.Size(121, 21);
            this.comboFPago.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(208, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Forma De Pago";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(278, 178);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(62, 20);
            this.txtIva.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(277, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Iva";
            // 
            // buttonBuscarProducto
            // 
            this.buttonBuscarProducto.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscarProducto.ForeColor = System.Drawing.Color.Gray;
            this.buttonBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuscarProducto.Image")));
            this.buttonBuscarProducto.Location = new System.Drawing.Point(147, 112);
            this.buttonBuscarProducto.Name = "buttonBuscarProducto";
            this.buttonBuscarProducto.Size = new System.Drawing.Size(48, 41);
            this.buttonBuscarProducto.TabIndex = 21;
            this.buttonBuscarProducto.UseVisualStyleBackColor = false;
            this.buttonBuscarProducto.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonAñadir
            // 
            this.buttonAñadir.BackColor = System.Drawing.Color.Transparent;
            this.buttonAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAñadir.ForeColor = System.Drawing.Color.Gray;
            this.buttonAñadir.Image = ((System.Drawing.Image)(resources.GetObject("buttonAñadir.Image")));
            this.buttonAñadir.Location = new System.Drawing.Point(431, 158);
            this.buttonAñadir.Name = "buttonAñadir";
            this.buttonAñadir.Size = new System.Drawing.Size(69, 55);
            this.buttonAñadir.TabIndex = 20;
            this.buttonAñadir.UseVisualStyleBackColor = false;
            this.buttonAñadir.Click += new System.EventHandler(this.buttonAñadir_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(363, 179);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(62, 20);
            this.txtCantidad.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(362, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cantidad";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(161, 179);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(103, 20);
            this.txtPrecio.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(158, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Precio";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(8, 178);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(135, 20);
            this.txtNombreProducto.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Nombre";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(6, 123);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(135, 20);
            this.txtCodigo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Codigo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "DATOS DEL PRODUCTO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(347, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(195, 50);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(135, 20);
            this.txtNombreCliente.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(192, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre";
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscarCliente.ForeColor = System.Drawing.Color.Gray;
            this.buttonBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuscarCliente.Image")));
            this.buttonBuscarCliente.Location = new System.Drawing.Point(147, 40);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(48, 41);
            this.buttonBuscarCliente.TabIndex = 3;
            this.buttonBuscarCliente.UseVisualStyleBackColor = false;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(6, 51);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(135, 20);
            this.txtIdentificacion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CC cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DATOS DE VENTA";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.Transparent;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("buttonGuardar.Image")));
            this.buttonGuardar.Location = new System.Drawing.Point(698, 37);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(125, 89);
            this.buttonGuardar.TabIndex = 21;
            this.buttonGuardar.Text = "Vender";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(698, 228);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 96);
            this.button5.TabIndex = 22;
            this.button5.Text = "Cancelar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(698, 132);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(125, 90);
            this.button6.TabIndex = 23;
            this.button6.Text = "Imprimir";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // dtgFactura
            // 
            this.dtgFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFactura.Location = new System.Drawing.Point(12, 262);
            this.dtgFactura.Name = "dtgFactura";
            this.dtgFactura.Size = new System.Drawing.Size(661, 146);
            this.dtgFactura.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtNFactura);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(516, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 219);
            this.panel2.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // txtNFactura
            // 
            this.txtNFactura.Location = new System.Drawing.Point(29, 174);
            this.txtNFactura.Name = "txtNFactura";
            this.txtNFactura.Size = new System.Drawing.Size(98, 20);
            this.txtNFactura.TabIndex = 26;
            this.txtNFactura.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(42, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "N° De Ventas";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(18, 431);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(105, 20);
            this.txtSubTotal.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(52, 415);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Sub total";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtIvaTotall
            // 
            this.txtIvaTotall.Location = new System.Drawing.Point(160, 431);
            this.txtIvaTotall.Name = "txtIvaTotall";
            this.txtIvaTotall.Size = new System.Drawing.Size(105, 20);
            this.txtIvaTotall.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(190, 415);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "IVA";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(292, 431);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(131, 20);
            this.txtTotal.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(334, 415);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Total Pagar";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(3, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 32;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(698, 330);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(125, 86);
            this.button8.TabIndex = 33;
            this.button8.Text = "Salir";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // FrmRegistrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(915, 536);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtIvaTotall);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtgFactura);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistrarVenta";
            this.Text = "FrmRegistrarVenta";
            this.Load += new System.EventHandler(this.FrmRegistrarVenta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactura)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAñadir;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dtgFactura;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNFactura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIvaTotall;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonBuscarProducto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboFPago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker fechaDatetime;
    }
}