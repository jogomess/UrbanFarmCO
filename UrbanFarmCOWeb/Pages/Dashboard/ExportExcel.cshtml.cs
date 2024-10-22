using OfficeOpenXml;
using UrbanFarmCOWeb.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace UrbanFarmCOWeb.Pages.Dashboard
{
    public class ExportExcelModel : PageModel
    {
        private readonly UrbanFarmDbContext _context;

        public ExportExcelModel(UrbanFarmDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Configura o contexto da licença
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Obtém os fornecedores do banco de dados
            var fornecedores = await _context.Fornecedores.ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Fornecedores");

                // Cabeçalhos
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Nome";
                worksheet.Cells[1, 3].Value = "CNPJ";
                worksheet.Cells[1, 4].Value = "Endereço";
                worksheet.Cells[1, 5].Value = "Telefone";
                worksheet.Cells[1, 6].Value = "Email";
                worksheet.Cells[1, 7].Value = "Data Cadastro";

                // Preencher os dados dos fornecedores
                for (int i = 0; i < fornecedores.Count; i++)
                {
                    var fornecedor = fornecedores[i];
                    worksheet.Cells[i + 2, 1].Value = fornecedor.FornecedorID;
                    worksheet.Cells[i + 2, 2].Value = fornecedor.Nome;
                    worksheet.Cells[i + 2, 3].Value = fornecedor.CNPJ;
                    worksheet.Cells[i + 2, 4].Value = fornecedor.Endereco;
                    worksheet.Cells[i + 2, 5].Value = fornecedor.Telefone;
                    worksheet.Cells[i + 2, 6].Value = fornecedor.Email;
                   
                }

                // Cria o arquivo Excel
                var fileName = $"Fornecedores_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                var content = package.GetAsByteArray();

                // Retorna o arquivo para download
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
