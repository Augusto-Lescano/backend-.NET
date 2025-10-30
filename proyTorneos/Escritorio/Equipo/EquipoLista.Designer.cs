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
            dgvEquipo.Location = new Point(12, 12);
            dgvEquipo.Name = "dgvEquipo";
            dgvEquipo.Size = new Size(776, 342);
            dgvEquipo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(475, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 25);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(597, 374);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 25);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(713, 374);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 25);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // EquipoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvEquipo);
            Name = "EquipoLista";
            Text = "Form1";
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