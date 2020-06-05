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
using static BLL.ClienteService;
using static BLL.TrabajadorService;

namespace PlayerUI
{
    public partial class FrmConsultarTerceros : Form
    {
        ClienteService clienteService;
        TrabajadorService trabajadorService;
        List<Cliente> clientes;
        Email correo = new Email(); 
        public FrmConsultarTerceros()
        {
            trabajadorService = new TrabajadorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

            clienteService = new ClienteService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
            InitializeComponent();
            clientes = new List<Cliente>();

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
                clientes = respuesta.clientes.ToList();
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

        private void buttonPdf_Click(object sender, EventArgs e)
        {
            ClientePdf();
        }

        private void ClientePdf()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Guardar Informe cliente";
            saveFileDialog.InitialDirectory = @"c:/document";
            saveFileDialog.DefaultExt = "pdf";
            string filename = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                if (filename != "" && clientes.Count > 0)
                {
                    string mensaje = clienteService.GenerarClientePdf(clientes, filename);

                    MessageBox.Show(mensaje, "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se especifico una ruta o No hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.Equals("") == false)
                {
                    txtAdjuntar.Text = this.openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error de la ruta del arcchivo" + ex.ToString());
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            correo.enviarCorreo("sneiderviana7@gmail.com", "carmencastillo14", "lista de cliente registrados en el proyecto de rafael rojas y sneider viana" ,"Enviar pdf al correo", txtCorreo.Text, txtAdjuntar.Text);

        }
    }
}
