namespace Escritorio
{
    partial class InscripcionLista
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
            dgvInscripciones = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dgvInscriptos = new DataGridView();
            btnEliminarInscripto = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInscriptos).BeginInit();
            SuspendLayout();
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(12, 12);
            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.RowHeadersWidth = 51;
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscripciones.Size = new Size(776, 349);
            dgvInscripciones.TabIndex = 23;
            dgvInscripciones.SelectionChanged += dgvInscripciones_SelectionChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(176, 377);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 26);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(12, 377);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(158, 26);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(324, 377);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(123, 26);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvInscriptos
            // 
            dgvInscriptos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscriptos.Location = new Point(858, 12);
            dgvInscriptos.Name = "dgvInscriptos";
            dgvInscriptos.Size = new Size(330, 349);
            dgvInscriptos.TabIndex = 24;
            // 
            // btnEliminarInscripto
            // 
            btnEliminarInscripto.Location = new Point(1078, 377);
            btnEliminarInscripto.Name = "btnEliminarInscripto";
            btnEliminarInscripto.Size = new Size(110, 26);
            btnEliminarInscripto.TabIndex = 25;
            btnEliminarInscripto.Text = "Eliminar inscripto";
            btnEliminarInscripto.UseVisualStyleBackColor = true;
            btnEliminarInscripto.Click += btnEliminarInscripto_Click;
            // 
            // InscripcionLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 445);
            Controls.Add(btnEliminarInscripto);
            Controls.Add(dgvInscriptos);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvInscripciones);
            Name = "InscripcionLista";
            Text = "Inscripciones";
            Load += InscripcionLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInscriptos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvInscripciones;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private DataGridView dgvInscriptos;
        private Button btnEliminarInscripto;
    }
}