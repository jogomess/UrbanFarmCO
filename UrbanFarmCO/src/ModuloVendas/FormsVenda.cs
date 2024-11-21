using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanFarmCO.src.ModuloVendas
{
    public partial class FormsVenda : Form
    {
        public FormsVenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int produtoId = ((dynamic)ComboBoxProduto.SelectedItem).Value;
                int fornecedorId = ((dynamic)ComboBoxFornecedor.SelectedItem).Value;
                int quantidade = int.Parse(txtQuantidade.Text);
                decimal precoVenda = decimal.Parse(txtPreco.Text);
                string cliente = txtCliente.Text;

                using (SqlConnection conn = new SqlConnection("Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Vendas (ProdutoID, FornecedorID, Quantidade, PrecoVenda, Cliente) " +
                        "VALUES (@ProdutoID, @FornecedorID, @Quantidade, @PrecoVenda, @Cliente)", conn);
                    cmd.Parameters.AddWithValue("@ProdutoID", produtoId);
                    cmd.Parameters.AddWithValue("@FornecedorID", fornecedorId);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@PrecoVenda", precoVenda);
                    cmd.Parameters.AddWithValue("@Cliente", string.IsNullOrEmpty(cliente) ? (object)DBNull.Value : cliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Venda registrada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar venda: {ex.Message}");
            }
        }

        private void FormsVenda_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();

                    // Carregar Produtos
                    SqlCommand cmd = new SqlCommand("SELECT ProdutoID, NomeProduto FROM Produtos", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable produtos = new DataTable();
                    adapter.Fill(produtos);

                    ComboBoxProduto.DataSource = produtos; // Defina a tabela como fonte de dados
                    ComboBoxProduto.DisplayMember = "NomeProduto"; // Exibe o NomeProduto
                    ComboBoxProduto.ValueMember = "ProdutoID"; // Usa o ProdutoID como valor

                    cmd.CommandText = "SELECT FornecedorID, Nome FROM Fornecedores";
                    DataTable fornecedores = new DataTable();
                    adapter.SelectCommand = cmd; // Atualizar o comando para Fornecedores
                    adapter.Fill(fornecedores);

                    ComboBoxFornecedor.DataSource = fornecedores;
                    ComboBoxFornecedor.DisplayMember = "Nome"; // Nome do fornecedor a ser exibido
                    ComboBoxFornecedor.ValueMember = "FornecedorID"; // Valor associado ao item
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }
    }
}
