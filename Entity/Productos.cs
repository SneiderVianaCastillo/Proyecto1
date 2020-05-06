using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Productos
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public int PrecioVenta { get; set; }
        public int PrecioCosto { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public decimal Iva { get; set; }

      public void CalcularExistencia()
        {
            Existencia = Existencia + Cantidad;
        }

        public bool Verificarexistencia()
        {
            Existencia = Existencia - Cantidad;
            if (Existencia<0)
            {
                return false;
            }
            return true;
        }
        public decimal CalcularIva()
        {
            return Iva = Convert.ToDecimal(PrecioVenta * 0.19) * Cantidad;
        }

    }
}
