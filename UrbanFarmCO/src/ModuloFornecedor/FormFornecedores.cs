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
    public partial class FormFornecedores : Form
    {
        public FormFornecedores()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewFornecedores.Rows[e.RowIndex];

                // Preenche os campos do formulário com os dados do fornecedor selecionado
                txtFornecedorID.Text = row.Cells["FornecedorID"].Value.ToString();
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtCNPJ.Text = row.Cells["CNPJ"].Value.ToString();
                txtEndereco.Text = row.Cells["Endereco"].Value.ToString();
                txtTelefone.Text = row.Cells["Telefone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Verifica se todos os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCNPJ.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de adicionar o fornecedor.");
                return;  // Sai do método se algum campo estiver vazio
            }



            // Connection string para o seu banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para inserir um novo fornecedor
            string query = "INSERT INTO Fornecedores (Nome, CNPJ, Endereco, Telefone, Email) " +
                   "VALUES (@Nome, @CNPJ, @Endereco, @Telefone, @Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nome", txtNome.Text);
                command.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text);
                command.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                command.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor adicionado com sucesso!");
                    ExibirFornecedores();  // Atualiza a lista de fornecedores
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar fornecedor: " + ex.Message);
                }


            }
        }

        private void txtEndereço_Click(object sender, EventArgs e)
        {

        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            ExibirFornecedores();
        }

        private void ExibirFornecedores()
        {
            // Connection string para o Banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // query para exibir todos os Fornecedores
            string query = "SELECT * FROM Fornecedores";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewFornecedores.DataSource = dataTable; // Exibe os fornecedores no DataGridView

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFornecedorID.Text))
            {
                MessageBox.Show("Por favor, insira um FornecedorID válido para remover o fornecedor.");
                return;  // Sai do método se o FornecedorID estiver vazio ou inválido
            }

            try
            {
                int fornecedorID = Convert.ToInt32(txtFornecedorID.Text);  // Tenta converter o FornecedorID para um número inteiro
            }
            catch (FormatException)
            {
                MessageBox.Show("FornecedorID inválido. Insira um número válido.");
                return;  // Sai do método se o FornecedorID não for um número válido
            }

            // Connection string para o seu banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para remover um fornecedor
            string query = "DELETE FROM Fornecedores WHERE FornecedorID = @FornecedorID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FornecedorID", Convert.ToInt32(txtFornecedorID.Text));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Fornecedor removido com sucesso!");
                        ExibirFornecedores();  // Atualiza a lista de fornecedores
                    }
                    else
                    {
                        MessageBox.Show("Fornecedor não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover fornecedor: " + ex.Message);
                }

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFornecedorID.Text))
            {
                MessageBox.Show("Por favor, selecione um fornecedor para atualizar.");
                return;  // Sai do método se o FornecedorID não estiver preenchido
            }

            try
            {
                int fornecedorID = Convert.ToInt32(txtFornecedorID.Text);  // Tenta converter o FornecedorID para um número inteiro
            }
            catch (FormatException)
            {
                MessageBox.Show("FornecedorID inválido. Insira um número válido.");
                return;  // Sai do método se o FornecedorID não for um número válido
            }


            // Connection string para o seu banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query base para atualizar o fornecedor
            string query = "UPDATE Fornecedores SET ";
            List<string> updates = new List<string>();  // Armazena os campos que serão atualizados

            // Verifica se cada campo foi preenchido
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                updates.Add("Nome = @Nome");
            }

            if (!string.IsNullOrWhiteSpace(txtCNPJ.Text))
            {
                updates.Add("CNPJ = @CNPJ");
            }

            if (!string.IsNullOrWhiteSpace(txtEndereco.Text))
            {
                updates.Add("Endereco = @Endereco");
            }

            if (!string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                updates.Add("Telefone = @Telefone");
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                updates.Add("Email = @Email");
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("Nenhuma alteração foi feita.");
                return;
            }

            // Junta os campos que precisam ser atualizados na query
            query += string.Join(", ", updates) + " WHERE FornecedorID = @FornecedorID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Adiciona os parâmetros apenas para os campos que serão atualizados
                if (!string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    command.Parameters.AddWithValue("@Nome", txtNome.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtCNPJ.Text))
                {
                    command.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    command.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtTelefone.Text))
                {
                    command.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                }

                command.Parameters.AddWithValue("@FornecedorID", Convert.ToInt32(txtFornecedorID.Text));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Fornecedor atualizado com sucesso!");
                        ExibirFornecedores();  // Atualiza a lista de fornecedores
                    }
                    else
                    {
                        MessageBox.Show("Fornecedor não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar fornecedor: " + ex.Message);
                }

            }
        }
    }
}