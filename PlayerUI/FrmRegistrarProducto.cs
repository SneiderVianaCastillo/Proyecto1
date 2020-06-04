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
using static BLL.ProveedorService;

namespace PlayerUI
{
    public partial class FrmRegistrarProducto : Form
    {
        ProveedorService proveedorService;
        Proveedor proveedor ;
        public FrmRegistrarProducto()
        {
            InitializeComponent();
            proveedorService = new ProveedorService(ConfigConnection.connectionString, ConfigConnection.ProviderName);

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
            Limpiar();
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
    }
}
