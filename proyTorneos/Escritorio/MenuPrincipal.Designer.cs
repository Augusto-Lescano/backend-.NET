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
            mnsPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPrincipal
            // 
            mnsPrincipal.ImageScalingSize = new Size(20, 20);
            mnsPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, opcionesToolStripMenuItem });
            mnsPrincipal.Location = new Point(0, 0);
            mnsPrincipal.Name = "mnsPrincipal";
            mnsPrincipal.Padding = new Padding(7, 3, 0, 3);
            mnsPrincipal.Size = new Size(914, 30);
            mnsPrincipal.TabIndex = 1;
            mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { mnuSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(73, 24);
            mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(121, 26);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuUsuarios, mnuTorneos, mnuTipoDeTorneo, mnuJuegos });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(85, 24);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // mnuUsuarios
            // 
            mnuUsuarios.Name = "mnuUsuarios";
            mnuUsuarios.Size = new Size(224, 26);
            mnuUsuarios.Text = "Usuarios";
            mnuUsuarios.Click += mnuUsuarios_Click;
            // 
            // mnuTorneos
            // 
            mnuTorneos.Name = "mnuTorneos";
            mnuTorneos.Size = new Size(224, 26);
            mnuTorneos.Text = "Torneos";
            mnuTorneos.Click += mnuTorneos_Click;
            // 
            // mnuTipoDeTorneo
            // 
            mnuTipoDeTorneo.Name = "mnuTipoDeTorneo";
            mnuTipoDeTorneo.Size = new Size(224, 26);
            mnuTipoDeTorneo.Text = "Tipos de Torneo";
            mnuTipoDeTorneo.Click += mnuTipoDeTorneo_Click;
            // 
            // mnuJuegos
            // 
            mnuJuegos.Name = "mnuJuegos";
            mnuJuegos.Size = new Size(224, 26);
            mnuJuegos.Text = "Juegos";
            mnuJuegos.Click += mnuJuegos_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(mnsPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = mnsPrincipal;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuPrincipal";
            Text = "Torneo de videojuegos";
            WindowState = FormWindowState.Maximized;
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
    }
}