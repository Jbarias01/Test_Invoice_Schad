namespace Test_Invoice_Schad.Views.Customers
{
    partial class Frm_CustomersDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CustomersDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DsCustomers = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.BtnViewCustomers = new System.Windows.Forms.Button();
            this.BtnAddCustomers = new System.Windows.Forms.Button();
            this.BtnEditCustomers = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LbCantItem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.BtnDeleteCustomers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DsCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DsCustomers
            // 
            this.DsCustomers.DataSetName = "NewDataSet";
            this.DsCustomers.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Customers";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "ID";
            this.dataColumn1.ColumnName = "Id";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "NOMBRE CLIENTE";
            this.dataColumn2.ColumnName = "CustName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "DIRECCION";
            this.dataColumn3.ColumnName = "Adress";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "TIPO CLIENTE";
            this.dataColumn4.ColumnName = "CustomerType";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "ESTADO";
            this.dataColumn5.ColumnName = "Estado";
            // 
            // BtnViewCustomers
            // 
            this.BtnViewCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(244)))));
            this.BtnViewCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewCustomers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnViewCustomers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.BtnViewCustomers.Image = ((System.Drawing.Image)(resources.GetObject("BtnViewCustomers.Image")));
            this.BtnViewCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnViewCustomers.Location = new System.Drawing.Point(303, 125);
            this.BtnViewCustomers.Name = "BtnViewCustomers";
            this.BtnViewCustomers.Size = new System.Drawing.Size(251, 47);
            this.BtnViewCustomers.TabIndex = 3;
            this.BtnViewCustomers.Text = "  VISUALIZAR CLIENTE";
            this.BtnViewCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnViewCustomers.UseVisualStyleBackColor = false;
            this.BtnViewCustomers.Click += new System.EventHandler(this.BtnViewCustomers_Click);
            // 
            // BtnAddCustomers
            // 
            this.BtnAddCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(244)))));
            this.BtnAddCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCustomers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCustomers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.BtnAddCustomers.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCustomers.Image")));
            this.BtnAddCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddCustomers.Location = new System.Drawing.Point(13, 125);
            this.BtnAddCustomers.Name = "BtnAddCustomers";
            this.BtnAddCustomers.Size = new System.Drawing.Size(284, 47);
            this.BtnAddCustomers.TabIndex = 2;
            this.BtnAddCustomers.Text = "  REGISTRAR NUEVO CLIENTE";
            this.BtnAddCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAddCustomers.UseVisualStyleBackColor = false;
            this.BtnAddCustomers.Click += new System.EventHandler(this.BtnAddCustomers_Click);
            // 
            // BtnEditCustomers
            // 
            this.BtnEditCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(244)))));
            this.BtnEditCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditCustomers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditCustomers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.BtnEditCustomers.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditCustomers.Image")));
            this.BtnEditCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditCustomers.Location = new System.Drawing.Point(560, 125);
            this.BtnEditCustomers.Name = "BtnEditCustomers";
            this.BtnEditCustomers.Size = new System.Drawing.Size(243, 47);
            this.BtnEditCustomers.TabIndex = 4;
            this.BtnEditCustomers.Text = "  EDITAR CLIENTE";
            this.BtnEditCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEditCustomers.UseVisualStyleBackColor = false;
            this.BtnEditCustomers.Click += new System.EventHandler(this.BtnEditCustomers_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Referencia,
            this.Nombre,
            this.Direccion,
            this.Tel1,
            this.StateID,
            this.estadoDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "Customers";
            this.dataGridView1.DataSource = this.DsCustomers;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(13, 178);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 299);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Referencia
            // 
            this.Referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Referencia.DataPropertyName = "Id";
            this.Referencia.HeaderText = "CLIENTE";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 98;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.DataPropertyName = "CustName";
            this.Nombre.HeaderText = "NOMBRE CLIENTES";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 179;
            // 
            // Direccion
            // 
            this.Direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Direccion.DataPropertyName = "Adress";
            this.Direccion.HeaderText = "DIRECCIÓN";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 128;
            // 
            // Tel1
            // 
            this.Tel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tel1.DataPropertyName = "CustomerType";
            this.Tel1.HeaderText = "TIPO CLIENTE";
            this.Tel1.Name = "Tel1";
            this.Tel1.ReadOnly = true;
            this.Tel1.Width = 138;
            // 
            // StateID
            // 
            this.StateID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StateID.DataPropertyName = "Status";
            this.StateID.HeaderText = "ESTADO";
            this.StateID.Name = "StateID";
            this.StateID.Visible = false;
            this.StateID.Width = 99;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO CLIENTE";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // LbCantItem
            // 
            this.LbCantItem.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCantItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LbCantItem.Location = new System.Drawing.Point(13, 483);
            this.LbCantItem.Name = "LbCantItem";
            this.LbCantItem.Size = new System.Drawing.Size(1118, 16);
            this.LbCantItem.TabIndex = 417;
            this.LbCantItem.Text = "CANTIDAD DE CLIENTES:";
            this.LbCantItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 16);
            this.label3.TabIndex = 416;
            this.label3.Text = "Buscar Clientes ⤵⤵⤵  //  Búsqueda Avanzada.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(490, 27);
            this.label4.TabIndex = 415;
            this.label4.Text = "Módulo de Clientes.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(489, 22);
            this.label5.TabIndex = 414;
            this.label5.Text = "Gestión de Clientes.";
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtBusqueda.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TxtBusqueda.Location = new System.Drawing.Point(13, 84);
            this.TxtBusqueda.Multiline = true;
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(1118, 36);
            this.TxtBusqueda.TabIndex = 1;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // BtnDeleteCustomers
            // 
            this.BtnDeleteCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(244)))));
            this.BtnDeleteCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteCustomers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteCustomers.ForeColor = System.Drawing.SystemColors.MenuText;
            this.BtnDeleteCustomers.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeleteCustomers.Image")));
            this.BtnDeleteCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteCustomers.Location = new System.Drawing.Point(809, 125);
            this.BtnDeleteCustomers.Name = "BtnDeleteCustomers";
            this.BtnDeleteCustomers.Size = new System.Drawing.Size(283, 47);
            this.BtnDeleteCustomers.TabIndex = 418;
            this.BtnDeleteCustomers.Text = "  ELIMINAR CLIENTE (INHABILITAR)";
            this.BtnDeleteCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteCustomers.UseVisualStyleBackColor = false;
            this.BtnDeleteCustomers.Click += new System.EventHandler(this.BtnDeleteCustomers_Click);
            // 
            // Frm_CustomersDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 508);
            this.Controls.Add(this.BtnDeleteCustomers);
            this.Controls.Add(this.BtnViewCustomers);
            this.Controls.Add(this.BtnAddCustomers);
            this.Controls.Add(this.BtnEditCustomers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LbCantItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtBusqueda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CustomersDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schad - Customers Details";
            this.Load += new System.EventHandler(this.Frm_CustomersDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet DsCustomers;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.Button BtnViewCustomers;
        private System.Windows.Forms.Button BtnAddCustomers;
        private System.Windows.Forms.Button BtnEditCustomers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LbCantItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Button BtnDeleteCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}