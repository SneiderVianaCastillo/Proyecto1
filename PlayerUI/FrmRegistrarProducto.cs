using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
using Infraestructura;
using static BLL.ProductosService;
using static BLL.ProveedorService;

namespace PlayerUI
{
    public partial class FrmRegistrarProducto : Form
    {
        ProveedorService proveedorService;
        Proveedor proveedor;
        PDF pdf;
        ProductosService productosService;
        Productos productos;
        List<Productos> LisProductos = new List<Productos>();
        public FrmRegistrarProducto()
        {
            InitializeComponent();
            proveedorService = new ProveedorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            productosService = new ProductosService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

        }

        private Proveedor MapearProveedor()
        {
            proveedor = new Proveedor();
            proveedor.Rut = txtRut.Text;
            proveedor.NombreComercial = txtNombreComercial.Text;
            proveedor.Telefono = txtTelefono.Text;
            return proveedor;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            agregarTabla();
        }



        private void Btnsalir_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = MapearProveedor();
            string mensaje = proveedorService.Guardar(proveedor);
            MessageBox.Show(mensaje, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //Limpiar();
        }

        public void Limpiar()
        {
            txtRut.Text = "";
            txtNombreComercial.Text = "";
            txtTelefono.Text = "";

        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            BusquedaProveedorRespuesta respuesta = new BusquedaProveedorRespuesta();
            string rut = txtRut.Text;
            if (rut != "")
            {
                respuesta = proveedorService.BuscarxRut(rut);

                if (respuesta.proveedor != null)
                {
                    txtNombreComercial.Text = respuesta.proveedor.NombreComercial;
                    txtTelefono.Text = respuesta.proveedor.Telefono;
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

        private void agregarTabla()
        {
            dtgConsultarProductosPdf.Columns.Add("codigo", "Codigo");
            dtgConsultarProductosPdf.Columns.Add("nombre", "Nombre");
            dtgConsultarProductosPdf.Columns.Add("descripcion", "Descripcion");
            dtgConsultarProductosPdf.Columns.Add("precio compra", "Precio compra");
            dtgConsultarProductosPdf.Columns.Add("precio venta", "Precio venta");
            dtgConsultarProductosPdf.Columns.Add("iva", "Iva");
            dtgConsultarProductosPdf.Columns.Add("tipo", "Tipo");
            dtgConsultarProductosPdf.Columns.Add("modelo", "Modelo");
            dtgConsultarProductosPdf.Columns.Add("cantidad", "Cantidad");
        }
        private void butModificar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar el Proveedor", "Mensaje de modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Proveedor proveedor = MapearProveedor();
                string mensaje = proveedorService.Modificar(proveedor);
                MessageBox.Show(mensaje, "Mensaje de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text;
            if (rut != "")
            {
                var respuesta = MessageBox.Show("Está seguro de eliminar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    string mensaje = proveedorService.Eliminar(rut);
                    MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor digite el rut de la empresa a modificar y presione el boton buscar", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private Productos MapearProductos()
        {
            productos = new Productos();
            productos.Productos_id = txtCodigoProducto.Text;
            productos.Nombre = txtNombreProducto.Text;
            productos.Descripcion = txtDescripcion.Text;
            productos.Precio_venta = Convert.ToDecimal(txtPVenta.Text);
            productos.Precio_costo = Convert.ToDecimal(txtPCompra.Text);
            productos.Iva = Convert.ToInt32(txtIva.Text);
            productos.Tipo = comboTipo.Text;
            productos.Modelo = txtModelo.Text;
            productos.Cantidad = Convert.ToInt32(txtCantidad.Text);
            return productos;

        }
        private void button1_Click(object sender, EventArgs e)
        {
  
            try
            {
                BusquedaProductosRespuesta respuesta = new BusquedaProductosRespuesta();
    
                for (int i = 0; i <= LisProductos.Count; i++)
                {

             
                    string codigo = productos.Productos_id;
                    int Cantidad = productos.Cantidad;
                    respuesta = productosService.BuscarxCodigo(codigo);
                    if (respuesta.productos == null)
                    {
                        Productos productos = new Productos();
                        MapearLista(productos, i);
                        productos.CalcularExistencia(Cantidad);
                        productosService.Guardar(productos);
                    }
                    else
                    {
                        Productos productos = new Productos();
                        MapearLista(productos, i);
                        productos.CalcularExistencia(Cantidad);
                        productosService.ModificarTodos(productos);
                    }

                }

                MessageBox.Show("Productos Guardados ");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Asegúrese de establecer una lista de compras. " + ex.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
           

        }


        private void MapearLista(Productos ListaProductos, int i)
        {
            try
            {
                ListaProductos.Productos_id= LisProductos[i].Productos_id;
                ListaProductos.Nombre= LisProductos[i].Nombre;
                ListaProductos.Descripcion = LisProductos[i].Descripcion;
                ListaProductos.Precio_costo = LisProductos[i].Precio_costo;
                ListaProductos.Precio_venta = LisProductos[i].Precio_venta;
                ListaProductos.Iva = LisProductos[i].Iva;
                ListaProductos.Tipo = LisProductos[i].Tipo;
                ListaProductos.Modelo = LisProductos[i].Modelo;
                ListaProductos.Cantidad = LisProductos[i].Cantidad;
          

            }
            catch (Exception) { }
        }

        private void buttonPdf_Click(object sender, EventArgs e)
        {

            ProductosPdf();
        }
        private void ProductosPdf()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Guardar Informe De Productos Comprados";
            saveFileDialog.InitialDirectory = @"c:/document";
            saveFileDialog.DefaultExt = "pdf";
            string filename = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                if (filename != "" && LisProductos.Count > 0)
                {
                    string mensaje = productosService.GenerarProductosPdf(LisProductos, filename);

                    MessageBox.Show(mensaje, "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se especifico una ruta o No hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonBuscarPro_Click(object sender, EventArgs e)
        {
            BusquedaProductosRespuesta respuesta = new BusquedaProductosRespuesta();
            string codigo = txtCodigoProducto.Text;
            if (codigo != "")
            {
                respuesta = productosService.BuscarxCodigo(codigo);

                if (respuesta.productos != null)
                {
                    txtNombreProducto.Text = respuesta.productos.Nombre;
                    txtDescripcion.Text = respuesta.productos.Descripcion;
                    txtPCompra .Text =  respuesta.productos.Precio_costo.ToString();
                    txtPVenta.Text = respuesta.productos.Precio_venta.ToString();
                    txtIva.Text = respuesta.productos.Iva.ToString();
                    txtModelo.Text = respuesta.productos.Modelo;
                    txtCantidad.Text = respuesta.productos.Cantidad.ToString();
                    comboTipo.Text = respuesta.productos.Tipo;
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

        private void buttonModificarPro_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar el Producto", "Mensaje de modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                int Cantidad = Convert.ToInt32(txtCantidad.Text);
                Productos productos  = MapearProductos();
                productos.CalcularExistencia(Cantidad);
                string mensaje = productosService.ModificarTodos(productos);
                MessageBox.Show(mensaje, "Mensaje de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonEliminarProd_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoProducto.Text;
            if (codigo != "")
            {
                var respuesta = MessageBox.Show("Está seguro de eliminar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    string mensaje = productosService.Eliminar(codigo);
                    MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor digite el rut del producto y presione el boton buscar", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoProducto.Text;
            if (codigo != "")
            {
                Productos productos = MapearProductos();
                LisProductos.Add(productos);

                dtgConsultarProductosPdf.Rows.Add(txtCodigoProducto.Text, txtNombreProducto.Text, txtDescripcion.Text, txtPCompra.Text, txtPVenta.Text, txtIva.Text, comboTipo.Text, txtModelo.Text, txtCantidad.Text);
                txtCodigoProducto.Text = "";
                txtNombreProducto.Text = "";
                txtDescripcion.Text = "";
                txtPCompra.Text = "";
                txtPVenta.Text = "";
                txtIva.Text = "";
                comboTipo.Text = "";
                txtModelo.Text = "";
                txtCantidad.Text = "";

            }
            else
            {
                MessageBox.Show("Por favor digite un codigo de producto", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            
        }
    }
}
