using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using ScinReport.Models;
//using System.IO.MemoryMappedFiles;
namespace ScinReport.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationContext _context;
        public ReportController(ApplicationContext context)
        {
            _context = context;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public void GeneratePDFTest()
        {
            FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.A4, 36, 72, 108, 180);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            
            // Setting Document properties e.g.
            // 1. Title
            // 2. Subject
            // 3. Keywords
            // 4. Creator
            // 5. Author
            // 6. Header
            doc.AddTitle("Hello World example");
            doc.AddSubject("This is an Example 4 of Chapter 1 of Book 'iText in Action'");
            doc.AddKeywords("Metadata, iTextSharp 5.4.4, Chapter 1");
            doc.AddCreator("iTextSharp 5.4.4");
            doc.AddAuthor("Top Coders");
            doc.AddHeader("Nothing", "No Header");
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
        }
        public void CreatePDF()
        {
            using (MemoryStream ms = new MemoryStream())
            using (Document document = new Document(PageSize.A4, 25, 25, 30, 30))
            using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
            {
                document.Open();
                document.Add(new Paragraph("Hello World"));
                document.Close();
                writer.Close();
                ms.Close();
                Response.ContentType = "pdf/application";
               // Response.AddHeader("content-disposition", "attachment;filename=First_PDF_document.pdf");
                //Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            }
        }
      

    }
}




