namespace UrbanFarmCO.src.ModuloVendas
{
    partial class FormsVenda
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ComboBoxProduto = new System.Windows.Forms.ComboBox();
            this.ComboBoxFornecedor = new System.Windows.Forms.ComboBox();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblFornecedores = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(99, 308);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar Venda";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(99, 347);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ComboBoxProduto
            // 
            this.ComboBoxProduto.FormattingEnabled = true;
            this.ComboBoxProduto.Location = new System.Drawing.Point(184, 124);
            this.ComboBoxProduto.Name = "ComboBoxProduto";
            this.ComboBoxProduto.Size = new System.Drawing.Size(208, 24);
            this.ComboBoxProduto.TabIndex = 2;
            // 
            // ComboBoxFornecedor
            // 
            this.ComboBoxFornecedor.FormattingEnabled = true;
            this.ComboBoxFornecedor.Location = new System.Drawing.Point(184, 163);
            this.ComboBoxFornecedor.Name = "ComboBoxFornecedor";
            this.ComboBoxFornecedor.Size = new System.Drawing.Size(208, 24);
            this.ComboBoxFornecedor.TabIndex = 3;
            // 
            // lblProdutos
            // 
            this.lblProdutos.AutoSize = true;
            this.lblProdutos.Location = new System.Drawing.Point(114, 132);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(64, 16);
            this.lblProdutos.TabIndex = 4;
            this.lblProdutos.Text = "Produtos:";
            // 
            // lblFornecedores
            // 
            this.lblFornecedores.AutoSize = true;
            this.lblFornecedores.Location = new System.Drawing.Point(83, 166);
            this.lblFornecedores.Name = "lblFornecedores";
            this.lblFornecedores.Size = new System.Drawing.Size(95, 16);
            this.lblFornecedores.TabIndex = 5;
            this.lblFornecedores.Text = "Fornecedores:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(96, 193);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(80, 16);
            this.lblQuantidade.TabIndex = 6;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(128, 249);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 16);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(184, 193);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(208, 22);
            this.txtQuantidade.TabIndex = 8;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(184, 249);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(208, 22);
            this.txtCliente.TabIndex = 9;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(130, 221);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(46, 16);
            this.lblPreco.TabIndex = 10;
            this.lblPreco.Text = "Preço:";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(184, 218);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(208, 22);
            this.txtPreco.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UrbanFarmCO.Properties.Resources.Captura_de_tela_2024_10_16_165655_removebg_preview_png;
            this.pictureBox1.Location = new System.Drawing.Point(435, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 259);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FormsVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblFornecedores);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.ComboBoxFornecedor);
            this.Controls.Add(this.ComboBoxProduto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Name = "FormsVenda";
            this.Text = "FormsVenda";
            this.Load += new System.EventHandler(this.FormsVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox ComboBoxProduto;
        private System.Windows.Forms.ComboBox ComboBoxFornecedor;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblFornecedores;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}