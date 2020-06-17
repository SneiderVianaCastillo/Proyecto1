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
        decimal totalFactura = 0;

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


        public void GuardarDetallesPdf(IList<DetalleFactura> detalles, string ruta, Factura factura)
        {
            FileStream fs = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL, 10, 40, 40, 10);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            document.AddTitle("QuickBilling");
            document.AddCreator("Proyecto QuickBilling");

            document.Open();
            DateTime fecha = DateTime.Now;
            string fechaactual = fecha.ToString();
            // Escribimos el encabezamiento en el documento
            document.Add(new Paragraph(fechaactual));
            document.Add(Chunk.NEWLINE);
            //margenes
            var content = pw.DirectContent;
            var pageBorderRect = new Rectangle(document.PageSize);

            pageBorderRect.Left += document.LeftMargin;
            pageBorderRect.Right -= document.RightMargin;
            pageBorderRect.Top -= document.TopMargin;
            pageBorderRect.Bottom += document.BottomMargin;

            content.SetColorStroke(BaseColor.BLACK);
            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
            content.Stroke();
            //pie de pagina 

            PdfPTable tabFot = new PdfPTable(new float[] { 1F });
            PdfPCell cell;
            tabFot.TotalWidth = 50F;
            cell = new PdfPCell(new Phrase("QuickBilling", FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.BOLD)));
            tabFot.AddCell(cell);
            tabFot.WriteSelectedRows(0, -1, 500, document.Bottom, pw.DirectContent);

            // logo
            string rutaimagen = @"C:\Users\ROJAS R\Downloads\Proyecto Final\Iconos\reyna.png";
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaimagen);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            document.Add(imagen);

            Paragraph Venta = new Paragraph("QuickBilling\n");
            Venta.Alignment = Element.ALIGN_CENTER;
            document.Add(Venta);
            Paragraph asteriscos = new Paragraph("**********\n");
            asteriscos.Alignment = Element.ALIGN_CENTER;
            document.Add(asteriscos);
            Paragraph direccion = new Paragraph("Dir: Calle 7 # 20-03 - Br. Kennedy (Sector el Boliche) VALLEDUPAR\n");
            direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(direccion);
            Paragraph telefono = new Paragraph("Tel: 570 9627 Fax: 570 7484\n");
            telefono.Alignment = Element.ALIGN_CENTER;
            document.Add(telefono);
            document.Add(new Paragraph("\n"));
            Paragraph detalle = new Paragraph("Factura de venta\n");
            detalle.Alignment = Element.ALIGN_CENTER;
            document.Add(detalle);

            Paragraph NoFact = new Paragraph("No fact:" + factura.Factura_id + "\n");
            NoFact.Alignment = Element.ALIGN_CENTER;
            document.Add(NoFact);
            Paragraph fecha_ = new Paragraph("Fecha creacion:" + factura.Fecha + "\n");
            fecha_.Alignment = Element.ALIGN_CENTER;
            document.Add(fecha_);
            Paragraph fechaImpresion = new Paragraph("Fecha impresion:" + DateTime.Now.ToString() + "\n");
            fechaImpresion.Alignment = Element.ALIGN_CENTER;
            document.Add(fechaImpresion);
            document.Add(new Paragraph("\n"));


            //lo que dimos en clase 
            document.Add(new Paragraph("                       Lista de Productos comprados", FontFactory.GetFont("ARIAL BLACK", 20, iTextSharp.text.Font.BOLD)));

            document.Add(new Paragraph("\n"));
            document.Add(LlenarTabla2(detalles));

            document.Add(new Paragraph("\n"));
            Paragraph totalPagar = new Paragraph("Total pagar:" + factura.Totales + "\n");
            totalPagar.Alignment = Element.ALIGN_CENTER;
            document.Add(totalPagar);
            document.Add(new Paragraph("\n"));
            Paragraph saludo = new Paragraph("Gracias por su compra vuelva pronto\n");
            saludo.Alignment = Element.ALIGN_CENTER;
            document.Add(saludo);

            document.Close();

        }
        public PdfPTable LlenarTabla2(IList<DetalleFactura> detalles)
        {
            PdfPTable tabla = new PdfPTable(6);

            tabla.AddCell(new Paragraph("Productos_id"));
            tabla.AddCell(new Paragraph("Nombre"));
            tabla.AddCell(new Paragraph("Precio_venta"));
            tabla.AddCell(new Paragraph("Iva"));
            tabla.AddCell(new Paragraph("Sub_Total"));
            tabla.AddCell(new Paragraph("Total"));
            foreach (var item in detalles)
            {
                tabla.AddCell(item.productos.Productos_id);
                tabla.AddCell(item.productos.Nombre);
                tabla.AddCell(Convert.ToString(item.productos.Precio_venta));
                tabla.AddCell(Convert.ToString(item.Iva));
                tabla.AddCell(Convert.ToString(item.Subtotal));
                tabla.AddCell(Convert.ToString(item.Total));

            }

            return tabla;
        }
    }
}
