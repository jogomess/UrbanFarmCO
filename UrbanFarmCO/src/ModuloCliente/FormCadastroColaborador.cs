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
    public partial class FormCadastroColaborador : Form
    {
        public FormCadastroColaborador()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
        string.IsNullOrWhiteSpace(txtCPF.Text) ||
        string.IsNullOrWhiteSpace(txtEmail.Text) ||
        string.IsNullOrWhiteSpace(txtFuncao.Text) ||
        string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";
            string query = "INSERT INTO Funcionarios (Nome, CPF, DataNascimento, Email, Funcao, SenhaHash, DataCadastro) " +
                   "VALUES (@Nome, @CPF, @DataNascimento, @Email, @Funcao, @SenhaHash, @DataCadastro)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Adicionar os parâmetros da query
                command.Parameters.AddWithValue("@Nome", txtNome.Text);
                command.Parameters.AddWithValue("@CPF", txtCPF.Text);
                command.Parameters.AddWithValue("@DataNascimento", txtDataNascimento.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Funcao", txtFuncao.Text);

                // Simples hash para fins de demonstração (use um algoritmo mais seguro como bcrypt em produção)
                command.Parameters.AddWithValue("@SenhaHash", txtSenha.Text);  // Substitua por um hash de senha

                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now); // Data atual

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Colaborador cadastrado com sucesso!");
                    LimparCampos();  // Função para limpar os campos do formulário após o cadastro
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar colaborador: " + ex.Message);
                }
            }

        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtFuncao.Clear();
            txtSenha.Clear();
            txtDataNascimento.Clear();
        }

        private bool ValidarCPF(string cpf)
        {
            // Remover pontos e traços do CPF
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verificar se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Implementar a lógica de validação de CPF aqui (caso necessário)

            return true;
        }

        private void txtFuncionarioID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
