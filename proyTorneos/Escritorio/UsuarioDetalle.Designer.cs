namespace Escritorio
{
    partial class UsuarioDetalle
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
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            txtPais = new TextBox();
            txtGamerTag = new TextBox();
            txtRol = new TextBox();
            NombreLabel = new Label();
            ApellidoLabel = new Label();
            EmailLabel = new Label();
            PaisLabel = new Label();
            TagLabel = new Label();
            RolLabel = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(274, 56);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(157, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(274, 95);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(157, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(274, 134);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(157, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtPais
            // 
            txtPais.Location = new Point(274, 175);
            txtPais.Margin = new Padding(3, 2, 3, 2);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(157, 23);
            txtPais.TabIndex = 4;
            // 
            // txtGamerTag
            // 
            txtGamerTag.Location = new Point(274, 217);
            txtGamerTag.Margin = new Padding(3, 2, 3, 2);
            txtGamerTag.Name = "txtGamerTag";
            txtGamerTag.Size = new Size(157, 23);
            txtGamerTag.TabIndex = 5;
            // 
            // txtRol
            // 
            txtRol.Location = new Point(274, 259);
            txtRol.Margin = new Padding(3, 2, 3, 2);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(157, 23);
            txtRol.TabIndex = 6;
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(148, 58);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(51, 15);
            NombreLabel.TabIndex = 8;
            NombreLabel.Text = "Nombre";
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(148, 100);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(51, 15);
            ApellidoLabel.TabIndex = 9;
            ApellidoLabel.Text = "Apellido";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(148, 139);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 10;
            EmailLabel.Text = "Email";
            // 
            // PaisLabel
            // 
            PaisLabel.AutoSize = true;
            PaisLabel.Location = new Point(148, 180);
            PaisLabel.Name = "PaisLabel";
            PaisLabel.Size = new Size(28, 15);
            PaisLabel.TabIndex = 11;
            PaisLabel.Text = "Pais";
            // 
            // TagLabel
            // 
            TagLabel.AutoSize = true;
            TagLabel.Location = new Point(148, 222);
            TagLabel.Name = "TagLabel";
            TagLabel.Size = new Size(109, 15);
            TagLabel.TabIndex = 12;
            TagLabel.Text = "Nombre de usuario";
            // 
            // RolLabel
            // 
            RolLabel.AutoSize = true;
            RolLabel.Location = new Point(148, 265);
            RolLabel.Name = "RolLabel";
            RolLabel.Size = new Size(24, 15);
            RolLabel.TabIndex = 13;
            RolLabel.Text = "Rol";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(454, 300);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(565, 300);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(RolLabel);
            Controls.Add(TagLabel);
            Controls.Add(PaisLabel);
            Controls.Add(EmailLabel);
            Controls.Add(ApellidoLabel);
            Controls.Add(NombreLabel);
            Controls.Add(txtRol);
            Controls.Add(txtGamerTag);
            Controls.Add(txtPais);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UsuarioDetalle";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtPais;
        private TextBox txtGamerTag;
        private TextBox txtRol;
        private Label NombreLabel;
        private Label ApellidoLabel;
        private Label EmailLabel;
        private Label PaisLabel;
        private Label TagLabel;
        private Label RolLabel;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}