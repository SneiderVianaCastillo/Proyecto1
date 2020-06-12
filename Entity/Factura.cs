using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Factura
    {
        public string Factura_id { get; set; }
        public List<DetalleFactura> detalleFacturas { get; set; }
        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        public decimal Iva { get; set; }
        public bool EstadoFactura { get; set; }
        public Cliente cliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Totales { get; set; }

        public Factura()
        {
            detalleFacturas = new List<DetalleFactura>();
            cliente = new Cliente();
        }

        public void AgregarDetalles(Productos producto,int cantidad)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.productos = producto;
            detalleFactura.Descripcion = producto.Descripcion;
            detalleFactura.Cantidad = cantidad;
            detalleFactura.CalcularTotal();
            detalleFacturas.Add(detalleFactura);
        }
       
        public void CalcularSubtotal()
        {
            SubTotal = detalleFacturas.Sum(d=>d.Subtotal);
        }
        public void CalcularIva()
        {
            Iva = detalleFacturas.Sum(d => d.Iva);
        }
        public void CalcularTotal()
        {
            CalcularSubtotal();
            CalcularIva();
            Totales = SubTotal + Iva;
        }


    }
}
