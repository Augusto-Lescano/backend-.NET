namespace Escritorio.Juego
{
    partial class JuegoLista
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
            dgvListaJuegos = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaJuegos).BeginInit();
            SuspendLayout();
            // 
            // dgvListaJuegos
            // 
            dgvListaJuegos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaJuegos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaJuegos.Location = new Point(12, 12);
            dgvListaJuegos.Name = "dgvListaJuegos";
            dgvListaJuegos.RowHeadersWidth = 51;
            dgvListaJuegos.Size = new Size(776, 352);
            dgvListaJuegos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(341, 393);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(137, 29);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += this.btnAgregar_Click; 
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(484, 393);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(148, 29);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += this.btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(638, 393);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += this.btnEliminar_Click;
            // 
            // JuegoLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvListaJuegos);
            Name = "JuegoLista";
            Text = "Lista de Juegos";
            ((System.ComponentModel.ISupportInitialize)dgvListaJuegos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvListaJuegos;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}