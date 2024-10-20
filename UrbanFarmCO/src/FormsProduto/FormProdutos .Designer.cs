namespace UrbanFarmCO
{
    partial class FormProdutos
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
            this.lblProdutoID = new System.Windows.Forms.Label();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblFornecedorID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtFornecedorID = new System.Windows.Forms.TextBox();
            this.dataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnAtualizarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.btnExibirProdutos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProdutoID
            // 
            this.lblProdutoID.AutoSize = true;
            this.lblProdutoID.Location = new System.Drawing.Point(155, 68);
            this.lblProdutoID.Name = "lblProdutoID";
            this.lblProdutoID.Size = new System.Drawing.Size(70, 16);
            this.lblProdutoID.TabIndex = 0;
            this.lblProdutoID.Text = "ProdutoID:";
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Location = new System.Drawing.Point(109, 109);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(116, 16);
            this.lblNomeProduto.TabIndex = 1;
            this.lblNomeProduto.Text = "Nome do Produto:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(155, 143);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 16);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria:";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(178, 177);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(46, 16);
            this.lblPreco.TabIndex = 3;
            this.lblPreco.Text = "Preço:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(145, 213);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(80, 16);
            this.lblQuantidade.TabIndex = 4;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // lblFornecedorID
            // 
            this.lblFornecedorID.AutoSize = true;
            this.lblFornecedorID.Location = new System.Drawing.Point(131, 248);
            this.lblFornecedorID.Name = "lblFornecedorID";
            this.lblFornecedorID.Size = new System.Drawing.Size(93, 16);
            this.lblFornecedorID.TabIndex = 5;
            this.lblFornecedorID.Text = "FornecedorID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Data de Cadastro:";
            // 
            // dtpDataCadastro
            // 
            this.dtpDataCadastro.Location = new System.Drawing.Point(231, 29);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(270, 22);
            this.dtpDataCadastro.TabIndex = 7;
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.Location = new System.Drawing.Point(241, 68);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.Size = new System.Drawing.Size(114, 22);
            this.txtProdutoID.TabIndex = 8;
            this.txtProdutoID.TextChanged += new System.EventHandler(this.txtProdutoID_TextChanged);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(241, 109);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(114, 22);
            this.txtNomeProduto.TabIndex = 9;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(241, 143);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(114, 22);
            this.txtCategoria.TabIndex = 10;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(241, 174);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(114, 22);
            this.txtPreco.TabIndex = 11;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(241, 210);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(114, 22);
            this.txtQuantidade.TabIndex = 12;
            // 
            // txtFornecedorID
            // 
            this.txtFornecedorID.Location = new System.Drawing.Point(241, 248);
            this.txtFornecedorID.Name = "txtFornecedorID";
            this.txtFornecedorID.Size = new System.Drawing.Size(114, 22);
            this.txtFornecedorID.TabIndex = 13;
            // 
            // dataGridViewProdutos
            // 
            this.dataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdutos.Location = new System.Drawing.Point(423, 71);
            this.dataGridViewProdutos.Name = "dataGridViewProdutos";
            this.dataGridViewProdutos.RowHeadersWidth = 51;
            this.dataGridViewProdutos.RowTemplate.Height = 24;
            this.dataGridViewProdutos.Size = new System.Drawing.Size(281, 199);
            this.dataGridViewProdutos.TabIndex = 14;
            this.dataGridViewProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProdutos_CellContentClick);
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(134, 290);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(125, 23);
            this.btnAdicionarProduto.TabIndex = 15;
            this.btnAdicionarProduto.Text = "Adicionar Produto";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // btnAtualizarProduto
            // 
            this.btnAtualizarProduto.Location = new System.Drawing.Point(132, 328);
            this.btnAtualizarProduto.Name = "btnAtualizarProduto";
            this.btnAtualizarProduto.Size = new System.Drawing.Size(125, 23);
            this.btnAtualizarProduto.TabIndex = 16;
            this.btnAtualizarProduto.Text = "Atualizar Produto";
            this.btnAtualizarProduto.UseVisualStyleBackColor = true;
            this.btnAtualizarProduto.Click += new System.EventHandler(this.btnAtualizarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(281, 290);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(124, 23);
            this.btnRemoverProduto.TabIndex = 17;
            this.btnRemoverProduto.Text = "Remover Produto";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // btnExibirProdutos
            // 
            this.btnExibirProdutos.Location = new System.Drawing.Point(281, 328);
            this.btnExibirProdutos.Name = "btnExibirProdutos";
            this.btnExibirProdutos.Size = new System.Drawing.Size(124, 23);
            this.btnExibirProdutos.TabIndex = 18;
            this.btnExibirProdutos.Text = "Exibir Produtos";
            this.btnExibirProdutos.UseVisualStyleBackColor = true;
            this.btnExibirProdutos.Click += new System.EventHandler(this.btnExibirProdutos_Click);
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExibirProdutos);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnAtualizarProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.dataGridViewProdutos);
            this.Controls.Add(this.txtFornecedorID);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.txtProdutoID);
            this.Controls.Add(this.dtpDataCadastro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFornecedorID);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.lblProdutoID);
            this.Name = "FormProdutos";
            this.Text = "FormProdutos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProdutoID;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblFornecedorID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        private System.Windows.Forms.TextBox txtProdutoID;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtFornecedorID;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnAtualizarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.Button btnExibirProdutos;
    }
}