using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrbanFarmCOWeb.Data;

namespace UrbanFarmCOWeb.Pages.Dashboard
{
    public class ExportPdfModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        public ExportPdfModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var fornecedores = _context.Fornecedores.ToList();

            using (var stream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, stream);
                document.Open();
                document.Add(new Paragraph("Relatório de Fornecedores"));
                document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5);
                table.AddCell("Nome");
                table.AddCell("CNPJ");
                table.AddCell("Endereço");
                table.AddCell("Telefone");
                table.AddCell("Email");

                foreach (var fornecedor in fornecedores)
                {
                    table.AddCell(fornecedor.Nome);
                    table.AddCell(fornecedor.CNPJ);
                    table.AddCell(fornecedor.Endereco);
                    table.AddCell(fornecedor.Telefone);
                    table.AddCell(fornecedor.Email);
                }

                document.Add(table);
                document.Close();

                var content = stream.ToArray();
                return File(content, "application/pdf", "Fornecedores.pdf");
            }
        }
    }
}
