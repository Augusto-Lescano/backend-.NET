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
            labelNombre.Location = new Point(20, 20);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre";
            // 
            // labelReglas
            // 
            labelReglas.AutoSize = true;
            labelReglas.Location = new Point(20, 61);
            labelReglas.Name = "labelReglas";
            labelReglas.Size = new Size(41, 15);
            labelReglas.TabIndex = 1;
            labelReglas.Text = "Reglas";
            // 
            // labelCantJugadores
            // 
            labelCantJugadores.AutoSize = true;
            labelCantJugadores.Location = new Point(20, 106);
            labelCantJugadores.Name = "labelCantJugadores";
            labelCantJugadores.Size = new Size(126, 15);
            labelCantJugadores.TabIndex = 2;
            labelCantJugadores.Text = "Cantidad de jugadores";
            // 
            // labelFechaInicio
            // 
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(20, 141);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(86, 15);
            labelFechaInicio.TabIndex = 3;
            labelFechaInicio.Text = "Fecha de Inicio";
            // 
            // labelFechaFin
            // 
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(20, 184);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(73, 15);
            labelFechaFin.TabIndex = 4;
            labelFechaFin.Text = "Fecha de Fin";
            // 
            // labelFechaInicioInscripciones
            // 
            labelFechaInicioInscripciones.AutoSize = true;
            labelFechaInicioInscripciones.Location = new Point(20, 222);
            labelFechaInicioInscripciones.Name = "labelFechaInicioInscripciones";
            labelFechaInicioInscripciones.Size = new Size(158, 15);
            labelFechaInicioInscripciones.TabIndex = 5;
            labelFechaInicioInscripciones.Text = "Fecha de inicio inscripciones";
            // 
            // labelFechaFinInscripciones
            // 
            labelFechaFinInscripciones.AutoSize = true;
            labelFechaFinInscripciones.Location = new Point(20, 270);
            labelFechaFinInscripciones.Name = "labelFechaFinInscripciones";
            labelFechaFinInscripciones.Size = new Size(159, 15);
            labelFechaFinInscripciones.TabIndex = 6;
            labelFechaFinInscripciones.Text = "Fecha de fin de inscripciones";
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(20, 311);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 7;
            labelResultado.Text = "Resultado";
            // 
            // labelRegion
            // 
            labelRegion.AutoSize = true;
            labelRegion.Location = new Point(20, 347);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(44, 15);
            labelRegion.TabIndex = 8;
            labelRegion.Text = "Region";
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(20, 379);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 9;
            labelEstado.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(105, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(189, 23);
            txtNombre.TabIndex = 11;
            // 
            // txtReglas
            // 
            txtReglas.Location = new Point(105, 58);
            txtReglas.Name = "txtReglas";
            txtReglas.Size = new Size(189, 23);
            txtReglas.TabIndex = 12;
            // 
            // txtCantJugadores
            // 
            txtCantJugadores.Location = new Point(152, 103);
            txtCantJugadores.Name = "txtCantJugadores";
            txtCantJugadores.Size = new Size(142, 23);
            txtCantJugadores.TabIndex = 13;
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.Location = new Point(105, 141);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Size = new Size(189, 23);
            txtFechaInicio.TabIndex = 14;
            // 
            // txtFechaFin
            // 
            txtFechaFin.Location = new Point(105, 181);
            txtFechaFin.Name = "txtFechaFin";
            txtFechaFin.Size = new Size(189, 23);
            txtFechaFin.TabIndex = 15;
            // 
            // txtFechaInicioInscripciones
            // 
            txtFechaInicioInscripciones.Location = new Point(184, 219);
            txtFechaInicioInscripciones.Name = "txtFechaInicioInscripciones";
            txtFechaInicioInscripciones.Size = new Size(110, 23);
            txtFechaInicioInscripciones.TabIndex = 16;
            // 
            // txtFechaFinInscripciones
            // 
            txtFechaFinInscripciones.Location = new Point(185, 267);
            txtFechaFinInscripciones.Name = "txtFechaFinInscripciones";
            txtFechaFinInscripciones.Size = new Size(109, 23);
            txtFechaFinInscripciones.TabIndex = 17;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(105, 308);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(189, 23);
            txtResultado.TabIndex = 18;
            // 
            // txtRegion
            // 
            txtRegion.Location = new Point(105, 344);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(189, 23);
            txtRegion.TabIndex = 19;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(105, 376);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(189, 23);
            txtEstado.TabIndex = 20;
            // 
            // labelDatosTorneo
            // 
            labelDatosTorneo.AutoSize = true;
            labelDatosTorneo.Location = new Point(19, -1);
            labelDatosTorneo.Name = "labelDatosTorneo";
            labelDatosTorneo.Size = new Size(95, 15);
            labelDatosTorneo.TabIndex = 21;
            labelDatosTorneo.Text = "Datos del Torneo";
            // 
            // dgvListaTorneos
            // 
            dgvListaTorneos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTorneos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTorneos.Location = new Point(314, 17);
            dgvListaTorneos.Name = "dgvListaTorneos";
            dgvListaTorneos.Size = new Size(480, 373);
            dgvListaTorneos.TabIndex = 22;
            dgvListaTorneos.SelectionChanged += dgvListaTorneos_SelectionChanged;
            // 
            // labelListaTorneos
            // 
            labelListaTorneos.AutoSize = true;
            labelListaTorneos.Location = new Point(314, -1);
            labelListaTorneos.Name = "labelListaTorneos";
            labelListaTorneos.Size = new Size(90, 15);
            labelListaTorneos.TabIndex = 23;
            labelListaTorneos.Text = "Lista de torneos";
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(608, 415);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 24;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregar.Location = new Point(499, 414);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 25;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(713, 414);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormTorneo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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