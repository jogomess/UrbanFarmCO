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
    public partial class FormsProdutos : Form
    {
        public FormsProdutos()
        {
            InitializeComponent();
        }


        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {


            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text) ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                string.IsNullOrWhiteSpace(txtFornecedorID.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Connection string para o seu banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Connect Timeout=30;Encrypt=True";

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
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);  // Define a data atual para o cadastro

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Produto adicionado com sucesso!");
                    ExibirProdutos();  // Atualiza a lista de produtos no DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                }


            }
        }
    }
}
