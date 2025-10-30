namespace Escritorio
{
    partial class TorneoDetalle
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
            dtpFechaFinInscripciones = new DateTimePicker();
            dtpFechaInicioInscripciones = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            txtResultado = new TextBox();
            txtCantJugadores = new TextBox();
            txtReglas = new TextBox();
            txtNombre = new TextBox();
            labelEstado = new Label();
            labelRegion = new Label();
            labelResultado = new Label();
            labelFechaFinInscripciones = new Label();
            labelFechaInicioInscripciones = new Label();
            labelFechaFin = new Label();
            labelFechaInicio = new Label();
            labelCantJugadores = new Label();
            labelReglas = new Label();
            labelNombre = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            labelTipoTorneo = new Label();
            cmbTipoTorneo = new ComboBox();
            cmbJuego = new ComboBox();
            labelJuego = new Label();
            cmbRegion = new ComboBox();
            cmbEstado = new ComboBox();
            SuspendLayout();
            // 
            // dtpFechaFinInscripciones
            // 
            dtpFechaFinInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFechaFinInscripciones.Location = new Point(182, 262);
            dtpFechaFinInscripciones.Name = "dtpFechaFinInscripciones";
            dtpFechaFinInscripciones.Size = new Size(230, 23);
            dtpFechaFinInscripciones.TabIndex = 50;
            // 
            // dtpFechaInicioInscripciones
            // 
            dtpFechaInicioInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFechaInicioInscripciones.Location = new Point(182, 228);
            dtpFechaInicioInscripciones.Name = "dtpFechaInicioInscripciones";
            dtpFechaInicioInscripciones.Size = new Size(230, 23);
            dtpFechaInicioInscripciones.TabIndex = 49;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFechaFin.Location = new Point(80, 188);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(332, 23);
            dtpFechaFin.TabIndex = 48;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFechaInicio.Location = new Point(80, 150);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(332, 23);
            dtpFechaInicio.TabIndex = 47;
            // 
            // txtResultado
            // 
            txtResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtResultado.Location = new Point(80, 385);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(332, 23);
            txtResultado.TabIndex = 44;
            // 
            // txtCantJugadores
            // 
            txtCantJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtCantJugadores.Location = new Point(182, 111);
            txtCantJugadores.Name = "txtCantJugadores";
            txtCantJugadores.Size = new Size(230, 23);
            txtCantJugadores.TabIndex = 43;
            // 
            // txtReglas
            // 
            txtReglas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtReglas.Location = new Point(80, 66);
            txtReglas.Name = "txtReglas";
            txtReglas.Size = new Size(332, 23);
            txtReglas.TabIndex = 42;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtNombre.Location = new Point(80, 25);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(332, 23);
            txtNombre.TabIndex = 41;
            // 
            // labelEstado
            // 
            labelEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(8, 470);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(42, 15);
            labelEstado.TabIndex = 40;
            labelEstado.Text = "Estado";
            // 
            // labelRegion
            // 
            labelRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelRegion.AutoSize = true;
            labelRegion.Location = new Point(8, 427);
            labelRegion.Name = "labelRegion";
            labelRegion.Size = new Size(44, 15);
            labelRegion.TabIndex = 39;
            labelRegion.Text = "Region";
            // 
            // labelResultado
            // 
            labelResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(8, 388);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(59, 15);
            labelResultado.TabIndex = 38;
            labelResultado.Text = "Resultado";
            // 
            // labelFechaFinInscripciones
            // 
            labelFechaFinInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaFinInscripciones.AutoSize = true;
            labelFechaFinInscripciones.Location = new Point(8, 268);
            labelFechaFinInscripciones.Name = "labelFechaFinInscripciones";
            labelFechaFinInscripciones.Size = new Size(143, 15);
            labelFechaFinInscripciones.TabIndex = 37;
            labelFechaFinInscripciones.Text = "Fecha de fin inscripciones";
            // 
            // labelFechaInicioInscripciones
            // 
            labelFechaInicioInscripciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaInicioInscripciones.AutoSize = true;
            labelFechaInicioInscripciones.Location = new Point(8, 234);
            labelFechaInicioInscripciones.Name = "labelFechaInicioInscripciones";
            labelFechaInicioInscripciones.Size = new Size(158, 15);
            labelFechaInicioInscripciones.TabIndex = 36;
            labelFechaInicioInscripciones.Text = "Fecha de inicio inscripciones";
            // 
            // labelFechaFin
            // 
            labelFechaFin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaFin.AutoSize = true;
            labelFechaFin.Location = new Point(8, 194);
            labelFechaFin.Name = "labelFechaFin";
            labelFechaFin.Size = new Size(57, 15);
            labelFechaFin.TabIndex = 35;
            labelFechaFin.Text = "Fecha Fin";
            // 
            // labelFechaInicio
            // 
            labelFechaInicio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelFechaInicio.AutoSize = true;
            labelFechaInicio.Location = new Point(8, 156);
            labelFechaInicio.Name = "labelFechaInicio";
            labelFechaInicio.Size = new Size(70, 15);
            labelFechaInicio.TabIndex = 34;
            labelFechaInicio.Text = "Fecha Inicio";
            // 
            // labelCantJugadores
            // 
            labelCantJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelCantJugadores.AutoSize = true;
            labelCantJugadores.Location = new Point(8, 114);
            labelCantJugadores.Name = "labelCantJugadores";
            labelCantJugadores.Size = new Size(126, 15);
            labelCantJugadores.TabIndex = 33;
            labelCantJugadores.Text = "Cantidad de jugadores";
            // 
            // labelReglas
            // 
            labelReglas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelReglas.AutoSize = true;
            labelReglas.Location = new Point(8, 69);
            labelReglas.Name = "labelReglas";
            labelReglas.Size = new Size(41, 15);
            labelReglas.TabIndex = 32;
            labelReglas.Text = "Reglas";
            // 
            // labelNombre
            // 
            labelNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(8, 28);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 31;
            labelNombre.Text = "Nombre";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(80, 509);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 51;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(218, 509);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 52;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // labelTipoTorneo
            // 
            labelTipoTorneo.AutoSize = true;
            labelTipoTorneo.Location = new Point(8, 305);
            labelTipoTorneo.Name = "labelTipoTorneo";
            labelTipoTorneo.Size = new Size(68, 15);
            labelTipoTorneo.TabIndex = 53;
            labelTipoTorneo.Text = "Tipo torneo";
            // 
            // cmbTipoTorneo
            // 
            cmbTipoTorneo.FormattingEnabled = true;
            cmbTipoTorneo.Location = new Point(80, 302);
            cmbTipoTorneo.Margin = new Padding(3, 2, 3, 2);
            cmbTipoTorneo.Name = "cmbTipoTorneo";
            cmbTipoTorneo.Size = new Size(332, 23);
            cmbTipoTorneo.TabIndex = 54;
            // 
            // cmbJuego
            // 
            cmbJuego.FormattingEnabled = true;
            cmbJuego.Location = new Point(80, 346);
            cmbJuego.Margin = new Padding(3, 2, 3, 2);
            cmbJuego.Name = "cmbJuego";
            cmbJuego.Size = new Size(332, 23);
            cmbJuego.TabIndex = 55;
            // 
            // labelJuego
            // 
            labelJuego.AutoSize = true;
            labelJuego.Location = new Point(8, 349);
            labelJuego.Name = "labelJuego";
            labelJuego.Size = new Size(38, 15);
            labelJuego.TabIndex = 56;
            labelJuego.Text = "Juego";
            // 
            // cmbRegion
            // 
            cmbRegion.FormattingEnabled = true;
            cmbRegion.Location = new Point(80, 424);
            cmbRegion.Name = "cmbRegion";
            cmbRegion.Size = new Size(332, 23);
            cmbRegion.TabIndex = 57;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(80, 467);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(332, 23);
            cmbEstado.TabIndex = 58;
            // 
            // TorneoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 574);
            Controls.Add(cmbEstado);
            Controls.Add(cmbRegion);
            Controls.Add(labelJuego);
            Controls.Add(cmbJuego);
            Controls.Add(cmbTipoTorneo);
            Controls.Add(labelTipoTorneo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dtpFechaFinInscripciones);
            Controls.Add(dtpFechaInicioInscripciones);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
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
            Name = "TorneoDetalle";
            Text = "Torneo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFechaFinInscripciones;
        private DateTimePicker dtpFechaInicioInscripciones;
        private DateTimePicker dtpFechaFin;
        private DateTimePicker dtpFechaInicio;
        private TextBox txtResultado;
        private TextBox txtCantJugadores;
        private TextBox txtReglas;
        private TextBox txtNombre;
        private Label labelEstado;
        private Label labelRegion;
        private Label labelResultado;
        private Label labelFechaFinInscripciones;
        private Label labelFechaInicioInscripciones;
        private Label labelFechaFin;
        private Label labelFechaInicio;
        private Label labelCantJugadores;
        private Label labelReglas;
        private Label labelNombre;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label labelTipoTorneo;
        private ComboBox cmbTipoTorneo;
        private ComboBox cmbJuego;
        private Label labelJuego;
        private ComboBox cmbRegion;
        private ComboBox cmbEstado;
    }
}