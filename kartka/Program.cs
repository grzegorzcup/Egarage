using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace kartka
{
    class Program
    {
        static void GeneratePDF()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Kartka";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 20);

            gfx.DrawString("Wtorek 21.10", font, XBrushes.Black,
                new XPoint(300, 20),XStringFormat.Center);

            font = new XFont("Arial", 15);

            gfx.DrawString("1 garaż", font, XBrushes.Black,
                new XPoint(10, 50));

            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkGray)), new XPoint(0, 55), new XPoint(1000, 55));

            gfx.DrawString("2 garaż", font, XBrushes.Gray,
                new XPoint(10, 75));

            document.Save("C:\\Users\\grzes\\Desktop\\Nowy folder\\Egarage\\test.pdf");

        }

        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            GeneratePDF();

        }
    }
}