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
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            txtPais = new TextBox();
            txtGamerTag = new TextBox();
            txtRol = new TextBox();
            IdLabel = new Label();
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
            // txtId
            // 
            txtId.Location = new Point(313, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(179, 27);
            txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(313, 92);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(179, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(313, 144);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(179, 27);
            txtApellido.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(313, 196);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(179, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPais
            // 
            txtPais.Location = new Point(313, 250);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(179, 27);
            txtPais.TabIndex = 4;
            // 
            // txtGamerTag
            // 
            txtGamerTag.Location = new Point(313, 306);
            txtGamerTag.Name = "txtGamerTag";
            txtGamerTag.Size = new Size(179, 27);
            txtGamerTag.TabIndex = 5;
            // 
            // txtRol
            // 
            txtRol.Location = new Point(313, 363);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(179, 27);
            txtRol.TabIndex = 6;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(169, 44);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(22, 20);
            IdLabel.TabIndex = 7;
            IdLabel.Text = "Id";
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(169, 95);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(64, 20);
            NombreLabel.TabIndex = 8;
            NombreLabel.Text = "Nombre";
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(169, 151);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(66, 20);
            ApellidoLabel.TabIndex = 9;
            ApellidoLabel.Text = "Apellido";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(169, 203);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(46, 20);
            EmailLabel.TabIndex = 10;
            EmailLabel.Text = "Email";
            // 
            // PaisLabel
            // 
            PaisLabel.AutoSize = true;
            PaisLabel.Location = new Point(169, 257);
            PaisLabel.Name = "PaisLabel";
            PaisLabel.Size = new Size(34, 20);
            PaisLabel.TabIndex = 11;
            PaisLabel.Text = "Pais";
            // 
            // TagLabel
            // 
            TagLabel.AutoSize = true;
            TagLabel.Location = new Point(169, 313);
            TagLabel.Name = "TagLabel";
            TagLabel.Size = new Size(80, 20);
            TagLabel.TabIndex = 12;
            TagLabel.Text = "Gamer Tag";
            // 
            // RolLabel
            // 
            RolLabel.AutoSize = true;
            RolLabel.Location = new Point(169, 370);
            RolLabel.Name = "RolLabel";
            RolLabel.Size = new Size(31, 20);
            RolLabel.TabIndex = 13;
            RolLabel.Text = "Rol";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(519, 400);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(646, 400);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(RolLabel);
            Controls.Add(TagLabel);
            Controls.Add(PaisLabel);
            Controls.Add(EmailLabel);
            Controls.Add(ApellidoLabel);
            Controls.Add(NombreLabel);
            Controls.Add(IdLabel);
            Controls.Add(txtRol);
            Controls.Add(txtGamerTag);
            Controls.Add(txtPais);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Name = "UsuarioDetalle";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtPais;
        private TextBox txtGamerTag;
        private TextBox txtRol;
        private Label IdLabel;
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