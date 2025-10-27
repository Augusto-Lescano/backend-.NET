namespace Escritorio
{
    partial class MenuPrincipal
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
            mnsPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            mnuUsuarios = new ToolStripMenuItem();
            mnuTorneos = new ToolStripMenuItem();
            mnuTipoDeTorneo = new ToolStripMenuItem();
            mnuJuegos = new ToolStripMenuItem();
            mnuInscripciones = new ToolStripMenuItem();
            mnuEquipos = new ToolStripMenuItem();
            mnuActualizarPerfil = new ToolStripMenuItem();
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.ImageScalingSize = new Size(20, 20);
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, opcionesToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Size = new Size(800, 24);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { mnuSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(60, 20);
            mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(96, 22);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuUsuarios, mnuTorneos, mnuTipoDeTorneo, mnuJuegos, mnuInscripciones, mnuEquipos, mnuActualizarPerfil });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // mnuUsuarios
            // 
            mnuUsuarios.Name = "mnuUsuarios";
            mnuUsuarios.Size = new Size(180, 22);
            mnuUsuarios.Text = "Usuarios";
            mnuUsuarios.Click += mnuUsuarios_Click;
            // 
            // mnuTorneos
            // 
            mnuTorneos.Name = "mnuTorneos";
            mnuTorneos.Size = new Size(180, 22);
            mnuTorneos.Text = "Torneos";
            mnuTorneos.Click += mnuTorneos_Click;
            // 
            // mnuTipoDeTorneo
            // 
            mnuTipoDeTorneo.Name = "mnuTipoDeTorneo";
            mnuTipoDeTorneo.Size = new Size(180, 22);
            mnuTipoDeTorneo.Text = "Tipos de Torneo";
            mnuTipoDeTorneo.Click += mnuTipoDeTorneo_Click;
            // 
            // mnuJuegos
            // 
            mnuJuegos.Name = "mnuJuegos";
            mnuJuegos.Size = new Size(180, 22);
            mnuJuegos.Text = "Juegos";
            mnuJuegos.Click += mnuJuegos_Click;
            // 
            // mnuInscripciones
            // 
            mnuInscripciones.Name = "mnuInscripciones";
            mnuInscripciones.Size = new Size(180, 22);
            mnuInscripciones.Text = "Inscripciones";
            mnuInscripciones.Click += mnuInscripciones_Click;
            // 
            // mnuEquipos
            // 
            mnuEquipos.Name = "mnuEquipos";
            mnuEquipos.Size = new Size(180, 22);
            mnuEquipos.Text = "Equipos";
            mnuEquipos.Click += mnuEquipos_Click;
            // 
            // mnuActualizarPerfil
            // 
            mnuActualizarPerfil.Name = "mnuActualizarPerfil";
            mnuActualizarPerfil.Size = new Size(180, 22);
            mnuActualizarPerfil.Text = "Actualizar perfil";
            mnuActualizarPerfil.Click += mnuActualizarPerfil_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mnsPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            Name = "MenuPrincipal";
            Text = "Torneo de videojuegos";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipal_Load;
            mnsPrincipal.ResumeLayout(false);
            mnsPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem mnuUsuarios;
        private ToolStripMenuItem mnuTorneos;
        private ToolStripMenuItem mnuTipoDeTorneo;
        private ToolStripMenuItem mnuJuegos;
        private ToolStripMenuItem mnuActualizarPerfil;
        private ToolStripMenuItem mnuInscripciones;
        private ToolStripMenuItem mnuEquipos;
    }
}