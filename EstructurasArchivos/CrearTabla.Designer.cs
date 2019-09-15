namespace EstructurasArchivos
{
    partial class CrearTabla
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
            this.label1 = new System.Windows.Forms.Label();
            this.nombreEntidad = new System.Windows.Forms.TextBox();
            this.nombreAtributo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoAtributo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.longitudAtributo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tipoIndiceAtributo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.entidadesBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.agregarAtributo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Entidad";
            // 
            // nombreEntidad
            // 
            this.nombreEntidad.Location = new System.Drawing.Point(142, 64);
            this.nombreEntidad.Name = "nombreEntidad";
            this.nombreEntidad.Size = new System.Drawing.Size(305, 22);
            this.nombreEntidad.TabIndex = 1;
            // 
            // nombreAtributo
            // 
            this.nombreAtributo.Location = new System.Drawing.Point(25, 203);
            this.nombreAtributo.Name = "nombreAtributo";
            this.nombreAtributo.Size = new System.Drawing.Size(100, 22);
            this.nombreAtributo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // tipoAtributo
            // 
            this.tipoAtributo.FormattingEnabled = true;
            this.tipoAtributo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.tipoAtributo.Location = new System.Drawing.Point(173, 201);
            this.tipoAtributo.Name = "tipoAtributo";
            this.tipoAtributo.Size = new System.Drawing.Size(121, 24);
            this.tipoAtributo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo";
            // 
            // longitudAtributo
            // 
            this.longitudAtributo.Location = new System.Drawing.Point(343, 201);
            this.longitudAtributo.Name = "longitudAtributo";
            this.longitudAtributo.Size = new System.Drawing.Size(113, 22);
            this.longitudAtributo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Longitud";
            // 
            // tipoIndiceAtributo
            // 
            this.tipoIndiceAtributo.FormattingEnabled = true;
            this.tipoIndiceAtributo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.tipoIndiceAtributo.Location = new System.Drawing.Point(512, 199);
            this.tipoIndiceAtributo.Name = "tipoIndiceAtributo";
            this.tipoIndiceAtributo.Size = new System.Drawing.Size(121, 24);
            this.tipoIndiceAtributo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo Indice";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Agregar Entidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // entidadesBox
            // 
            this.entidadesBox.FormattingEnabled = true;
            this.entidadesBox.Location = new System.Drawing.Point(694, 199);
            this.entidadesBox.Name = "entidadesBox";
            this.entidadesBox.Size = new System.Drawing.Size(121, 24);
            this.entidadesBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(691, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Elige Entidad";
            // 
            // agregarAtributo
            // 
            this.agregarAtributo.Location = new System.Drawing.Point(854, 197);
            this.agregarAtributo.Name = "agregarAtributo";
            this.agregarAtributo.Size = new System.Drawing.Size(145, 26);
            this.agregarAtributo.TabIndex = 13;
            this.agregarAtributo.Text = "Agregar Atributo";
            this.agregarAtributo.UseVisualStyleBackColor = true;
            this.agregarAtributo.Click += new System.EventHandler(this.AgregarAtributo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1088, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 46);
            this.button2.TabIndex = 14;
            this.button2.Text = "Crear Tabla ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CrearTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 250);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.agregarAtributo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.entidadesBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tipoIndiceAtributo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.longitudAtributo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoAtributo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreAtributo);
            this.Controls.Add(this.nombreEntidad);
            this.Controls.Add(this.label1);
            this.Name = "CrearTabla";
            this.Text = "CrearTabla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreEntidad;
        private System.Windows.Forms.TextBox nombreAtributo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoAtributo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox longitudAtributo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tipoIndiceAtributo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox entidadesBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button agregarAtributo;
        private System.Windows.Forms.Button button2;
    }
}