namespace EstructurasArchivos
{
    partial class cargarAtributos
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
            this.createFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.label_entidad_nombre = new System.Windows.Forms.Label();
            this.entityText = new System.Windows.Forms.TextBox();
            this.addEntity = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectEntidad = new System.Windows.Forms.ComboBox();
            this.tipoAtributo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nombreEntidadNuevo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.editarEntidad = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.entidadEditar = new System.Windows.Forms.Button();
            this.eTipoAtributo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.eTipoIndiceAtributo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.eLongitudEntidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.eNombreAtributo = new System.Windows.Forms.TextBox();
            this.editarAtributo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.editarEntAtri = new System.Windows.Forms.ComboBox();
            this.cargarAtrib = new System.Windows.Forms.Button();
            this.bEditarAtributo = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cargarEntidades = new System.Windows.Forms.ComboBox();
            this.elimEntidad = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.botonEliminaEntidad = new System.Windows.Forms.Button();
            this.elimAtributo = new System.Windows.Forms.Button();
            this.eliminaCargarEntidades = new System.Windows.Forms.Button();
            this.elimEntidadAtributo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.eliminarAtributo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.entidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atributos)).BeginInit();
            this.SuspendLayout();
            // 
            // createFile
            // 
            this.createFile.Location = new System.Drawing.Point(691, 23);
            this.createFile.Name = "createFile";
            this.createFile.Size = new System.Drawing.Size(75, 23);
            this.createFile.TabIndex = 2;
            this.createFile.Text = "Crear";
            this.createFile.UseVisualStyleBackColor = true;
            this.createFile.Click += new System.EventHandler(this.CreateFile_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(691, 66);
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
            this.label_entidad_nombre.Location = new System.Drawing.Point(9, 49);
            this.label_entidad_nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_entidad_nombre.Name = "label_entidad_nombre";
            this.label_entidad_nombre.Size = new System.Drawing.Size(114, 17);
            this.label_entidad_nombre.TabIndex = 10;
            this.label_entidad_nombre.Text = "Nombre Entidad:";
            // 
            // entityText
            // 
            this.entityText.Location = new System.Drawing.Point(12, 69);
            this.entityText.Margin = new System.Windows.Forms.Padding(4);
            this.entityText.Name = "entityText";
            this.entityText.Size = new System.Drawing.Size(132, 22);
            this.entityText.TabIndex = 9;
            // 
            // addEntity
            // 
            this.addEntity.Location = new System.Drawing.Point(12, 98);
            this.addEntity.Name = "addEntity";
            this.addEntity.Size = new System.Drawing.Size(132, 32);
            this.addEntity.TabIndex = 11;
            this.addEntity.Text = "Agregar";
            this.addEntity.UseVisualStyleBackColor = true;
            this.addEntity.Click += new System.EventHandler(this.AddEntity_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre Atributo";
            // 
            // nombreAtributo
            // 
            this.nombreAtributo.Location = new System.Drawing.Point(161, 69);
            this.nombreAtributo.Name = "nombreAtributo";
            this.nombreAtributo.Size = new System.Drawing.Size(122, 22);
            this.nombreAtributo.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 187);
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
            this.tipoIndiceAtributo.Location = new System.Drawing.Point(161, 207);
            this.tipoIndiceAtributo.Name = "tipoIndiceAtributo";
            this.tipoIndiceAtributo.Size = new System.Drawing.Size(122, 24);
            this.tipoIndiceAtributo.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Longitud";
            // 
            // longitudAtributo
            // 
            this.longitudAtributo.Location = new System.Drawing.Point(161, 162);
            this.longitudAtributo.Name = "longitudAtributo";
            this.longitudAtributo.Size = new System.Drawing.Size(122, 22);
            this.longitudAtributo.TabIndex = 17;
            // 
            // agregarAtributo
            // 
            this.agregarAtributo.Location = new System.Drawing.Point(161, 290);
            this.agregarAtributo.Name = "agregarAtributo";
            this.agregarAtributo.Size = new System.Drawing.Size(122, 26);
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
            this.entidades.Location = new System.Drawing.Point(12, 402);
            this.entidades.Name = "entidades";
            this.entidades.RowHeadersWidth = 51;
            this.entidades.RowTemplate.Height = 24;
            this.entidades.Size = new System.Drawing.Size(1426, 135);
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
            this.direccion_final.HeaderText = "Direccion Atributos";
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
            this.atributos.Location = new System.Drawing.Point(12, 543);
            this.atributos.Name = "atributos";
            this.atributos.RowHeadersWidth = 51;
            this.atributos.RowTemplate.Height = 24;
            this.atributos.Size = new System.Drawing.Size(1426, 166);
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
            this.closeFile.Location = new System.Drawing.Point(691, 108);
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(75, 23);
            this.closeFile.TabIndex = 24;
            this.closeFile.Text = "Cerrar Archvo";
            this.closeFile.UseVisualStyleBackColor = true;
            this.closeFile.Click += new System.EventHandler(this.CloseFile_Click);
            // 
            // cargarDatos
            // 
            this.cargarDatos.Location = new System.Drawing.Point(637, 283);
            this.cargarDatos.Name = "cargarDatos";
            this.cargarDatos.Size = new System.Drawing.Size(182, 49);
            this.cargarDatos.TabIndex = 25;
            this.cargarDatos.Text = "Cargar Datos";
            this.cargarDatos.UseVisualStyleBackColor = true;
            this.cargarDatos.Click += new System.EventHandler(this.CargarDatos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Entidad";
            // 
            // selectEntidad
            // 
            this.selectEntidad.FormattingEnabled = true;
            this.selectEntidad.Location = new System.Drawing.Point(161, 253);
            this.selectEntidad.Name = "selectEntidad";
            this.selectEntidad.Size = new System.Drawing.Size(122, 24);
            this.selectEntidad.TabIndex = 29;
            // 
            // tipoAtributo
            // 
            this.tipoAtributo.FormattingEnabled = true;
            this.tipoAtributo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.tipoAtributo.Location = new System.Drawing.Point(161, 115);
            this.tipoAtributo.Name = "tipoAtributo";
            this.tipoAtributo.Size = new System.Drawing.Size(121, 24);
            this.tipoAtributo.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(99, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 33);
            this.label6.TabIndex = 31;
            this.label6.Text = "AGREGAR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1245, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 33);
            this.label7.TabIndex = 32;
            this.label7.Text = "EDITAR";
            // 
            // nombreEntidadNuevo
            // 
            this.nombreEntidadNuevo.Location = new System.Drawing.Point(1163, 69);
            this.nombreEntidadNuevo.Name = "nombreEntidadNuevo";
            this.nombreEntidadNuevo.Size = new System.Drawing.Size(121, 22);
            this.nombreEntidadNuevo.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1160, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Nombre Nuevo";
            // 
            // editarEntidad
            // 
            this.editarEntidad.FormattingEnabled = true;
            this.editarEntidad.Location = new System.Drawing.Point(1163, 115);
            this.editarEntidad.Name = "editarEntidad";
            this.editarEntidad.Size = new System.Drawing.Size(121, 24);
            this.editarEntidad.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1160, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Entidad a Editar";
            // 
            // entidadEditar
            // 
            this.entidadEditar.Location = new System.Drawing.Point(1163, 145);
            this.entidadEditar.Name = "entidadEditar";
            this.entidadEditar.Size = new System.Drawing.Size(121, 39);
            this.entidadEditar.TabIndex = 37;
            this.entidadEditar.Text = "Editar Entidad";
            this.entidadEditar.UseVisualStyleBackColor = true;
            this.entidadEditar.Click += new System.EventHandler(this.EntidadEditar_Click);
            // 
            // eTipoAtributo
            // 
            this.eTipoAtributo.FormattingEnabled = true;
            this.eTipoAtributo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.eTipoAtributo.Location = new System.Drawing.Point(1302, 115);
            this.eTipoAtributo.Name = "eTipoAtributo";
            this.eTipoAtributo.Size = new System.Drawing.Size(121, 24);
            this.eTipoAtributo.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1302, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Entidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1302, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Tipo Indice";
            // 
            // eTipoIndiceAtributo
            // 
            this.eTipoIndiceAtributo.FormattingEnabled = true;
            this.eTipoIndiceAtributo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.eTipoIndiceAtributo.Location = new System.Drawing.Point(1302, 207);
            this.eTipoIndiceAtributo.Name = "eTipoIndiceAtributo";
            this.eTipoIndiceAtributo.Size = new System.Drawing.Size(122, 24);
            this.eTipoIndiceAtributo.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1302, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 17);
            this.label12.TabIndex = 42;
            this.label12.Text = "Longitud";
            // 
            // eLongitudEntidad
            // 
            this.eLongitudEntidad.Location = new System.Drawing.Point(1302, 162);
            this.eLongitudEntidad.Name = "eLongitudEntidad";
            this.eLongitudEntidad.Size = new System.Drawing.Size(122, 22);
            this.eLongitudEntidad.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1300, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 17);
            this.label13.TabIndex = 40;
            this.label13.Text = "Tipo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1303, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 17);
            this.label14.TabIndex = 39;
            this.label14.Text = "Nombre Atributo";
            // 
            // eNombreAtributo
            // 
            this.eNombreAtributo.Location = new System.Drawing.Point(1302, 69);
            this.eNombreAtributo.Name = "eNombreAtributo";
            this.eNombreAtributo.Size = new System.Drawing.Size(122, 22);
            this.eNombreAtributo.TabIndex = 38;
            // 
            // editarAtributo
            // 
            this.editarAtributo.FormattingEnabled = true;
            this.editarAtributo.Location = new System.Drawing.Point(1302, 334);
            this.editarAtributo.Name = "editarAtributo";
            this.editarAtributo.Size = new System.Drawing.Size(121, 24);
            this.editarAtributo.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1302, 314);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 17);
            this.label15.TabIndex = 50;
            this.label15.Text = "Atributo";
            // 
            // editarEntAtri
            // 
            this.editarEntAtri.FormattingEnabled = true;
            this.editarEntAtri.Location = new System.Drawing.Point(1303, 253);
            this.editarEntAtri.Name = "editarEntAtri";
            this.editarEntAtri.Size = new System.Drawing.Size(121, 24);
            this.editarEntAtri.TabIndex = 51;
            // 
            // cargarAtrib
            // 
            this.cargarAtrib.Location = new System.Drawing.Point(1303, 283);
            this.cargarAtrib.Name = "cargarAtrib";
            this.cargarAtrib.Size = new System.Drawing.Size(120, 28);
            this.cargarAtrib.TabIndex = 52;
            this.cargarAtrib.Text = "Cargar";
            this.cargarAtrib.UseVisualStyleBackColor = true;
            this.cargarAtrib.Click += new System.EventHandler(this.CargarAtrib_Click);
            // 
            // bEditarAtributo
            // 
            this.bEditarAtributo.Location = new System.Drawing.Point(1302, 364);
            this.bEditarAtributo.Name = "bEditarAtributo";
            this.bEditarAtributo.Size = new System.Drawing.Size(121, 32);
            this.bEditarAtributo.TabIndex = 53;
            this.bEditarAtributo.Text = "Editar Atributo";
            this.bEditarAtributo.UseVisualStyleBackColor = true;
            this.bEditarAtributo.Click += new System.EventHandler(this.BEditarAtributo_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(453, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 33);
            this.label16.TabIndex = 54;
            this.label16.Text = "ELIMINAR";
            // 
            // cargarEntidades
            // 
            this.cargarEntidades.FormattingEnabled = true;
            this.cargarEntidades.Location = new System.Drawing.Point(663, 240);
            this.cargarEntidades.Name = "cargarEntidades";
            this.cargarEntidades.Size = new System.Drawing.Size(122, 24);
            this.cargarEntidades.TabIndex = 55;
            // 
            // elimEntidad
            // 
            this.elimEntidad.FormattingEnabled = true;
            this.elimEntidad.Location = new System.Drawing.Point(382, 69);
            this.elimEntidad.Name = "elimEntidad";
            this.elimEntidad.Size = new System.Drawing.Size(121, 24);
            this.elimEntidad.TabIndex = 56;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(388, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 17);
            this.label17.TabIndex = 57;
            this.label17.Text = "Eliminar Entidad";
            // 
            // botonEliminaEntidad
            // 
            this.botonEliminaEntidad.Location = new System.Drawing.Point(382, 99);
            this.botonEliminaEntidad.Name = "botonEliminaEntidad";
            this.botonEliminaEntidad.Size = new System.Drawing.Size(121, 32);
            this.botonEliminaEntidad.TabIndex = 58;
            this.botonEliminaEntidad.Text = "Eliminar";
            this.botonEliminaEntidad.UseVisualStyleBackColor = true;
            this.botonEliminaEntidad.Click += new System.EventHandler(this.BotonEliminaEntidad_Click);
            // 
            // elimAtributo
            // 
            this.elimAtributo.Location = new System.Drawing.Point(520, 180);
            this.elimAtributo.Name = "elimAtributo";
            this.elimAtributo.Size = new System.Drawing.Size(121, 32);
            this.elimAtributo.TabIndex = 64;
            this.elimAtributo.Text = "Eliminar Atributo";
            this.elimAtributo.UseVisualStyleBackColor = true;
            this.elimAtributo.Click += new System.EventHandler(this.ElimAtributo_Click);
            // 
            // eliminaCargarEntidades
            // 
            this.eliminaCargarEntidades.Location = new System.Drawing.Point(521, 99);
            this.eliminaCargarEntidades.Name = "eliminaCargarEntidades";
            this.eliminaCargarEntidades.Size = new System.Drawing.Size(120, 28);
            this.eliminaCargarEntidades.TabIndex = 63;
            this.eliminaCargarEntidades.Text = "Cargar";
            this.eliminaCargarEntidades.UseVisualStyleBackColor = true;
            this.eliminaCargarEntidades.Click += new System.EventHandler(this.EliminaCargarEntidades_Click);
            // 
            // elimEntidadAtributo
            // 
            this.elimEntidadAtributo.FormattingEnabled = true;
            this.elimEntidadAtributo.Location = new System.Drawing.Point(521, 69);
            this.elimEntidadAtributo.Name = "elimEntidadAtributo";
            this.elimEntidadAtributo.Size = new System.Drawing.Size(121, 24);
            this.elimEntidadAtributo.TabIndex = 62;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(520, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 17);
            this.label18.TabIndex = 61;
            this.label18.Text = "Atributo";
            // 
            // eliminarAtributo
            // 
            this.eliminarAtributo.FormattingEnabled = true;
            this.eliminarAtributo.Location = new System.Drawing.Point(520, 150);
            this.eliminarAtributo.Name = "eliminarAtributo";
            this.eliminarAtributo.Size = new System.Drawing.Size(121, 24);
            this.eliminarAtributo.TabIndex = 60;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(520, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 17);
            this.label19.TabIndex = 59;
            this.label19.Text = "Entidad";
            // 
            // cargarAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 721);
            this.Controls.Add(this.elimAtributo);
            this.Controls.Add(this.eliminaCargarEntidades);
            this.Controls.Add(this.elimEntidadAtributo);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.eliminarAtributo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.botonEliminaEntidad);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.elimEntidad);
            this.Controls.Add(this.cargarEntidades);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.bEditarAtributo);
            this.Controls.Add(this.cargarAtrib);
            this.Controls.Add(this.editarEntAtri);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.editarAtributo);
            this.Controls.Add(this.eTipoAtributo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.eTipoIndiceAtributo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.eLongitudEntidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.eNombreAtributo);
            this.Controls.Add(this.entidadEditar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.editarEntidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nombreEntidadNuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tipoAtributo);
            this.Controls.Add(this.selectEntidad);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreAtributo);
            this.Controls.Add(this.addEntity);
            this.Controls.Add(this.label_entidad_nombre);
            this.Controls.Add(this.entityText);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.createFile);
            this.Name = "cargarAtributos";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.entidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Label label_entidad_nombre;
        private System.Windows.Forms.TextBox entityText;
        private System.Windows.Forms.Button addEntity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreAtributo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tipoIndiceAtributo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox longitudAtributo;
        private System.Windows.Forms.Button agregarAtributo;
        private System.Windows.Forms.DataGridView entidades;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectEntidad;
        private System.Windows.Forms.ComboBox tipoAtributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sig_entidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nombreEntidadNuevo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox editarEntidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button entidadEditar;
        private System.Windows.Forms.ComboBox eTipoAtributo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox eTipoIndiceAtributo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox eLongitudEntidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox eNombreAtributo;
        private System.Windows.Forms.ComboBox editarAtributo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox editarEntAtri;
        private System.Windows.Forms.Button cargarAtrib;
        private System.Windows.Forms.Button bEditarAtributo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cargarEntidades;
        private System.Windows.Forms.ComboBox elimEntidad;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button botonEliminaEntidad;
        private System.Windows.Forms.Button elimAtributo;
        private System.Windows.Forms.Button eliminaCargarEntidades;
        private System.Windows.Forms.ComboBox elimEntidadAtributo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox eliminarAtributo;
        private System.Windows.Forms.Label label19;
    }
}

