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
            btnAgregarJugadores = new Button();
            dgvJugadoresEquipo = new DataGridView();
            btnEliminarJugador = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvJugadoresEquipo).BeginInit();
            SuspendLayout();
            // 
            // dgvEquipo
            // 
            dgvEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipo.Location = new Point(12, 12);
            dgvEquipo.Name = "dgvEquipo";
            dgvEquipo.RowHeadersWidth = 51;
            dgvEquipo.Size = new Size(776, 342);
            dgvEquipo.TabIndex = 0;
            dgvEquipo.SelectionChanged += dgvEquipo_SelectionChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 374);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(97, 25);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar equipo";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(632, 374);
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
            // btnAgregarJugadores
            // 
            btnAgregarJugadores.Location = new Point(115, 374);
            btnAgregarJugadores.Name = "btnAgregarJugadores";
            btnAgregarJugadores.Size = new Size(114, 25);
            btnAgregarJugadores.TabIndex = 4;
            btnAgregarJugadores.Text = "Agregar jugadores";
            btnAgregarJugadores.UseVisualStyleBackColor = true;
            btnAgregarJugadores.Click += btnAgregarJugadores_Click;
            // 
            // dgvJugadoresEquipo
            // 
            dgvJugadoresEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadoresEquipo.Location = new Point(819, 12);
            dgvJugadoresEquipo.Name = "dgvJugadoresEquipo";
            dgvJugadoresEquipo.Size = new Size(240, 342);
            dgvJugadoresEquipo.TabIndex = 5;
            // 
            // btnEliminarJugador
            // 
            btnEliminarJugador.Location = new Point(956, 374);
            btnEliminarJugador.Name = "btnEliminarJugador";
            btnEliminarJugador.Size = new Size(103, 23);
            btnEliminarJugador.TabIndex = 6;
            btnEliminarJugador.Text = "Eliminar jugador";
            btnEliminarJugador.UseVisualStyleBackColor = true;
            btnEliminarJugador.Click += btnEliminarJugador_Click;
            // 
            // EquipoLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 438);
            Controls.Add(btnEliminarJugador);
            Controls.Add(dgvJugadoresEquipo);
            Controls.Add(btnAgregarJugadores);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvEquipo);
            Name = "EquipoLista";
            Text = "Listado de equipos";
            Load += EquipoLista_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvJugadoresEquipo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEquipo;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnAgregarJugadores;
        private DataGridView dgvJugadoresEquipo;
        private Button btnEliminarJugador;
    }
}