namespace Escritorio
{
    partial class TipoTorneoLista
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
            dgvTipoTorneo = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTipoTorneo).BeginInit();
            SuspendLayout();
            // 
            // dgvTipoTorneo
            // 
            dgvTipoTorneo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipoTorneo.Location = new Point(12, 22);
            dgvTipoTorneo.Name = "dgvTipoTorneo";
            dgvTipoTorneo.Size = new Size(776, 303);
            dgvTipoTorneo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(482, 331);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 27);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(600, 331);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 27);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(713, 331);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 27);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // TipoTorneoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 374);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTipoTorneo);
            Name = "TipoTorneoLista";
            Text = "Lista de tipos de torneos";
            Load += TipoTorneosLoad;
            ((System.ComponentModel.ISupportInitialize)dgvTipoTorneo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTipoTorneo;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}