using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UrbanFarmCO
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dados de conexão ao banco de dados
            string connectionString = "Data Source=NITRO_5\\SQLEXPRESS;Initial Catalog=UrbanFarmCO;Integrated Security=True;Encrypt=False";

            // Query para atualizar a senha
            string query = "UPDATE Funcionarios SET SenhaHash = @NovaSenha WHERE Nome = @Usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                command.Parameters.AddWithValue("@NovaSenha", txtNovaSenha.Text);  // Use hashing aqui em um sistema real

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Senha redefinida com sucesso! Você pode fazer login agora.");
                        this.Close(); // Fecha a janela de redefinição de senha
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }


            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
