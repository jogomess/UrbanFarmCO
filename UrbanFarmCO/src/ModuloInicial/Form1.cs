using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ClosedXML.Excel;
using System.Data.SqlClient;


namespace UrbanFarmCO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário já está aberto
            FormFornecedores formFornecedores = new FormFornecedores();
            formFornecedores.MdiParent = this;  // Define Form1 como o MDI Parent
            formFornecedores.Show();

        
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FormFornecedores)
                {
                    frm.BringToFront();  // Traz a janela existente para frente
                    return;
                }
            }

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se o formulário de produtos já está aberto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FormProdutos)
                {
                    frm.BringToFront();  // Traz o formulário para a frente se já estiver aberto
                    return;
                }
            }

            // Se o formulário de produtos não estiver aberto, cria uma nova instância
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.MdiParent = this;  // Define Form1 como o MDI Parent
            formProdutos.Show();
        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solicita a senha ao usuário
            string senhaDigitada = Prompt.ShowDialog("Digite sua senha para acessar a aba de colaboradores:", "Verificação de Acesso");

            // Verifica o usuário e a senha (você pode fazer isso comparando com o banco de dados também)
            if (VerificarAcesso(senhaDigitada))
            {
                // Se a verificação for bem-sucedida, abrir o FormColaboradores
                FormColaboradores formColaboradores = new FormColaboradores();
                formColaboradores.MdiParent = this;  // Se estiver usando MDI
                formColaboradores.Show();
            }
            else
            {
                MessageBox.Show("Acesso negado. Você não tem permissão para acessar esta área.");
            }

        }
        private bool VerificarAcesso(string senha)
        {
            // Lista de usuários e suas senhas - você pode verificar isso diretamente no banco de dados
            string usuarioGerenteTI = "jogomes10";
            string usuarioDBA = "matheus10";

            // Verifica se a senha é de um usuário autorizado
            if (senha == usuarioGerenteTI || senha == usuarioDBA)
            {
                return true;  // Acesso permitido
            }

            return false;  // Acesso negado
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    Text = caption
                };

                Label lblText = new Label() { Left = 50, Top = 20, Text = text };
                TextBox txtInput = new TextBox() { Left = 50, Top = 50, Width = 400, PasswordChar = '*' };  // Campo de senha
                Button btnOk = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70 };

                btnOk.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(lblText);
                prompt.Controls.Add(txtInput);
                prompt.Controls.Add(btnOk);
                prompt.ShowDialog();

                return txtInput.Text;  // Retorna a senha digitada
            }
        }

        private void relatórioFornecedorEmExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para puxar os dados do banco
            string query = "SELECT FornecedorID, Nome, CNPJ, Endereco, Telefone, Email FROM Fornecedores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Preencher o DataTable com os dados do banco
                adapter.Fill(dataTable);

                // Criar um novo documento Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Relatório de Fornecedores");

                    // Adicionar cabeçalhos
                    worksheet.Cell(1, 1).Value = "FornecedorID";
                    worksheet.Cell(1, 2).Value = "Nome";
                    worksheet.Cell(1, 3).Value = "CNPJ";
                    worksheet.Cell(1, 4).Value = "Endereço";
                    worksheet.Cell(1, 5).Value = "Telefone";
                    worksheet.Cell(1, 6).Value = "Email";

                    // Adicionar os dados
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = Convert.ToString(dataTable.Rows[i]["FornecedorID"]);
                        worksheet.Cell(i + 2, 2).Value = Convert.ToString(dataTable.Rows[i]["Nome"]);
                        worksheet.Cell(i + 2, 3).Value = Convert.ToString(dataTable.Rows[i]["CNPJ"]);
                        worksheet.Cell(i + 2, 4).Value = Convert.ToString(dataTable.Rows[i]["Endereco"]);
                        worksheet.Cell(i + 2, 5).Value = Convert.ToString(dataTable.Rows[i]["Telefone"]);
                        worksheet.Cell(i + 2, 6).Value = Convert.ToString(dataTable.Rows[i]["Email"]);
                    }

                    // Salvar o arquivo Excel
                    workbook.SaveAs("Relatorio_Fornecedores.xlsx");
                }
            }

            MessageBox.Show("Relatório de Fornecedores em Excel gerado com sucesso!");

        }

        private void relatórioFornecedorEmPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para puxar os dados do banco
            string query = "SELECT FornecedorID, Nome, CNPJ, Endereco, Telefone, Email FROM Fornecedores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Criação do documento PDF
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("Relatorio_Fornecedores.pdf", FileMode.Create));

                // Abrir o documento para inserção de conteúdo
                document.Open();

                // Título do documento
                document.Add(new Paragraph("Relatório de Fornecedores"));
                document.Add(new Paragraph(" ")); // Linha em branco

                // Criar uma tabela no PDF
                PdfPTable table = new PdfPTable(6); // 6 colunas para os dados do Fornecedor

                // Adicionar cabeçalhos
                table.AddCell("FornecedorID");
                table.AddCell("Nome");
                table.AddCell("CNPJ");
                table.AddCell("Endereço");
                table.AddCell("Telefone");
                table.AddCell("Email");

                // Adicionar os dados
                while (reader.Read())
                {
                    table.AddCell(reader["FornecedorID"].ToString());
                    table.AddCell(reader["Nome"].ToString());
                    table.AddCell(reader["CNPJ"].ToString());
                    table.AddCell(reader["Endereco"].ToString());
                    table.AddCell(reader["Telefone"].ToString());
                    table.AddCell(reader["Email"].ToString());
                }

                // Adicionar a tabela ao documento
                document.Add(table);

                // Fechar o documento
                document.Close();
                reader.Close();
            }

            MessageBox.Show("Relatório de Fornecedores em PDF gerado com sucesso!");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close(); // Fecha o Form1
        }
    }
}

