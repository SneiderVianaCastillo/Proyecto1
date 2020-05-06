using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Facturacs
    {
        public List<DetalleFactura> DetalleFacturas { get; set; }
        public int Codigo { get; set; }
        public string CodigoCliente { get; set; }
        public string Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public decimal Iva { get; set; }
        public bool EstadoFactura { get; set; }
        public Persona cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }



        public void AgregarDetalles(Productos producto, Persona cliente)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.productos = producto;
            detalleFactura.Descripcion = producto.Descripcion;
            detalleFactura.Cantidad = producto.Cantidad;
            detalleFactura.CalcularSubTotal();
            detalleFactura.CalcularIva();
            detalleFactura.CalcularCantidad();
            detalleFactura.Iva = producto.Iva;


        }
       

        public void CalcularTotal()
        {
            Total = SubTotal + Iva;
        }


    }
}
