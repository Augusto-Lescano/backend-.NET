namespace Escritorio
{
    partial class FormTorneo
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
            labelNombre = new Label();
            labelReglas = new Label();
            labelCantJugadores = new Label();
            labelFechaInicio = new Label();
            labelFechaFin = new Label();
            labelFechaInicioInscripciones = new Label();
            labelFechaFinInscripciones = new Label();
            labelResultado = new Label();
            labelRegion = new Label();
            labelEstado = new Label();
            txtNombre = new TextBox();
            txtReglas = new TextBox();
            txtCantJugadores = new TextBox();
            txtFechaInicio = new TextBox();
            txtFechaFin = new TextBox();
            txtFechaInicioInscripciones = new TextBox();
            txtFechaFinInscripciones = new TextBox();
            txtResultado = new TextBox();
            txtRegion = new TextBox();
            txtEstado = new TextBox();
            labelDatosTorneo = new Label();
            dgvListaTorneos = new DataGridView();
            labelListaTorneos = new Label();
            btnActualizar = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).BeginInit();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(23, 27);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(64, 20);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre";
            // 
            // labelReglas
            // 
            labelReglas.AutoSize = true;
            labelReglas.Location = new Point(23, 81);
            labelReglas.Name = "labelReglas";
            labelReglas.Size = new Size(53, 20);
            labelReglas.TabIndex = 1;
            labelReglas.Text = "Reglas";
            // 
            // labelCantJugadores
            // 
            labelCantJugadores.AutoSize = true;
            labelCantJugadores.Location = new Point(23, 141);
            labelCantJugadores.Name = "labelCantJugadores";
            labelCantJugadores.Size = new Size(160, 20);
            labelCantJugadores.TabIndex = 2;
            labelCantJugadores.Text = "Cantidad de jugadores";
            // 
            // labelFechaInicio
            // 
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(23, 188);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(108, 20);
            labelFechaInicio.TabIndex = 3;
            labelFechaInicio.Text = "Fecha de Inicio";
            // 
            // labelFechaFin
            // 
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(23, 245);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(91, 20);
            labelFechaFin.TabIndex = 4;
            labelFechaFin.Text = "Fecha de Fin";
            // 
            // labelFechaInicioInscripciones
            // 
            labelFechaInicioInscripciones.AutoSize = true;
            labelFechaInicioInscripciones.Location = new Point(23, 296);
            labelFechaInicioInscripciones.Name = "labelFechaInicioInscripciones";
            labelFechaInicioInscripciones.Size = new Size(197, 20);
            labelFechaInicioInscripciones.TabIndex = 5;
            labelFechaInicioInscripciones.Text = "Fecha de inicio inscripciones";
            // 
            // labelFechaFinInscripciones
            // 
            labelFechaFinInscripciones.AutoSize = true;
            labelFechaFinInscripciones.Location = new Point(23, 360);
            labelFechaFinInscripciones.Name = "labelFechaFinInscripciones";
            labelFechaFinInscripciones.Size = new Size(199, 20);
            labelFechaFinInscripciones.TabIndex = 6;
            labelFechaFinInscripciones.Text = "Fecha de fin de inscripciones";
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(23, 415);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(75, 20);
            labelResultado.TabIndex = 7;
            labelResultado.Text = "Resultado";
            // 
            // labelRegion
            // 
            labelRegion.AutoSize = true;
            labelRegion.Location = new Point(23, 463);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(56, 20);
            labelRegion.TabIndex = 8;
            labelRegion.Text = "Region";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(23, 505);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(54, 20);
            labelEstado.TabIndex = 9;
            labelEstado.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 23);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(215, 27);
            txtNombre.TabIndex = 11;
            // 
            // txtReglas
            // 
            txtReglas.Location = new Point(120, 77);
            txtReglas.Margin = new Padding(3, 4, 3, 4);
            txtReglas.Name = "txtReglas";
            txtReglas.Size = new Size(215, 27);
            txtReglas.TabIndex = 12;
            txtReglas.TextChanged += txtReglas_TextChanged;
            // 
            // txtCantJugadores
            // 
            txtCantJugadores.Location = new Point(174, 137);
            txtCantJugadores.Margin = new Padding(3, 4, 3, 4);
            txtCantJugadores.Name = "txtCantJugadores";
            txtCantJugadores.Size = new Size(162, 27);
            txtCantJugadores.TabIndex = 13;
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.Location = new Point(120, 188);
            txtFechaInicio.Margin = new Padding(3, 4, 3, 4);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Size = new Size(215, 27);
            txtFechaInicio.TabIndex = 14;
            // 
            // txtFechaFin
            // 
            txtFechaFin.Location = new Point(120, 241);
            txtFechaFin.Margin = new Padding(3, 4, 3, 4);
            txtFechaFin.Name = "txtFechaFin";
            txtFechaFin.Size = new Size(215, 27);
            txtFechaFin.TabIndex = 15;
            // 
            // txtFechaInicioInscripciones
            // 
            txtFechaInicioInscripciones.Location = new Point(210, 292);
            txtFechaInicioInscripciones.Margin = new Padding(3, 4, 3, 4);
            txtFechaInicioInscripciones.Name = "txtFechaInicioInscripciones";
            txtFechaInicioInscripciones.Size = new Size(125, 27);
            txtFechaInicioInscripciones.TabIndex = 16;
            // 
            // txtFechaFinInscripciones
            // 
            txtFechaFinInscripciones.Location = new Point(211, 356);
            txtFechaFinInscripciones.Margin = new Padding(3, 4, 3, 4);
            txtFechaFinInscripciones.Name = "txtFechaFinInscripciones";
            txtFechaFinInscripciones.Size = new Size(124, 27);
            txtFechaFinInscripciones.TabIndex = 17;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(120, 411);
            txtResultado.Margin = new Padding(3, 4, 3, 4);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(215, 27);
            txtResultado.TabIndex = 18;
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(120, 459);
            txtRegion.Margin = new Padding(3, 4, 3, 4);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(215, 27);
            txtRegion.TabIndex = 19;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(120, 501);
            txtEstado.Margin = new Padding(3, 4, 3, 4);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(215, 27);
            txtEstado.TabIndex = 20;
            // 
            // labelDatosTorneo
            // 
            labelDatosTorneo.AutoSize = true;
            labelDatosTorneo.Location = new Point(22, -1);
            labelDatosTorneo.Name = "labelDatosTorneo";
            labelDatosTorneo.Size = new Size(123, 20);
            labelDatosTorneo.TabIndex = 21;
            labelDatosTorneo.Text = "Datos del Torneo";
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(359, 23);
            dgvListaTorneos.Margin = new Padding(3, 4, 3, 4);
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.RowHeadersWidth = 51;
            dgvListaTorneos.Size = new Size(549, 497);
            dgvListaTorneos.TabIndex = 22;
            dgvListaTorneos.CellContentClick += dgvListaTorneos_CellContentClick;
            dgvListaTorneos.SelectionChanged += dgvListaTorneos_SelectionChanged;
            // 
            // labelListaTorneos
            // 
            labelListaTorneos.AutoSize = true;
            labelListaTorneos.Location = new Point(359, -1);
            labelListaTorneos.Name = "labelListaTorneos";
            labelListaTorneos.Size = new Size(114, 20);
            labelListaTorneos.TabIndex = 23;
            labelListaTorneos.Text = "Lista de torneos";
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(695, 553);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(86, 31);
            btnActualizar.TabIndex = 24;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(570, 552);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(86, 31);
            btnAgregar.TabIndex = 25;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(815, 552);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormTorneo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(labelListaTorneos);
            Controls.Add(dgvListaTorneos);
            Controls.Add(labelDatosTorneo);
            Controls.Add(txtEstado);
            Controls.Add(txtRegion);
            Controls.Add(txtResultado);
            Controls.Add(txtFechaFinInscripciones);
            Controls.Add(txtFechaInicioInscripciones);
            Controls.Add(txtFechaFin);
            Controls.Add(txtFechaInicio);
            Controls.Add(txtCantJugadores);
            Controls.Add(txtReglas);
            Controls.Add(txtNombre);
            Controls.Add(labelEstado);
            Controls.Add(labelRegion);
            Controls.Add(labelResultado);
            Controls.Add(labelFechaFinInscripciones);
            Controls.Add(labelFechaInicioInscripciones);
            Controls.Add(labelFechaFin);
            Controls.Add(labelFechaInicio);
            Controls.Add(labelCantJugadores);
            Controls.Add(labelReglas);
            Controls.Add(labelNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTorneo";
            Text = "TORNEOS";
            Load += FormTorneo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNombre;
        private Label labelReglas;
        private Label labelCantJugadores;
        private Label labelFechaInicio;
        private Label labelFechaFin;
        private Label labelFechaInicioInscripciones;
        private Label labelFechaFinInscripciones;
        private Label labelResultado;
        private Label labelRegion;
        private Label labelEstado;
        private TextBox txtNombre;
        private TextBox txtReglas;
        private TextBox txtCantJugadores;
        private TextBox txtFechaInicio;
        private TextBox txtFechaFin;
        private TextBox txtFechaInicioInscripciones;
        private TextBox txtFechaFinInscripciones;
        private TextBox txtResultado;
        private TextBox txtRegion;
        private TextBox txtEstado;
        private Label labelDatosTorneo;
        private DataGridView dgvListaTorneos;
        private Label labelListaTorneos;
        private Button btnActualizar;
        private Button btnAgregar;
        private Button btnEliminar;
    }
}