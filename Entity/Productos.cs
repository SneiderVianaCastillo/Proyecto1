using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Productos
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public int PrecioVenta { get; set; }
        public int PrecioCosto { get; set; }
        public string Tipo { get; set; }
      
        public decimal Iva { get; set; }

      public void CalcularExistencia(int cantidad)
        {
            Existencia = Existencia + cantidad;
        }
        public void DescontarExistencia(int cantidad)
        {
            Existencia = Existencia - cantidad;
        }

        public bool Verificarexistencia()
        {
            
            if (Existencia<0)
            {
                return false;
            }
            return true;
        }
      

    }
}
