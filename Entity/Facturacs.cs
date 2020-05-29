using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Facturacs
    {
        public List<DetalleFactura> DetalleFacturas { get; set; }
        public int Codigo { get; set; }
        public string CodigoCliente { get; set; }
        public Persona Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public decimal Iva { get; set; }
        public bool EstadoFactura { get; set; }
        public Persona cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }



        public void AgregarDetalles(Productos producto,int cantidad)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.productos = producto;
            detalleFactura.Descripcion = producto.Descripcion;
            detalleFactura.Cantidad = cantidad;
            detalleFactura.CalcularTotal();
            DetalleFacturas.Add(detalleFactura);
        }
       
        public void CalcularSubtotal()
        {
            SubTotal = DetalleFacturas.Sum(d=>d.Subtotal);
        }
        public void CalcularIva()
        {
            Iva = DetalleFacturas.Sum(d => d.Iva);
        }
        public void CalcularTotal()
        {
            CalcularSubtotal();
            CalcularIva();
            Total = SubTotal + Iva;
        }


    }
}
