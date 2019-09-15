namespace EstructurasArchivos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.crearTabla = new System.Windows.Forms.Button();
            this.createFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.label_entidad_nombre = new System.Windows.Forms.Label();
            this.entityText = new System.Windows.Forms.TextBox();
            this.addEntity = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoAtributo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreAtributo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoIndiceAtributo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.longitudAtributo = new System.Windows.Forms.TextBox();
            this.agregarAtributo = new System.Windows.Forms.Button();
            this.entidades = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sig_entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atributos = new System.Windows.Forms.DataGridView();
            this.id_atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sig_atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeFile = new System.Windows.Forms.Button();
            this.cargarDatos = new System.Windows.Forms.Button();
            this.typeAtributo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.entidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atributos)).BeginInit();
            this.SuspendLayout();
            // 
            // crearTabla
            // 
            this.crearTabla.Location = new System.Drawing.Point(1063, 12);
            this.crearTabla.Name = "crearTabla";
            this.crearTabla.Size = new System.Drawing.Size(273, 51);
            this.crearTabla.TabIndex = 0;
            this.crearTabla.Text = "Crear Tabla";
            this.crearTabla.UseVisualStyleBackColor = true;
            this.crearTabla.Click += new System.EventHandler(this.CrearTabla_Click);
            // 
            // createFile
            // 
            this.createFile.Location = new System.Drawing.Point(12, 12);
            this.createFile.Name = "createFile";
            this.createFile.Size = new System.Drawing.Size(75, 23);
            this.createFile.TabIndex = 2;
            this.createFile.Text = "Crear";
            this.createFile.UseVisualStyleBackColor = true;
            this.createFile.Click += new System.EventHandler(this.CreateFile_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(105, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 3;
            this.openFile.Text = "Abrir";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // label_entidad_nombre
            // 
            this.label_entidad_nombre.AutoSize = true;
            this.label_entidad_nombre.Location = new System.Drawing.Point(13, 65);
            this.label_entidad_nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_entidad_nombre.Name = "label_entidad_nombre";
            this.label_entidad_nombre.Size = new System.Drawing.Size(114, 17);
            this.label_entidad_nombre.TabIndex = 10;
            this.label_entidad_nombre.Text = "Nombre Entidad:";
            // 
            // entityText
            // 
            this.entityText.Location = new System.Drawing.Point(135, 62);
            this.entityText.Margin = new System.Windows.Forms.Padding(4);
            this.entityText.Name = "entityText";
            this.entityText.Size = new System.Drawing.Size(132, 22);
            this.entityText.TabIndex = 9;
            // 
            // addEntity
            // 
            this.addEntity.Location = new System.Drawing.Point(285, 57);
            this.addEntity.Name = "addEntity";
            this.addEntity.Size = new System.Drawing.Size(75, 32);
            this.addEntity.TabIndex = 11;
            this.addEntity.Text = "Agregar";
            this.addEntity.UseVisualStyleBackColor = true;
            this.addEntity.Click += new System.EventHandler(this.AddEntity_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tipo";
            // 
            // tipoAtributo
            // 
            this.tipoAtributo.FormattingEnabled = true;
            this.tipoAtributo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.tipoAtributo.Location = new System.Drawing.Point(514, 57);
            this.tipoAtributo.Name = "tipoAtributo";
            this.tipoAtributo.Size = new System.Drawing.Size(121, 24);
            this.tipoAtributo.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre";
            // 
            // nombreAtributo
            // 
            this.nombreAtributo.Location = new System.Drawing.Point(16, 142);
            this.nombreAtributo.Name = "nombreAtributo";
            this.nombreAtributo.Size = new System.Drawing.Size(100, 22);
            this.nombreAtributo.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(511, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tipo Indice";
            // 
            // tipoIndiceAtributo
            // 
            this.tipoIndiceAtributo.FormattingEnabled = true;
            this.tipoIndiceAtributo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.tipoIndiceAtributo.Location = new System.Drawing.Point(505, 138);
            this.tipoIndiceAtributo.Name = "tipoIndiceAtributo";
            this.tipoIndiceAtributo.Size = new System.Drawing.Size(121, 24);
            this.tipoIndiceAtributo.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Longitud";
            // 
            // longitudAtributo
            // 
            this.longitudAtributo.Location = new System.Drawing.Point(336, 140);
            this.longitudAtributo.Name = "longitudAtributo";
            this.longitudAtributo.Size = new System.Drawing.Size(113, 22);
            this.longitudAtributo.TabIndex = 17;
            // 
            // agregarAtributo
            // 
            this.agregarAtributo.Location = new System.Drawing.Point(674, 138);
            this.agregarAtributo.Name = "agregarAtributo";
            this.agregarAtributo.Size = new System.Drawing.Size(145, 26);
            this.agregarAtributo.TabIndex = 21;
            this.agregarAtributo.Text = "Agregar Atributo";
            this.agregarAtributo.UseVisualStyleBackColor = true;
            this.agregarAtributo.Click += new System.EventHandler(this.AgregarAtributo_Click);
            // 
            // entidades
            // 
            this.entidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombreEntidad,
            this.direccion,
            this.direccion_final,
            this.dataDireccion,
            this.sig_entidad});
            this.entidades.Location = new System.Drawing.Point(12, 197);
            this.entidades.Name = "entidades";
            this.entidades.RowHeadersWidth = 51;
            this.entidades.RowTemplate.Height = 24;
            this.entidades.Size = new System.Drawing.Size(1426, 150);
            this.entidades.TabIndex = 22;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // nombreEntidad
            // 
            this.nombreEntidad.HeaderText = "Nombre";
            this.nombreEntidad.MinimumWidth = 6;
            this.nombreEntidad.Name = "nombreEntidad";
            this.nombreEntidad.Width = 125;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.MinimumWidth = 6;
            this.direccion.Name = "direccion";
            this.direccion.Width = 125;
            // 
            // direccion_final
            // 
            this.direccion_final.HeaderText = "Direccion Final";
            this.direccion_final.MinimumWidth = 6;
            this.direccion_final.Name = "direccion_final";
            this.direccion_final.Width = 125;
            // 
            // dataDireccion
            // 
            this.dataDireccion.HeaderText = "-1";
            this.dataDireccion.MinimumWidth = 6;
            this.dataDireccion.Name = "dataDireccion";
            this.dataDireccion.Width = 125;
            // 
            // sig_entidad
            // 
            this.sig_entidad.HeaderText = "Entidad Siguiente";
            this.sig_entidad.MinimumWidth = 6;
            this.sig_entidad.Name = "sig_entidad";
            this.sig_entidad.Width = 125;
            // 
            // atributos
            // 
            this.atributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.atributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_atributo,
            this.nombre_atributo,
            this.tipo_dato,
            this.longitud,
            this.direccion_atributo,
            this.tipo_indice,
            this.direccion_data,
            this.sig_atributo});
            this.atributos.Location = new System.Drawing.Point(12, 354);
            this.atributos.Name = "atributos";
            this.atributos.RowHeadersWidth = 51;
            this.atributos.RowTemplate.Height = 24;
            this.atributos.Size = new System.Drawing.Size(1426, 355);
            this.atributos.TabIndex = 23;
            // 
            // id_atributo
            // 
            this.id_atributo.HeaderText = "ID";
            this.id_atributo.MinimumWidth = 6;
            this.id_atributo.Name = "id_atributo";
            this.id_atributo.Width = 125;
            // 
            // nombre_atributo
            // 
            this.nombre_atributo.HeaderText = "Nombre Atributo";
            this.nombre_atributo.MinimumWidth = 6;
            this.nombre_atributo.Name = "nombre_atributo";
            this.nombre_atributo.Width = 125;
            // 
            // tipo_dato
            // 
            this.tipo_dato.HeaderText = "Tipo de Dato";
            this.tipo_dato.MinimumWidth = 6;
            this.tipo_dato.Name = "tipo_dato";
            this.tipo_dato.Width = 125;
            // 
            // longitud
            // 
            this.longitud.HeaderText = "Longitud";
            this.longitud.MinimumWidth = 6;
            this.longitud.Name = "longitud";
            this.longitud.Width = 125;
            // 
            // direccion_atributo
            // 
            this.direccion_atributo.HeaderText = "Direccion";
            this.direccion_atributo.MinimumWidth = 6;
            this.direccion_atributo.Name = "direccion_atributo";
            this.direccion_atributo.Width = 125;
            // 
            // tipo_indice
            // 
            this.tipo_indice.HeaderText = "Tipo Indice";
            this.tipo_indice.MinimumWidth = 6;
            this.tipo_indice.Name = "tipo_indice";
            this.tipo_indice.Width = 125;
            // 
            // direccion_data
            // 
            this.direccion_data.HeaderText = "Direccion de los Datos";
            this.direccion_data.MinimumWidth = 6;
            this.direccion_data.Name = "direccion_data";
            this.direccion_data.Width = 125;
            // 
            // sig_atributo
            // 
            this.sig_atributo.HeaderText = "Siguiente Atributo";
            this.sig_atributo.MinimumWidth = 6;
            this.sig_atributo.Name = "sig_atributo";
            this.sig_atributo.Width = 125;
            // 
            // closeFile
            // 
            this.closeFile.Location = new System.Drawing.Point(210, 12);
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(75, 23);
            this.closeFile.TabIndex = 24;
            this.closeFile.Text = "Cerrar Archvo";
            this.closeFile.UseVisualStyleBackColor = true;
            this.closeFile.Click += new System.EventHandler(this.CloseFile_Click);
            // 
            // cargarDatos
            // 
            this.cargarDatos.Location = new System.Drawing.Point(1154, 142);
            this.cargarDatos.Name = "cargarDatos";
            this.cargarDatos.Size = new System.Drawing.Size(182, 49);
            this.cargarDatos.TabIndex = 25;
            this.cargarDatos.Text = "Cargar Datos";
            this.cargarDatos.UseVisualStyleBackColor = true;
            this.cargarDatos.Click += new System.EventHandler(this.CargarDatos_Click);
            // 
            // typeAtributo
            // 
            this.typeAtributo.Location = new System.Drawing.Point(164, 140);
            this.typeAtributo.Name = "typeAtributo";
            this.typeAtributo.Size = new System.Drawing.Size(121, 22);
            this.typeAtributo.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 721);
            this.Controls.Add(this.typeAtributo);
            this.Controls.Add(this.cargarDatos);
            this.Controls.Add(this.closeFile);
            this.Controls.Add(this.atributos);
            this.Controls.Add(this.entidades);
            this.Controls.Add(this.agregarAtributo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tipoIndiceAtributo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.longitudAtributo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoAtributo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreAtributo);
            this.Controls.Add(this.addEntity);
            this.Controls.Add(this.label_entidad_nombre);
            this.Controls.Add(this.entityText);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.createFile);
            this.Controls.Add(this.crearTabla);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.entidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button crearTabla;
        private System.Windows.Forms.Button createFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label label_entidad_nombre;
        private System.Windows.Forms.TextBox entityText;
        private System.Windows.Forms.Button addEntity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoAtributo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreAtributo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tipoIndiceAtributo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox longitudAtributo;
        private System.Windows.Forms.Button agregarAtributo;
        private System.Windows.Forms.DataGridView entidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sig_entidad;
        private System.Windows.Forms.DataGridView atributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_dato;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn sig_atributo;
        private System.Windows.Forms.Button closeFile;
        private System.Windows.Forms.Button cargarDatos;
        private System.Windows.Forms.TextBox typeAtributo;
    }
}

