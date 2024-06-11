using DocumentFormat.OpenXml.ExtendedProperties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TravelerCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "StatikPdfRaporu.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document= new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);


            document.Open();
            Paragraph paragraph= new Paragraph("Traveler Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/StatikPdfRaporu.pdf", "application/pdf", "StatikPdfRaporu.pdf");
        }


        //
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "StatikPdfRaporu2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);


            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Oğuzhan");
            pdfPTable.AddCell("Güney");
            pdfPTable.AddCell("12345678909");
            pdfPTable.AddCell("Alican");
            pdfPTable.AddCell("Sarıboğa");
            pdfPTable.AddCell("52345678909");
            pdfPTable.AddCell("Mert");
            pdfPTable.AddCell("Demir");
            pdfPTable.AddCell("62345678909");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/StatikPdfRaporu2.pdf", "application/pdf", "StatikPdfRaporu2.pdf");
        }
    }
}
