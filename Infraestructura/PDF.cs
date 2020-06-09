using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Infraestructura
{
    public class PDF
    {
        
        public void GuardarProductoPdf(IList<Productos> productos, string ruta)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 30, 30, 10);
            PdfWriter pw = PdfWriter.GetInstance(document, fileStream);
            document.AddAuthor("Proyecto QuickBilling");
            document.Open();
            document.Add(new Paragraph("Lista De Productos Comprados " + "         " + "Productos"));
            document.Add(new Paragraph("\n"));
            document.Add(LlenarTabla(productos));
            document.Close();

        }


        public PdfPTable LlenarTabla(IList<Productos> productos)
        {
            PdfPTable tabla = new PdfPTable(9);

            tabla.AddCell(new Paragraph("Productos_id"));
            tabla.AddCell(new Paragraph("nombre"));
            tabla.AddCell(new Paragraph("Descripcion"));
            tabla.AddCell(new Paragraph("precio_venta"));
            tabla.AddCell(new Paragraph("precio_costo"));
            tabla.AddCell(new Paragraph("Iva"));
            tabla.AddCell(new Paragraph("tipo"));
            tabla.AddCell(new Paragraph("modelo"));
            tabla.AddCell(new Paragraph("cantidad"));
            foreach (var item in productos)
            {
                tabla.AddCell(item.Productos_id);
                tabla.AddCell(item.Nombre);
                tabla.AddCell(item.Descripcion);
                tabla.AddCell(Convert.ToString(item.Precio_venta));
                tabla.AddCell(Convert.ToString(item.Precio_costo));
                tabla.AddCell(Convert.ToString(item.Iva));
                tabla.AddCell(item.Tipo);
                tabla.AddCell(item.Modelo);
                tabla.AddCell(Convert.ToString(item.Cantidad));

            }

            return tabla;
        }

        public void GuardarClientePdf(IList<Cliente> clientes, string ruta)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 40, 40, 40, 40);
            PdfWriter pw = PdfWriter.GetInstance(document, fileStream);

            document.AddAuthor("Proyecto QuickBilling");
            document.Open();
            document.Add(new Paragraph("Lista de clientes " + "         " + "prueba"));
            document.Add(new Paragraph("\n"));
            document.Add(LlenarTablaCliente(clientes));
            document.Close();

        }

        public PdfPTable LlenarTablaCliente(IList<Cliente> clientes)
        {
            PdfPTable tabla = new PdfPTable(11);

            tabla.AddCell(new Paragraph("Identificacion"));
            tabla.AddCell(new Paragraph("PrimerNombre"));
            tabla.AddCell(new Paragraph("SegundoNombre"));
            tabla.AddCell(new Paragraph("PrimerApellido"));
            tabla.AddCell(new Paragraph("SegundoApellido"));
            tabla.AddCell(new Paragraph("Ciudad"));
            tabla.AddCell(new Paragraph("Barrio"));
            tabla.AddCell(new Paragraph("Comuna"));
            tabla.AddCell(new Paragraph("N_Casa"));
            tabla.AddCell(new Paragraph("Telefono"));
            tabla.AddCell(new Paragraph("Email"));
            foreach (var item in clientes)
            {
                tabla.AddCell(item.Identificacion);
                tabla.AddCell(item.PrimerNombre);
                tabla.AddCell(item.SegundoNombre);
                tabla.AddCell(item.PrimerApellido);
                tabla.AddCell(item.SegundoApellido);
                tabla.AddCell(item.Ciudad);
                tabla.AddCell(item.Barrio);
                tabla.AddCell(item.Comuna);
                tabla.AddCell(item.N_Casa);
                tabla.AddCell(item.Telefono);
                tabla.AddCell(item.Email);

            }

            return tabla;
        }
    }
}
