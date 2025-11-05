namespace Escritorio
{
    partial class SeleccionarUsuarios
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
            clbUsuarios = new CheckedListBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // clbUsuarios
            // 
            clbUsuarios.FormattingEnabled = true;
            clbUsuarios.Location = new Point(12, 12);
            clbUsuarios.Name = "clbUsuarios";
            clbUsuarios.Size = new Size(553, 382);
            clbUsuarios.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 404);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 34);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(93, 404);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 34);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // SeleccionarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(clbUsuarios);
            Name = "SeleccionarUsuarios";
            Text = "Seleccion de usuarios";
            Load += SeleccionarUsuarios_Load;
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox clbUsuarios;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}