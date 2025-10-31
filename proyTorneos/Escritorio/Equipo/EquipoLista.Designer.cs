namespace Escritorio
{
    partial class EquipoLista
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
            dgvEquipo = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).BeginInit();
            SuspendLayout();
            // 
            // dgvEquipo
            // 
            dgvEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipo.Location = new Point(14, 16);
            dgvEquipo.Margin = new Padding(3, 4, 3, 4);
            dgvEquipo.Name = "dgvEquipo";
            dgvEquipo.RowHeadersWidth = 51;
            dgvEquipo.Size = new Size(887, 456);
            dgvEquipo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(543, 499);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 33);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(682, 499);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(86, 33);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(815, 499);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 33);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // EquipoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvEquipo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EquipoLista";
            Text = "Form1";
            Load += EquipoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEquipo;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}