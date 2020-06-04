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
using static BLL.ProveedorService;

namespace PlayerUI
{
    public partial class FrmConsultarProducto : Form
    {
        ProveedorService proveedorService;
        public FrmConsultarProducto()
        {
            InitializeComponent();
            proveedorService = new ProveedorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultarClientes_Click(object sender, EventArgs e)
        {
            ConsultaProveedorRespuesta respuesta = new ConsultaProveedorRespuesta();

            DtgConsultarProducto.DataSource = null;
            respuesta = proveedorService.Consultar();
            DtgConsultarProducto.DataSource = respuesta.proveedors;
            DtgConsultarProducto.Refresh();
            MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
