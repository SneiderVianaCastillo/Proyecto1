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
using Infraestructura;
using static BLL.ClienteService;
using static BLL.TrabajadorService;

namespace PlayerUI
{
    public partial class FrmRegistrarTerceros : Form
    {
        ClienteService clienteService;
        Cliente cliente;
        TrabajadorService trabajadorService;
        Trabajador trabajador;
        Email e = new Email();
        public FrmRegistrarTerceros()
        {
            InitializeComponent();
            trabajadorService = new TrabajadorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

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
            cliente.Identificacion = txtIdentificacion.Text;
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
        private Trabajador MapearTrabajador()
        {
            trabajador = new Trabajador();
            trabajador.Identificacion = txtIdentificacion.Text;
            trabajador.PrimerNombre = txtPrimerNombreText.Text;
            trabajador.SegundoNombre = txtSegundoNombreText.Text;
            trabajador.PrimerApellido = txtPrimerApellidoText.Text;
            trabajador.SegundoApellido = txtSegundoApellido.Text;
            trabajador.Telefono = txtTelefono.Text;
            trabajador.Cargo = comboCargo.Text;
            trabajador.Ciudad = txtCiudad.Text;
            trabajador.Barrio = txtBarrio.Text;
            trabajador.Comuna = txtComuna.Text;
            trabajador.N_Casa = txtCasa.Text;
            trabajador.Email = txtCorreo.Text;
            return trabajador;

        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           
            string tipo = comboTipo.Text;
            if (tipo == "Cliente")
            {
                Cliente cliente = MapearCliente();
                string mensaje = clienteService.Guardar(cliente);
                MessageBox.Show(mensaje, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                Trabajador trabajador = MapearTrabajador();
                string mensaje2 = trabajadorService.Guardar(trabajador);
                MessageBox.Show(mensaje2, "Mensaje de Guardado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Limpiar();
            }
 
        }
        public void Limpiar()
        {
            comboTipo.Text = "...";
            comboCargo.Text = "...";
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
            txtCorreo.Text = "";
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            string tipo = comboTipo.Text;
            if (tipo == "Cliente")
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
            else
            {
                string trabajador_id = txtIdentificacion.Text;
                if (trabajador_id != "")
                {
                    var respuesta = MessageBox.Show("Está seguro de eliminar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        string mensaje = trabajadorService.Eliminar(trabajador_id);
                        MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor digite la cedula de la persona a modificar y presione el boton buscar", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Limpiar();
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            string tipo = comboTipo.Text;
            if (tipo == "Cliente")
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
            else
            {
                BusquedaTrabajadorRespuesta respuesta = new BusquedaTrabajadorRespuesta();
                string trabajador_id = txtIdentificacion.Text;
                if (trabajador_id != "")
                {
                    respuesta = trabajadorService.BuscarxIdentificacionTrab(trabajador_id);

                    if (respuesta.trabajador != null)
                    {
                        txtPrimerNombreText.Text = respuesta.trabajador.PrimerNombre;
                        txtSegundoNombreText.Text = respuesta.trabajador.SegundoNombre;
                        txtPrimerApellidoText.Text = respuesta.trabajador.PrimerApellido;
                        txtSegundoApellido.Text = respuesta.trabajador.SegundoApellido;
                        txtTelefono.Text = respuesta.trabajador.Telefono;
                        comboCargo.Text = respuesta.trabajador.Cargo;
                        txtCiudad.Text = respuesta.trabajador.Ciudad;
                        txtBarrio.Text = respuesta.trabajador.Barrio;
                        txtCasa.Text = respuesta.trabajador.N_Casa;
                        txtComuna.Text = respuesta.trabajador.Comuna;
                        txtCorreo.Text = respuesta.trabajador.Email;
                        comboTipo.Text = "Trabajador";
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
           

        }

        private void butModificar_Click(object sender, EventArgs e)
        {
            string tipo = comboTipo.Text;
            if (tipo == "Trabajador")
            {
                var respuesta2 = MessageBox.Show("Está seguro de Modificar el Trabajador", "Mensaje de modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta2 == DialogResult.Yes)
                {
                    Trabajador trabajador = MapearTrabajador();
                    string mensaje2 = trabajadorService.Modificar(trabajador);
                    MessageBox.Show(mensaje2, "Mensaje de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                var respuesta = MessageBox.Show("Está seguro de Modificar el Cliente ", "Mensaje de modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Cliente cliente = MapearCliente();
                    string mensaje = clienteService.Modificar(cliente);
                    MessageBox.Show(mensaje, "Mensaje de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
