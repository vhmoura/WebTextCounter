namespace TextCounter
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFetch = new System.Windows.Forms.Button();
            this.edtWebAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdTextCounter = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdTextCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(466, 25);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 20);
            this.btnFetch.TabIndex = 0;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            // 
            // edtWebAddress
            // 
            this.edtWebAddress.Location = new System.Drawing.Point(34, 25);
            this.edtWebAddress.Name = "edtWebAddress";
            this.edtWebAddress.Size = new System.Drawing.Size(426, 20);
            this.edtWebAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Web address";
            // 
            // grdTextCounter
            // 
            this.grdTextCounter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTextCounter.Location = new System.Drawing.Point(34, 72);
            this.grdTextCounter.Name = "grdTextCounter";
            this.grdTextCounter.Size = new System.Drawing.Size(426, 283);
            this.grdTextCounter.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 367);
            this.Controls.Add(this.grdTextCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtWebAddress);
            this.Controls.Add(this.btnFetch);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Text Counter";
            ((System.ComponentModel.ISupportInitialize)(this.grdTextCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.TextBox edtWebAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdTextCounter;
    }
}

