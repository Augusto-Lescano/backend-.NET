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
            btnInscribirse = new Button();
            btnGenerarReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).BeginInit();
            SuspendLayout();
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(12, 50);
            dgvListaTorneos.MultiSelect = false;
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.RowHeadersWidth = 51;
            dgvListaTorneos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaTorneos.Size = new Size(776, 219);
            dgvListaTorneos.TabIndex = 23;
            dgvListaTorneos.SelectionChanged += dgvListaTorneos_SelectionChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminar.Location = new Point(713, 275);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 27);
            btnEliminar.TabIndex = 29;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Location = new Point(488, 275);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 27);
            btnAgregar.TabIndex = 28;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnActualizar.Location = new Point(604, 275);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 27);
            btnActualizar.TabIndex = 27;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // labelFiltro
            // 
            labelFiltro.AutoSize = true;
            labelFiltro.Location = new Point(12, 22);
            labelFiltro.Name = "labelFiltro";
            labelFiltro.Size = new Size(64, 15);
            labelFiltro.TabIndex = 30;
            labelFiltro.Text = "Filtrar Por: ";
            // 
            // cmbFiltro
            // 
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(87, 20);
            cmbFiltro.Margin = new Padding(3, 2, 3, 2);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(140, 23);
            cmbFiltro.TabIndex = 31;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Location = new Point(244, 22);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(48, 15);
            labelBuscar.TabIndex = 32;
            labelBuscar.Text = "Buscar: ";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(301, 20);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(143, 23);
            txtBuscar.TabIndex = 33;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnInscribirse
            // 
            btnInscribirse.Location = new Point(12, 275);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(75, 27);
            btnInscribirse.TabIndex = 34;
            btnInscribirse.Text = "Inscribirse";
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(675, 12);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(113, 32);
            btnGenerarReporte.TabIndex = 35;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // TorneoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 316);
            Controls.Add(btnGenerarReporte);
            Controls.Add(btnInscribirse);
            Controls.Add(txtBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(cmbFiltro);
            Controls.Add(labelFiltro);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(dgvListaTorneos);
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
        private Button btnInscribirse;
        private Button btnGenerarReporte;
    }
}