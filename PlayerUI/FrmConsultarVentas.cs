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
using static BLL.FacturaService;

namespace PlayerUI
{
    public partial class FrmConsultarVentas : Form
    {
        FacturaService facturaService;
        List<Factura> facturas;
        public FrmConsultarVentas()
        {
            InitializeComponent();
            facturaService = new FacturaService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOcultarDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarNumFactura_Click(object sender, EventArgs e)
        {
            ConsultaFcturaRespuesta respuesta = new ConsultaFcturaRespuesta();

            dtgFacturas.DataSource = null;
            respuesta = facturaService.Consultar();
            dtgFacturas.DataSource = respuesta.factura;
            dtgFacturas.Refresh();
            MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
