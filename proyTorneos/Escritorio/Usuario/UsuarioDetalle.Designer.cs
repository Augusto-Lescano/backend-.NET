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
            txtNombreUsuario = new TextBox();
            NombreLabel = new Label();
            ApellidoLabel = new Label();
            EmailLabel = new Label();
            PaisLabel = new Label();
            TagLabel = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            txtClave = new TextBox();
            checkBoxAdmin = new CheckBox();
            comboBoxPais = new ComboBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(274, 11);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(157, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(274, 56);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(157, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(274, 104);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(157, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(273, 235);
            txtNombreUsuario.Margin = new Padding(3, 2, 3, 2);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(157, 23);
            txtNombreUsuario.TabIndex = 5;
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(148, 19);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(51, 15);
            NombreLabel.TabIndex = 8;
            NombreLabel.Text = "Nombre";
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(148, 64);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(51, 15);
            ApellidoLabel.TabIndex = 9;
            ApellidoLabel.Text = "Apellido";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(148, 112);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 10;
            EmailLabel.Text = "Email";
            // 
            // PaisLabel
            // 
            PaisLabel.AutoSize = true;
            PaisLabel.Location = new Point(148, 199);
            PaisLabel.Name = "PaisLabel";
            PaisLabel.Size = new Size(28, 15);
            PaisLabel.TabIndex = 11;
            PaisLabel.Text = "Pais";
            // 
            // TagLabel
            // 
            TagLabel.AutoSize = true;
            TagLabel.Location = new Point(148, 243);
            TagLabel.Name = "TagLabel";
            TagLabel.Size = new Size(109, 15);
            TagLabel.TabIndex = 12;
            TagLabel.Text = "Nombre de usuario";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(148, 291);
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
            btnCancelar.Location = new Point(348, 291);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 156);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 16;
            label1.Text = "Contraseña";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(274, 148);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(156, 23);
            txtClave.TabIndex = 17;
            // 
            // checkBoxAdmin
            // 
            checkBoxAdmin.AutoSize = true;
            checkBoxAdmin.Location = new Point(508, 150);
            checkBoxAdmin.Name = "checkBoxAdmin";
            checkBoxAdmin.Size = new Size(118, 34);
            checkBoxAdmin.TabIndex = 18;
            checkBoxAdmin.Text = "Otorgar permisos\r\nde administrador\r\n";
            checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // comboBoxPais
            // 
            comboBoxPais.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPais.FormattingEnabled = true;
            comboBoxPais.Location = new Point(274, 191);
            comboBoxPais.Name = "comboBoxPais";
            comboBoxPais.Size = new Size(156, 23);
            comboBoxPais.TabIndex = 19;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(comboBoxPais);
            Controls.Add(checkBoxAdmin);
            Controls.Add(txtClave);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(TagLabel);
            Controls.Add(PaisLabel);
            Controls.Add(EmailLabel);
            Controls.Add(ApellidoLabel);
            Controls.Add(NombreLabel);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UsuarioDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtNombreUsuario;
        private Label NombreLabel;
        private Label ApellidoLabel;
        private Label EmailLabel;
        private Label PaisLabel;
        private Label TagLabel;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private TextBox txtClave;
        private CheckBox checkBoxAdmin;
        private ComboBox comboBoxPais;
    }
}