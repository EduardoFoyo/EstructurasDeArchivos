namespace EstructurasArchivos
{
    partial class IndiceSecundario
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
            this.tablaIndice = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indiceRegistro = new System.Windows.Forms.DataGridView();
            this.Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaIndice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indiceRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaIndice
            // 
            this.tablaIndice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaIndice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tablaIndice.Location = new System.Drawing.Point(12, 12);
            this.tablaIndice.Name = "tablaIndice";
            this.tablaIndice.RowHeadersWidth = 51;
            this.tablaIndice.RowTemplate.Height = 24;
            this.tablaIndice.Size = new System.Drawing.Size(307, 426);
            this.tablaIndice.TabIndex = 1;
            this.tablaIndice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaIndice_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Dato";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direccion";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // indiceRegistro
            // 
            this.indiceRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indiceRegistro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Indice});
            this.indiceRegistro.Location = new System.Drawing.Point(325, 12);
            this.indiceRegistro.Name = "indiceRegistro";
            this.indiceRegistro.RowHeadersWidth = 51;
            this.indiceRegistro.RowTemplate.Height = 24;
            this.indiceRegistro.Size = new System.Drawing.Size(183, 426);
            this.indiceRegistro.TabIndex = 2;
            // 
            // Indice
            // 
            this.Indice.HeaderText = "Direccion";
            this.Indice.MinimumWidth = 6;
            this.Indice.Name = "Indice";
            this.Indice.Width = 125;
            // 
            // IndiceSecundario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 450);
            this.Controls.Add(this.indiceRegistro);
            this.Controls.Add(this.tablaIndice);
            this.Name = "IndiceSecundario";
            this.Text = "IndiceSecundario";
            this.Load += new System.EventHandler(this.IndiceSecundario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaIndice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indiceRegistro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView indiceRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indice;
    }
}