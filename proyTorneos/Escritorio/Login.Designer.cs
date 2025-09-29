namespace Escritorio
{
    partial class Login
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
            labelUsuario = new Label();
            btnAceptar = new Button();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            labelClave = new Label();
            btnCancelar = new Button();
            linkNuevoUsuario = new LinkLabel();
            SuspendLayout();
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Location = new Point(25, 100);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(50, 15);
            labelUsuario.TabIndex = 0;
            labelUsuario.Text = "Usuario:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(91, 236);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(91, 92);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(250, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(91, 144);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(250, 23);
            txtClave.TabIndex = 4;
            // 
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Location = new Point(25, 152);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(39, 15);
            labelClave.TabIndex = 3;
            labelClave.Text = "Clave:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(266, 236);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // linkNuevoUsuario
            // 
            linkNuevoUsuario.AutoSize = true;
            linkNuevoUsuario.Location = new Point(123, 300);
            linkNuevoUsuario.Name = "linkNuevoUsuario";
            linkNuevoUsuario.Size = new Size(168, 30);
            linkNuevoUsuario.TabIndex = 6;
            linkNuevoUsuario.TabStop = true;
            linkNuevoUsuario.Text = "¿Eres nuevo en el sistema?\r\n!Haz click aqui para registrarte¡";
            linkNuevoUsuario.LinkClicked += linkNuevoUsuario_LinkClicked;
            // 
            // Login
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 368);
            Controls.Add(linkNuevoUsuario);
            Controls.Add(btnCancelar);
            Controls.Add(txtClave);
            Controls.Add(labelClave);
            Controls.Add(txtUsuario);
            Controls.Add(btnAceptar);
            Controls.Add(labelUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            Text = "Login sistema de torneos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsuario;
        private Button btnAceptar;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label labelClave;
        private Button btnCancelar;
        private LinkLabel linkNuevoUsuario;
    }
}