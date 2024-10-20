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

namespace UrbanFarmCO
{
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {

            // Verifica se todos os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                string.IsNullOrWhiteSpace(txtFornecedorID.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de adicionar o produto.");
                return;  // Sai do método se algum campo estiver vazio
            }

            // Connection string para o seu banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para inserir um novo produto
            string query = "INSERT INTO Produtos (NomeProduto, Categoria, Preco, Quantidade, FornecedorID, DataCadastro) " +
                           "VALUES (@NomeProduto, @Categoria, @Preco, @Quantidade, @FornecedorID, @DataCadastro)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Vincular os valores dos TextBoxes aos parâmetros corretos
                command.Parameters.AddWithValue("@NomeProduto", txtNomeProduto.Text);
                command.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                command.Parameters.AddWithValue("@Preco", Convert.ToDecimal(txtPreco.Text));  // Conversão para decimal
                command.Parameters.AddWithValue("@Quantidade", Convert.ToInt32(txtQuantidade.Text));  // Conversão para int
                command.Parameters.AddWithValue("@FornecedorID", Convert.ToInt32(txtFornecedorID.Text));  // Conversão para int
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);  // Usa a data atual para o cadastro

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Produto adicionado com sucesso!");
                    ExibirProdutos();  // Atualiza a lista de produtos
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                }


            }
        }

        private void btnAtualizarProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdutoID.Text))
            {
                MessageBox.Show("Por favor, selecione um produto para atualizar.");
                return;  // Sai do método se o ProdutoID não estiver preenchido
            }

            // Connection string para o banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para atualizar o produto
            string query = "UPDATE Produtos SET NomeProduto = @NomeProduto, Categoria = @Categoria, Preco = @Preco, Quantidade = @Quantidade, FornecedorID = @FornecedorID " +
                           "WHERE ProdutoID = @ProdutoID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Vincular os valores dos TextBoxes aos parâmetros corretos
                command.Parameters.AddWithValue("@NomeProduto", txtNomeProduto.Text);
                command.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                command.Parameters.AddWithValue("@Preco", Convert.ToDecimal(txtPreco.Text));  // Conversão para decimal
                command.Parameters.AddWithValue("@Quantidade", Convert.ToInt32(txtQuantidade.Text));  // Conversão para int
                command.Parameters.AddWithValue("@FornecedorID", Convert.ToInt32(txtFornecedorID.Text));  // Conversão para int
                command.Parameters.AddWithValue("@ProdutoID", Convert.ToInt32(txtProdutoID.Text));  // Necessário para identificar o produto

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produto atualizado com sucesso!");
                        ExibirProdutos();  // Atualiza a lista de produtos
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
                }
            }
        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdutoID.Text))
            {
                MessageBox.Show("Por favor, selecione um produto para remover.");
                return;  // Sai do método se o ProdutoID não estiver preenchido
            }

            // Connection string para o banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para remover o produto
            string query = "DELETE FROM Produtos WHERE ProdutoID = @ProdutoID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProdutoID", Convert.ToInt32(txtProdutoID.Text));  // Necessário para identificar o produto

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Produto removido com sucesso!");
                        ExibirProdutos();  // Atualiza a lista de produtos
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover produto: " + ex.Message);
                }
            }
        }

        private void btnExibirProdutos_Click(object sender, EventArgs e)
        {
            ExibirProdutos();

        }

        private void ExibirProdutos()
        {
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para exibir todos os produtos
            string query = "SELECT ProdutoID, NomeProduto, Categoria, Preco, Quantidade, FornecedorID, DataCadastro FROM Produtos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewProdutos.DataSource = dataTable;  // Exibe os produtos no DataGridView
            }
        }

        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewProdutos.Rows[e.RowIndex];

                txtProdutoID.Text = row.Cells["ProdutoID"].Value.ToString();
                txtNomeProduto.Text = row.Cells["NomeProduto"].Value.ToString();
                txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
                txtPreco.Text = row.Cells["Preco"].Value.ToString();
                txtQuantidade.Text = row.Cells["Quantidade"].Value.ToString();
                txtFornecedorID.Text = row.Cells["FornecedorID"].Value.ToString();
                dtpDataCadastro.Value = Convert.ToDateTime(row.Cells["DataCadastro"].Value);  // Preenche a data de cadastro
            }
        }

        private void txtProdutoID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
