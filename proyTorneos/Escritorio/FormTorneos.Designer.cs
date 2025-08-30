namespace Escritorio
{
    partial class FormTorneos
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
            txtResultado = new TextBox();
            txtRegion = new TextBox();
            txtEstado = new TextBox();
            labelDatosTorneo = new Label();
            dgvListaTorneos = new DataGridView();
            labelListaTorneos = new Label();
            btnActualizar = new Button();
            btnAgregar = new Button();
            btnEliminar = new Button();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicioInscripciones = new DateTimePicker();
            dtpFechaFinInscripciones = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvListaTorneos).BeginInit();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(157, 33);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre";
            // 
            // labelReglas
            // 
            labelReglas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelReglas.AutoSize = true;
            labelReglas.Location = new Point(157, 74);
            labelReglas.Name = "labelReglas";
            labelReglas.Size = new Size(41, 15);
            labelReglas.TabIndex = 1;
            labelReglas.Text = "Reglas";
            // 
            // labelCantJugadores
            // 
            labelCantJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCantJugadores.AutoSize = true;
            labelCantJugadores.Location = new Point(157, 119);
            labelCantJugadores.Name = "labelCantJugadores";
            labelCantJugadores.Size = new Size(126, 15);
            labelCantJugadores.TabIndex = 2;
            labelCantJugadores.Text = "Cantidad de jugadores";
            // 
            // labelFechaInicio
            // 
            labelFechaInicio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(156, 160);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(86, 15);
            labelFechaInicio.TabIndex = 3;
            labelFechaInicio.Text = "Fecha de Inicio";
            // 
            // labelFechaFin
            // 
            labelFechaFin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(163, 199);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(73, 15);
            labelFechaFin.TabIndex = 4;
            labelFechaFin.Text = "Fecha de Fin";
            // 
            // labelFechaInicioInscripciones
            // 
            labelFechaInicioInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaInicioInscripciones.AutoSize = true;
            labelFechaInicioInscripciones.Location = new Point(437, 36);
            labelFechaInicioInscripciones.Name = "labelFechaInicioInscripciones";
            labelFechaInicioInscripciones.Size = new Size(158, 15);
            labelFechaInicioInscripciones.TabIndex = 5;
            labelFechaInicioInscripciones.Text = "Fecha de inicio inscripciones";
            // 
            // labelFechaFinInscripciones
            // 
            labelFechaFinInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaFinInscripciones.AutoSize = true;
            labelFechaFinInscripciones.Location = new Point(437, 74);
            labelFechaFinInscripciones.Name = "labelFechaFinInscripciones";
            labelFechaFinInscripciones.Size = new Size(143, 15);
            labelFechaFinInscripciones.TabIndex = 6;
            labelFechaFinInscripciones.Text = "Fecha de fin inscripciones";
            // 
            // labelResultado
            // 
            labelResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(437, 119);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 7;
            labelResultado.Text = "Resultado";
            // 
            // labelRegion
            // 
            labelRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRegion.AutoSize = true;
            labelRegion.Location = new Point(452, 160);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(44, 15);
            labelRegion.TabIndex = 8;
            labelRegion.Text = "Region";
            // 
            // labelEstado
            // 
            labelEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(454, 199);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 9;
            labelEstado.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(242, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(189, 23);
            txtNombre.TabIndex = 11;
            // 
            // txtReglas
            // 
            txtReglas.Location = new Point(242, 71);
            txtReglas.Name = "txtReglas";
            txtReglas.Size = new Size(189, 23);
            txtReglas.TabIndex = 12;
            // 
            // txtCantJugadores
            // 
            txtCantJugadores.Location = new Point(289, 116);
            txtCantJugadores.Name = "txtCantJugadores";
            txtCantJugadores.Size = new Size(142, 23);
            txtCantJugadores.TabIndex = 13;
            // 
            // txtResultado
            // 
            txtResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtResultado.Location = new Point(502, 116);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(286, 23);
            txtResultado.TabIndex = 18;
            // 
            // txtRegion
            // 
            txtRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegion.Location = new Point(502, 155);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(286, 23);
            txtRegion.TabIndex = 19;
            // 
            // txtEstado
            // 
            txtEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEstado.Location = new Point(502, 193);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(286, 23);
            txtEstado.TabIndex = 20;
            // 
            // labelDatosTorneo
            // 
            labelDatosTorneo.AutoSize = true;
            labelDatosTorneo.Location = new Point(7, 9);
            labelDatosTorneo.Name = "labelDatosTorneo";
            labelDatosTorneo.Size = new Size(95, 15);
            labelDatosTorneo.TabIndex = 21;
            labelDatosTorneo.Text = "Datos del Torneo";
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(12, 238);
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.RowHeadersWidth = 51;
            dgvListaTorneos.Size = new Size(776, 200);
            dgvListaTorneos.TabIndex = 22;
            dgvListaTorneos.SelectionChanged += dgvListaTorneos_SelectionChanged;
            // 
            // labelListaTorneos
            // 
            labelListaTorneos.AutoSize = true;
            labelListaTorneos.Location = new Point(12, 220);
            labelListaTorneos.Name = "labelListaTorneos";
            labelListaTorneos.Size = new Size(90, 15);
            labelListaTorneos.TabIndex = 23;
            labelListaTorneos.Text = "Lista de torneos";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(7, 110);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 24;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(7, 64);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 25;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(7, 157);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(248, 155);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(200, 23);
            dtpFechaInicio.TabIndex = 27;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(248, 193);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(200, 23);
            dtpFechaFin.TabIndex = 28;
            // 
            // dtpFechaInicioInscripciones
            // 
            dtpFechaInicioInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaInicioInscripciones.Location = new Point(601, 33);
            dtpFechaInicioInscripciones.Name = "dtpFechaInicioInscripciones";
            dtpFechaInicioInscripciones.Size = new Size(187, 23);
            dtpFechaInicioInscripciones.TabIndex = 29;
            // 
            // dtpFechaFinInscripciones
            // 
            dtpFechaFinInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaFinInscripciones.Location = new Point(586, 71);
            dtpFechaFinInscripciones.Name = "dtpFechaFinInscripciones";
            dtpFechaFinInscripciones.Size = new Size(202, 23);
            dtpFechaFinInscripciones.TabIndex = 30;
            // 
            // FormTorneo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpFechaFinInscripciones);
            Controls.Add(dtpFechaInicioInscripciones);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(labelListaTorneos);
            Controls.Add(dgvListaTorneos);
            Controls.Add(labelDatosTorneo);
            Controls.Add(txtEstado);
            Controls.Add(txtRegion);
            Controls.Add(txtResultado);
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
        private TextBox txtResultado;
        private TextBox txtRegion;
        private TextBox txtEstado;
        private Label labelDatosTorneo;
        private DataGridView dgvListaTorneos;
        private Label labelListaTorneos;
        private Button btnActualizar;
        private Button btnAgregar;
        private Button btnEliminar;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicioInscripciones;
        private DateTimePicker dtpFechaFinInscripciones;
    }
}