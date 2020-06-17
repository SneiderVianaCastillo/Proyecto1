using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using Infraestructura;
using static BLL.ClienteService;
using static BLL.FacturaService;
using static BLL.ProductosService;

namespace PlayerUI
{
    public partial class FrmRegistrarVenta : Form
    {
    
        ClienteService clienteService;
        ProductosService productosService;
        FacturaService facturaService;
        DetalleFacturaService detalleFacturaService;
        Factura factura;
        DetalleFactura detalleFatura;
        List<Factura> LisFactura;
        List<DetalleFactura> LisDetalle = new List<DetalleFactura>();
        List<Productos> LisDetalleAux;
        List<Factura> LisFacturaAux;
        int i = 1;
        int N_Factura = 1;
        string correo;
        string ruta_correo;
        Email email = new Email();
        public FrmRegistrarVenta()
        {
            InitializeComponent();
            clienteService = new ClienteService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            productosService = new ProductosService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            facturaService = new FacturaService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            detalleFacturaService = new DetalleFacturaService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            LisDetalleAux = new List< Productos>();
            LisFacturaAux = new List<Factura>();
            LisFactura = new List<Factura>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BusquedaClienteRespuesta respuesta = new BusquedaClienteRespuesta();
            string cliente_id = txtIdentificacion.Text;
            if (cliente_id != "")
            {
                respuesta = clienteService.BuscarxIdentificacion(cliente_id);

                if (respuesta.cliente != null)
                {
                    
                    txtNombreCliente.Text = respuesta.cliente.PrimerNombre;
                    correo = respuesta.cliente.Email;
                    MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Por favor digite una identificación", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NFacturas()
        {
            int N_Factura=1;
            ConsultaFcturaRespuesta respuesta = new ConsultaFcturaRespuesta();
            respuesta = facturaService.Consultar();
            LisFactura = respuesta.factura.ToList();
            foreach (var item in LisFactura)
            {
                N_Factura++;
            }
            txtNFactura.Text = Convert.ToString(N_Factura);
            i = N_Factura;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BusquedaProductosRespuesta respuesta = new BusquedaProductosRespuesta();
            string codigo = txtCodigo.Text;

            if (codigo != "")
            {
                respuesta = productosService.BuscarxCodigo(codigo);

                if (respuesta.productos != null)
                {
                    txtNombreProducto.Text = respuesta.productos.Nombre;
                    txtPrecio.Text = respuesta.productos.Precio_venta.ToString();
                    txtIva.Text = respuesta.productos.Iva.ToString();
                    MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Por favor digite una identificación", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DetalleFactura MapearProductos()
        {
            detalleFatura = new DetalleFactura();
            detalleFatura.productos.Productos_id= txtCodigo.Text;
            detalleFatura.productos.Nombre = txtNombreProducto.Text;
            detalleFatura.Cantidad = Convert.ToInt32(txtCantidad.Text);
            return detalleFatura;

        }

        private void agregarTabla()
        {
            dtgFactura.Columns.Add("codigo", "Codigo");
            dtgFactura.Columns.Add("nombre", "Nombre");
            dtgFactura.Columns.Add("precio venta", "Precio venta" );
            dtgFactura.Columns.Add("cantidad", "Cantidad");
            dtgFactura.Columns.Add("iva", "Iva");
            dtgFactura.Columns.Add("sub total", "Sub total");
            dtgFactura.Columns.Add("total", "Total");
        }
        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            ConsultaProductosRespuesta respuesta = new ConsultaProductosRespuesta();
            respuesta = productosService.Consultar();
            LisDetalleAux = respuesta.productos.ToList();
            string codigo = txtCodigo.Text;
            double Iva = 0.19;
            if (codigo != "")
            {
                DetalleFactura detalle = MapearProductos();

                foreach (var item in LisDetalleAux)
                {
                  
                    if (item.Productos_id == codigo)
                    {
                       
                        detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        if (detalle.Cantidad <= item.Existencia)
                        {
                            if (item.Iva == 19)
                            {
                                detalle.productos.Iva = Convert.ToDecimal(Iva);
                            }
                            else
                            {
                                detalle.productos.Iva = 0;
                            }
                            detalle.productos.Precio_venta = item.Precio_venta;
                            detalle.productos.Nombre = item.Nombre;
                            detalle.productos.Tipo = item.Tipo;
                            detalle.productos.Productos_id = item.Productos_id;
                            detalle.CalcularSubTotal();
                            detalle.CalcularIva();
                            detalle.CalcularTotal();
                            detalle.CodigoFactura = txtNFactura.Text;
                            detalle.DetalleFac_id = txtNFactura.Text + i;
                            detalle.Total = detalle.Total;
                            i++;
                            LisDetalle.Add(detalle);


                            dtgFactura.Rows.Add(txtCodigo.Text, txtNombreProducto.Text, txtPrecio.Text, txtCantidad.Text, detalle.Iva, detalle.Subtotal, detalle.Total);
                            LimpiarPro();
                        }
                        else
                        {
                            MessageBox.Show("Cantida sobre pasa a la existencia del producto, la existencia es de:" + item.Existencia);
                        }
                    }
                             
                }

            }
            else
            {
                MessageBox.Show("Por favor digite un codigo de producto", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AgregarTotales();
        }

        private void AgregarTotales()
        {
            Factura factura = new Factura();
            foreach (var item in LisDetalle)
            {
                int Cantidad = item.Cantidad;
               
                factura.AgregarDetalles(item.productos,Cantidad);
                factura.CalcularSubtotal();
                factura.CalcularIva();
                factura.CalcularTotal();

                LisFacturaAux.Add(factura);
                txtSubTotal.Text = Convert.ToString(factura.SubTotal);
                txtIvaTotall.Text = Convert.ToString(factura.Iva);
                txtTotal.Text = Convert.ToString(factura.Totales);
            }
        }
        private void LimpiarPro()
        {
            txtCodigo.Text = "";
            txtNombreProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtIva.Text = "";
        }

        private void FrmRegistrarVenta_Load(object sender, EventArgs e)
        {
            agregarTabla();
            NFacturas();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void MapearListDetalle(DetalleFactura detalle, int i)
        {
       
            try
            {
                detalle.DetalleFac_id= LisDetalle[i].DetalleFac_id ;
                detalle.productos.Productos_id = LisDetalle[i].productos.Productos_id;
                detalle.productos.Nombre= LisDetalle[i].productos.Nombre;
                detalle.productos.Tipo = LisDetalle[i].productos.Tipo;
                detalle.productos.Precio_venta = LisDetalle[i].productos.Precio_venta;
                detalle.Cantidad = LisDetalle[i].Cantidad;
                detalle.Total= LisDetalle[i].Total;
                detalle.CodigoFactura = LisDetalle[i].CodigoFactura;

            }
            catch (Exception) { }
        }

        private Factura MapearFactura()
        {
                factura = new Factura();
                factura.Factura_id = txtNFactura.Text;
                factura.Totales = Convert.ToDecimal(txtTotal.Text);
                factura.Fecha = DateTime.Parse(fechaDatetime.Text.ToString());
                factura.cliente.Identificacion = txtIdentificacion.Text;
                factura.FormaPago = comboFPago.Text;
                return factura;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = MapearFactura();
                string mensaje = facturaService.Guardar(factura);
               
                for (int i = 0; i <= LisDetalle.Count; i++)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    MapearListDetalle(detalle, i);
                    detalleFacturaService.Guardar(detalle);
                }
                MessageBox.Show(mensaje, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Asegúrese de establecer una lista de compras. " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            
        }

        private void LimpiarFactura()
        {
            txtIdentificacion.Text = "";
            txtNombreCliente.Text = "";
            comboFPago.Text = "...";
            txtSubTotal.Text = "";
            txtTotal.Text = "";
            txtIvaTotall.Text = "";
            dtgFactura.Columns.Clear();
            agregarTabla();
           //LisDetalle.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarFactura();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DetallesPdf();
            email.enviarCorreoFactura("quickbillin2019@gmail.com", "programacion3", "lista de productos comprados", "Factura de compra", correo, ruta_correo);
            NFacturas();
            LimpiarFactura();
        }
        private void DetallesPdf()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            Factura factura = MapearFactura();
            saveFileDialog.Title = "Guardar Informe Venta";
            saveFileDialog.InitialDirectory = @"c:/document";
            saveFileDialog.DefaultExt = "pdf";
            string filename = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                if (filename != "" && LisDetalle.Count > 0)
                {
                    ruta_correo = filename;
                    string mensaje = detalleFacturaService.GenerarDetallePdf(LisDetalle, filename, factura);

                    MessageBox.Show(mensaje, "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se especifico una ruta o No hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
