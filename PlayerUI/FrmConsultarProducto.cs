using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.ProductosService;
using static BLL.ProveedorService;

namespace PlayerUI
{
    public partial class FrmConsultarProducto : Form
    {
        ProveedorService proveedorService;
        ProductosService productosService;
        public FrmConsultarProducto()
        {
            InitializeComponent();
            productosService = new ProductosService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

            proveedorService = new ProveedorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultarClientes_Click(object sender, EventArgs e)
        {
            ConsultaProductosRespuesta respuesta = new ConsultaProductosRespuesta();
            DtgConsultarProductos.DataSource = null;
            respuesta = productosService.Consultar();
            DtgConsultarProductos.DataSource = respuesta.productos;
            DtgConsultarProductos.Refresh();
            MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
