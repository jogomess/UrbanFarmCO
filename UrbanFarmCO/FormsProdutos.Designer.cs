namespace UrbanFarmCO
{
    partial class FormsProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormsProdutos
            // 
            this.ClientSize = new System.Drawing.Size(1115, 738);
            this.Name = "FormsProdutos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProdutoID;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblFornecedorID;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnAtualizarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.Button btnExibirProdutos;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.TextBox txtProdutoID;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtFornecedorID;
        private System.Windows.Forms.TextBox textBox7;
    }
}