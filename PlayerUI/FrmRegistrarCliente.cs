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

namespace PlayerUI
{
    public partial class FrmRegistrarCliente : Form
    {
        ClienteService clienteService;
        Cliente cliente;
        public FrmRegistrarCliente()
        {
            InitializeComponent();
            clienteService = new ClienteService(ConfigConnection.connectionString);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private Cliente MapearCliente()
        {
            cliente = new Cliente();
            cliente.Cliente_id = texIdentificacion.Text;
            cliente.PrimerNombre = PrimerNombreText.Text;
            cliente.SegundoNombre = SegundoNombreText.Text;
            cliente.PrimerApellido = PrimerApellidoText.Text;
            cliente.SegundoApellido = SegundoApellidotext.Text;
            cliente.Ciudad = textCiudad.Text;
            cliente.Barrio = BarrioText.Text;
            cliente.Comuna =ComunaText.Text;
            cliente.N_Casa = textDireccion.Text;
            cliente.Telefono = textTelefono.Text;
            return cliente;

        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = MapearCliente();
            string mensaje = clienteService.Guardar(cliente);
            MessageBox.Show(mensaje, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
