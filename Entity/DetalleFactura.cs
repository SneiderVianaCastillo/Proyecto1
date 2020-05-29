using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class DetalleFactura
    {
        public int CodigoFactura { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Iva { get; set; }
        public int PrecioVenta { get; set; }
        public string Descripcion { get; set; }
        public Productos productos { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public void CalcularSubTotal()
        {
            Subtotal = productos.PrecioVenta  * Cantidad;
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
