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
using static BLL.ClienteService;

namespace PlayerUI
{
    public partial class FrmRegistrarCliente : Form
    {
        ClienteService clienteService;
        Cliente cliente;
        public FrmRegistrarCliente()
        {
            InitializeComponent();
            clienteService = new ClienteService(ConfigConnection.connectionString, ConfigConnection.ProviderName);
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
            cliente.Cliente_id = txtIdentificacion.Text;
            cliente.PrimerNombre = txtPrimerNombreText.Text;
            cliente.SegundoNombre = txtSegundoNombreText.Text;
            cliente.PrimerApellido = txtPrimerApellidoText.Text;
            cliente.SegundoApellido = txtSegundoApellido.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.Barrio = txtBarrio.Text;
            cliente.Comuna =txtComuna.Text;
            cliente.N_Casa = txtCasa.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Email = txtCorreo.Text;
            return cliente;

        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = MapearCliente();
            string mensaje = clienteService.Guardar(cliente);
            MessageBox.Show(mensaje, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            Limpiar();
        }
        public void Limpiar()
        {
             txtIdentificacion.Text ="";
            txtPrimerNombreText.Text = "";
            txtSegundoNombreText.Text = "";
            txtPrimerApellidoText.Text = "";
           txtSegundoApellido.Text = "";
            txtCiudad.Text = "";
            txtBarrio.Text = "";
           txtComuna.Text = "";
            txtCasa.Text = "";
            txtTelefono.Text = "";
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            string cliente_id = txtIdentificacion.Text;
            if (cliente_id != "")
            {
                var respuesta = MessageBox.Show("Está seguro de eliminar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    string mensaje = clienteService.Eliminar(cliente_id);
                    MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor digite la cedula de la persona a modificar y presione el boton buscar", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            BusquedaClienteRespuesta respuesta = new BusquedaClienteRespuesta();
            string cliente_id = txtIdentificacion.Text;
            if (cliente_id != "")
            {
                respuesta = clienteService.BuscarxIdentificacion(cliente_id);

                if (respuesta.cliente != null)
                {
                    txtPrimerNombreText.Text = respuesta.cliente.PrimerNombre;
                    txtSegundoNombreText.Text = respuesta.cliente.SegundoNombre;
                    txtPrimerApellidoText.Text = respuesta.cliente.PrimerApellido;
                    txtSegundoApellido.Text = respuesta.cliente.SegundoApellido;
                    txtCiudad.Text = respuesta.cliente.Ciudad;
                    txtBarrio.Text = respuesta.cliente.Barrio;
                    txtCasa.Text = respuesta.cliente.N_Casa;
                    txtComuna.Text = respuesta.cliente.Comuna;
                    txtTelefono.Text = respuesta.cliente.Telefono;
                    txtCorreo.Text = respuesta.cliente.Email;
                    comboTipo.Text = "Cliente";
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

        private void butModificar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar la información", "Mensaje de modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Cliente cliente = MapearCliente();
                string mensaje = clienteService.Modificar(cliente);
                MessageBox.Show(mensaje, "Mensaje de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
