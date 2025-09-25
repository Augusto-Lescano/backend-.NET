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
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).BeginInit();
            SuspendLayout();
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(12, 12);
            dgvListaTorneos.MultiSelect = false;
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.RowHeadersWidth = 51;
            dgvListaTorneos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaTorneos.Size = new Size(776, 257);
            dgvListaTorneos.TabIndex = 23;
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
            // TorneoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 316);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(dgvListaTorneos);
            Name = "TorneoLista";
            Text = "Lista de torneos";
            Load += TorneoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvListaTorneos;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnActualizar;
    }
}