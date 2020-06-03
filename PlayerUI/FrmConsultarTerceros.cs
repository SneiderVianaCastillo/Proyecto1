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
using static BLL.TrabajadorService;

namespace PlayerUI
{
    public partial class FrmConsultarTerceros : Form
    {
        ClienteService clienteService;
        TrabajadorService trabajadorService;
        public FrmConsultarTerceros()
        {
            trabajadorService = new TrabajadorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

            clienteService = new ClienteService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConsultarClientes_Click(object sender, EventArgs e)
        {
            string tipo = comboTipo.Text;
            if (tipo == "Cliente")
            {
                ConsultaClienteRespuesta respuesta = new ConsultaClienteRespuesta();

                dtgConsultarTerceros.DataSource = null;
                respuesta = clienteService.Consultar();
                dtgConsultarTerceros.DataSource = respuesta.clientes;
                dtgConsultarTerceros.Refresh();
                MessageBox.Show(respuesta.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ConsultaTrabajadorRespuesta respuesta2 = new ConsultaTrabajadorRespuesta();

                dtgConsultarTerceros.DataSource = null;
                respuesta2 = trabajadorService.Consultar();
                dtgConsultarTerceros.DataSource = respuesta2.trabajadores;
                dtgConsultarTerceros.Refresh();
                MessageBox.Show(respuesta2.Mensaje, "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
 
        }
    }
}
