using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using Infraestructura;
using static BLL.DetalleFacturaService;
using static BLL.FacturaService;

namespace PlayerUI
{
    public partial class FrmConsultarVentas : Form
    {
        FacturaService facturaService;
        List<Factura> facturas;
        DetalleFacturaService detalleFacturaService;
        List<DetalleFactura> LisDetalleFacturas;
        ConsultaDetalleFcturaRespuesta respuesta1;
        ConsultaFcturaRespuesta respuesta;
        public FrmConsultarVentas()
        {
            InitializeComponent();
            facturaService = new FacturaService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            detalleFacturaService = new DetalleFacturaService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            respuesta1 = new ConsultaDetalleFcturaRespuesta();
            respuesta = new ConsultaFcturaRespuesta();
            facturas = new List<Factura>();
            LisDetalleFacturas = new List<DetalleFactura>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOcultarDetalle_Click(object sender, EventArgs e)
        {
            DtgDetallesFacturas.Columns.Clear();
        }

        private void btnBuscarNumFactura_Click(object sender, EventArgs e)
        {
            dtgFacturas.Columns.Clear();
            DtgDetallesFacturas.Columns.Clear();
            agregarTablaFactura();
            agregarTablaDetalleFactura();
            if (comboTipo.Text == "Todo")
            {
                ConsultarTodo();
            }
            else
            {
                if (comboTipo.Text == "#De Factura")
                {
                    
                    ConsultarXfactura();
                }
                else
                {
                    if (comboTipo.Text == "Cliente")
                    {
                        ConsultarXcliente();
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione una obcion valida");
                    }
                }
            }
              
        }

        private void ConsultarXcliente()
        {
            string encontro = "no";
            string Cliente_id = txtID.Text;
            respuesta1 = detalleFacturaService.Consultar();
            LisDetalleFacturas = respuesta1.detalle.ToList();
            respuesta = facturaService.Consultar();
            facturas = respuesta.factura.ToList();
            foreach (var item in facturas)
            {
                if (Cliente_id == item.cliente.Identificacion)
                {
                    dtgFacturas.Rows.Add(item.Factura_id, item.Totales, item.Fecha, item.cliente.Identificacion, item.FormaPago);
                    foreach (var items in LisDetalleFacturas)
                    {
                        if (item.Factura_id == items.CodigoFactura)
                            DtgDetallesFacturas.Rows.Add(items.DetalleFac_id, items.productos.Productos_id, items.productos.Nombre, items.productos.Tipo, items.productos.Precio_venta, items.Cantidad, items.Total, items.CodigoFactura);
                    }
                    encontro = "si";
                }

            }
            if (encontro == "no")
            {
                MessageBox.Show( "No hay Factura con ese Id");
                DtgDetallesFacturas.Columns.Clear();
                dtgFacturas.Columns.Clear();
            }
        }
        private void ConsultarXfactura()
        {
            string encontro = "no";
            string factura_id= txtID.Text;
            respuesta1 = detalleFacturaService.Consultar();
            respuesta = facturaService.Consultar();
            facturas = respuesta.factura.ToList();
            LisDetalleFacturas = respuesta1.detalle.ToList();
            foreach (var item in facturas)
            {
                if(factura_id == item.Factura_id)
                dtgFacturas.Rows.Add(item.Factura_id, item.Totales, item.Fecha, item.cliente.Identificacion, item.FormaPago);
                encontro = "si";
            }
            foreach (var item in LisDetalleFacturas)
            {
                if (factura_id == item.CodigoFactura)
                    DtgDetallesFacturas.Rows.Add(item.DetalleFac_id, item.productos.Productos_id, item.productos.Nombre, item.productos.Tipo, item.productos.Precio_venta, item.Cantidad, item.Total, item.CodigoFactura);

            }
            if (encontro == "no")
            {
                DtgDetallesFacturas.Columns.Clear();
                dtgFacturas.Columns.Clear();
                MessageBox.Show("No hay Factura con ese Id");
            }

        }
        private void ConsultarTodo()
        {

            respuesta = facturaService.Consultar();
            facturas = respuesta.factura.ToList();
            respuesta1 = detalleFacturaService.Consultar();
            LisDetalleFacturas = respuesta1.detalle.ToList();
            foreach (var item in facturas)
            {
                dtgFacturas.Rows.Add(item.Factura_id, item.Totales, item.Fecha, item.cliente.Identificacion, item.FormaPago);

            }

            foreach (var item in LisDetalleFacturas)
            {
                DtgDetallesFacturas.Rows.Add(item.DetalleFac_id, item.productos.Productos_id, item.productos.Nombre, item.productos.Tipo, item.productos.Precio_venta, item.Cantidad, item.Total, item.CodigoFactura);

            }
         
        }

        private void FrmConsultarVentas_Load(object sender, EventArgs e)
        {
           
            
        }
        private void agregarTablaDetalleFactura()
        {
            DtgDetallesFacturas.Columns.Add("DetalleFac_id", "DetalleFac_id");
            DtgDetallesFacturas.Columns.Add("Productos_id", "Productos_id");
            DtgDetallesFacturas.Columns.Add("nombre", "Nombre");
            DtgDetallesFacturas.Columns.Add("tipo", "Tipo");
            DtgDetallesFacturas.Columns.Add("precio", "Precio");
            DtgDetallesFacturas.Columns.Add("cantidad", "Cantidad");
            DtgDetallesFacturas.Columns.Add("total", "Total");
            DtgDetallesFacturas.Columns.Add("factura_id", "Factura_id");
        }

        private void agregarTablaFactura()
        {
            dtgFacturas.Columns.Add("factura_id", "Factura_id");
            dtgFacturas.Columns.Add("total", "Total");
            dtgFacturas.Columns.Add("fecha", "Fecha");
            dtgFacturas.Columns.Add("cliente_id", "Cliente_id");
            dtgFacturas.Columns.Add("forma de pago", "Forma de pago");
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            agregarTablaDetalleFactura();
        }

        private void btnBuscarPorFechas_Click(object sender, EventArgs e)
        {
            DtgDetallesFacturas.Columns.Clear();
            dtgFacturas.Columns.Clear();
            agregarTablaFactura();
            agregarTablaDetalleFactura();
            ConsultarXfecha();
        }

        private void ConsultarXfecha()
        {
            string encontro = "no";
            txtID.Text = "";
            comboTipo.Text = "...";
            DateTime fecha = Convert.ToDateTime(fechaDatetime.Text);
            respuesta1 = detalleFacturaService.Consultar();
            LisDetalleFacturas = respuesta1.detalle.ToList();
            respuesta = facturaService.Consultar();
            facturas = respuesta.factura.ToList();
            foreach (var item in facturas)
            {
                if (fecha == item.Fecha)
                {
                    encontro = "si";
                    dtgFacturas.Rows.Add(item.Factura_id, item.Totales, item.Fecha, item.cliente.Identificacion, item.FormaPago);
                    foreach (var items in LisDetalleFacturas)
                    {
                        if (item.Factura_id == items.CodigoFactura)
                            DtgDetallesFacturas.Rows.Add(items.DetalleFac_id, items.productos.Productos_id, items.productos.Nombre, items.productos.Tipo, items.productos.Precio_venta, items.Cantidad, items.Total, items.CodigoFactura);

                    }
                }
                
            }
            if (encontro == "no")
            {
                DtgDetallesFacturas.Columns.Clear();
                dtgFacturas.Columns.Clear();
                MessageBox.Show("No hay Factura con esa fecha");
            
            }
        }

        private void buttonMostrar_Click_1(object sender, EventArgs e)
        {
            dtgFacturas.Columns.Clear();
            DtgDetallesFacturas.Columns.Clear();
            agregarTablaFactura();
            agregarTablaDetalleFactura();
            if (comboTipo.Text == "Todo")
            {
                ConsultarTodo();
            }
            else
            {
                if (comboTipo.Text == "#De Factura")
                {

                    ConsultarXfactura();
                }
                else
                {
                    if (comboTipo.Text == "Cliente")
                    {
                        ConsultarXcliente();
                    }
                    else
                    {
                        ConsultarXfecha();
                    }
                }
            }
        }
    }
}
