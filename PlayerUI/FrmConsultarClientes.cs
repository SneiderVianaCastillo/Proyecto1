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
using static BLL.ClienteService;

namespace PlayerUI
{
    public partial class FrmConsultarClientes : Form
    {
        ClienteService clienteService;
        public FrmConsultarClientes()
        {
         clienteService = new ClienteService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultarClientes_Click(object sender, EventArgs e)
        {
            ConsultaClienteRespuesta respuesta = new ConsultaClienteRespuesta();

            dtgConsultarClientes.DataSource = null;
            respuesta = clienteService.Consultar();
            dtgConsultarClientes.DataSource = respuesta.clientes;
            dtgConsultarClientes.Refresh();
            MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
