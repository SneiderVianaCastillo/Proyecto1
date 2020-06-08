using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Productos
    {
        public string Productos_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio_venta { get; set; }
        public decimal Precio_costo { get; set; }
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public decimal Iva { get; set; }
        public int Cantidad { get; set; }

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

            if (Existencia < 0)
            {
                return false;
            }
            return true;
        }


    }
}
