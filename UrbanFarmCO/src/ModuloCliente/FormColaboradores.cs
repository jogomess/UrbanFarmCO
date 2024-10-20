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
    public partial class FormColaboradores : Form
    {
        public FormColaboradores()
        {
            InitializeComponent();
        }

        private void btnExibirColaboradores_Click(object sender, EventArgs e)
        {
            ExibirColaboradores();
        }
        private void ExibirColaboradores()
        {
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            string query = "SELECT FuncionarioID, Nome, CPF, DataNascimento, Email, Funcao, DataCadastro FROM Funcionarios";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewColaboradores.DataSource = dataTable;  // Exibe os colaboradores no DataGridView
            }
        }

        private void dataGridViewColaboradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewColaboradores.Rows[e.RowIndex];

                txtFuncionarioID.Text = row.Cells["FuncionarioID"].Value.ToString();
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtCPF.Text = row.Cells["CPF"].Value.ToString();
                txtDataNascimento.Text = row.Cells["DataNascimento"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtFuncao.Text = row.Cells["Funcao"].Value.ToString();
                txtDataCadastro.Text = row.Cells["DataCadastro"].Value.ToString();
            }
        }

        private void btnAtualizarColaborador_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFuncionarioID.Text))
            {
                MessageBox.Show("Por favor, selecione um colaborador para atualizar.");
                return;
            }

            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "UPDATE Funcionarios SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Email = @Email, Funcao = @Funcao, SenhaHash = @SenhaHash " +
                           "WHERE FuncionarioID = @FuncionarioID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Vincula os valores dos campos aos parâmetros SQL
                command.Parameters.AddWithValue("@Nome", txtNome.Text);
                command.Parameters.AddWithValue("@CPF", txtCPF.Text);
                command.Parameters.AddWithValue("@DataNascimento", txtDataNascimento.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Funcao", txtFuncao.Text);
                command.Parameters.AddWithValue("@SenhaHash", txtSenha.Text);  // Lembre-se de tratar a senha com hash
                command.Parameters.AddWithValue("@FuncionarioID", Convert.ToInt32(txtFuncionarioID.Text));
                command.Parameters.AddWithValue("@DataCadastro", txtDataCadastro.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Colaborador atualizado com sucesso!");
                        ExibirColaboradores();  // Atualiza a lista de colaboradores
                    }
                    else
                    {
                        MessageBox.Show("Colaborador não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar colaborador: " + ex.Message);
                }
            }
        }

        private void btnExcluirColaborador_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFuncionarioID.Text))
            {
                MessageBox.Show("Por favor, selecione um colaborador para remover.");
                return;
            }

            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            string query = "DELETE FROM Funcionarios WHERE FuncionarioID = @FuncionarioID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FuncionarioID", Convert.ToInt32(txtFuncionarioID.Text));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Colaborador removido com sucesso!");
                        ExibirColaboradores();  // Atualiza a lista de colaboradores
                    }
                    else
                    {
                        MessageBox.Show("Colaborador não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao remover colaborador: " + ex.Message);
                }
            }
        }
    }
}
