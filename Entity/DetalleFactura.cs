using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class DetalleFactura
    {
        public string DetalleFac_id { get; set; }
        public string CodigoFactura { get; set; }
        public int Cantidad { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio_venta { get; set; }
        public string Descripcion { get; set; }
        public Productos productos { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public DetalleFactura()
        {
            productos = new Productos();
        }
        public void CalcularSubTotal()
        {
            Subtotal = productos.Precio_venta  * Cantidad;
        }

        public void CalcularIva()
        {
            Iva = productos.Iva * Subtotal;
        }

       public void CalcularTotal()
        {
            CalcularSubTotal();
            CalcularIva();
            Total = Subtotal + Iva;
        }
    }
}
