namespace Escritorio
{
    partial class TorneoLista
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
            dgvListaTorneos = new DataGridView();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            labelFiltro = new Label();
            cmbFiltro = new ComboBox();
            labelBuscar = new Label();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).BeginInit();
            SuspendLayout();
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(14, 67);
            dgvListaTorneos.Margin = new Padding(3, 4, 3, 4);
            dgvListaTorneos.MultiSelect = false;
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.RowHeadersWidth = 51;
            dgvListaTorneos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaTorneos.Size = new Size(887, 292);
            dgvListaTorneos.TabIndex = 23;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Location = new Point(815, 367);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 36);
            btnEliminar.TabIndex = 29;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Location = new Point(558, 367);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 36);
            btnAgregar.TabIndex = 28;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnActualizar.Location = new Point(690, 367);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(86, 36);
            btnActualizar.TabIndex = 27;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // labelFiltro
            // 
            labelFiltro.AutoSize = true;
            labelFiltro.Location = new Point(14, 29);
            labelFiltro.Name = "labelFiltro";
            labelFiltro.Size = new Size(79, 20);
            labelFiltro.TabIndex = 30;
            labelFiltro.Text = "Filtrar Por: ";
            // 
            // cmbFiltro
            // 
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(99, 26);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(160, 28);
            cmbFiltro.TabIndex = 31;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new Point(279, 29);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(59, 20);
            labelBuscar.TabIndex = 32;
            labelBuscar.Text = "Buscar: ";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(344, 27);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(163, 27);
            txtBuscar.TabIndex = 33;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // TorneoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 421);
            Controls.Add(txtBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(cmbFiltro);
            Controls.Add(labelFiltro);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(dgvListaTorneos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TorneoLista";
            Text = "Lista de torneos";
            Load += TorneoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListaTorneos;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Label labelFiltro;
        private ComboBox cmbFiltro;
        private Label labelBuscar;
        private TextBox txtBuscar;
    }
}