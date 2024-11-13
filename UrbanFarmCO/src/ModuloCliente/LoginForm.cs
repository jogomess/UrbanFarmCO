using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UrbanFarmCO
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEsqueciSenha_Click(object sender, EventArgs e)
        {
            ResetPasswordForm resetForm = new ResetPasswordForm();
            resetForm.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Conexão com o banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para verificar o login usando o email
            string query = "SELECT COUNT(1) FROM Funcionarios WHERE Email = @Email AND SenhaHash = @SenhaHash";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Atualize para usar o campo de texto do email
                command.Parameters.AddWithValue("@Email", txtUsuario.Text);
                command.Parameters.AddWithValue("@SenhaHash", txtSenha.Text); // Usando senha simples

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        // Se o login for bem-sucedido, abrir a tela principal
                        MessageBox.Show("Login bem-sucedido!");

                        // Abrir o formulário principal
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide(); // Esconder o formulário de login
                    }
                    else
                    {
                        MessageBox.Show("Email ou senha inválidos!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';  // Mostra a senha
            }
            else
            {
                txtSenha.PasswordChar = '*';  // Oculta a senha
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCadastroColaborador formCadastro = new FormCadastroColaborador();
            formCadastro.Show();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            // Qualquer lógica adicional para o campo de texto de email, se necessário
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
