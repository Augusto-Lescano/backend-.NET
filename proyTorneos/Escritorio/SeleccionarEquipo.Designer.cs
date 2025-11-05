namespace Escritorio
{
    partial class SeleccionarEquipo
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
            ListaEquipos = new ListBox();
            btnAgregar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // ListaEquipos
            // 
            ListaEquipos.FormattingEnabled = true;
            ListaEquipos.ItemHeight = 15;
            ListaEquipos.Location = new Point(12, 12);
            ListaEquipos.Name = "ListaEquipos";
            ListaEquipos.Size = new Size(423, 364);
            ListaEquipos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 382);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Inscribir";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(360, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // SeleccionarEquipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 419);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(ListaEquipos);
            Name = "SeleccionarEquipo";
            Text = "Seleccionar equipo";
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListaEquipos;
        private Button btnAgregar;
        private Button btnCancelar;
    }
}