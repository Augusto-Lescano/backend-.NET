namespace Escritorio
{
    partial class FormUsuario
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
            button1 = new Button();
            label1 = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvUsuarios = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            txtPais = new TextBox();
            label7 = new Label();
            txtGamerTag = new TextBox();
            label8 = new Label();
            txtRol = new TextBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(410, 398);
            button1.Name = "button1";
            button1.Size = new Size(80, 34);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(43, 85);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtId.Location = new Point(109, 82);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtNombre.Location = new Point(109, 123);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(43, 126);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtApellido.Location = new Point(109, 166);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 8;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(43, 169);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Apellido";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtEmail.Location = new Point(109, 211);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(43, 214);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 9;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 23);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 11;
            label5.Text = "Lista de usuarios";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 23);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 12;
            label6.Text = "Datos del usuario";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(410, 52);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(348, 332);
            dgvUsuarios.TabIndex = 15;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(541, 398);
            button2.Name = "button2";
            button2.Size = new Size(80, 34);
            button2.TabIndex = 16;
            button2.Text = "Actualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnActualizar_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(678, 398);
            button3.Name = "button3";
            button3.Size = new Size(80, 34);
            button3.TabIndex = 17;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnEliminar_Click;
            // 
            // txtPais
            // 
            txtPais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtPais.Location = new Point(109, 249);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(100, 23);
            txtPais.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(43, 252);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 18;
            label7.Text = "País";
            // 
            // txtGamerTag
            // 
            txtGamerTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtGamerTag.Location = new Point(109, 289);
            txtGamerTag.Name = "txtGamerTag";
            txtGamerTag.Size = new Size(100, 23);
            txtGamerTag.TabIndex = 21;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(43, 292);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 20;
            label8.Text = "GamerTag";
            // 
            // txtRol
            // 
            txtRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtRol.Location = new Point(109, 327);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(100, 23);
            txtRol.TabIndex = 23;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(43, 330);
            label9.Name = "label9";
            label9.Size = new Size(24, 15);
            label9.TabIndex = 22;
            label9.Text = "Rol";
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtRol);
            Controls.Add(label9);
            Controls.Add(txtGamerTag);
            Controls.Add(label8);
            Controls.Add(txtPais);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dgvUsuarios);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtApellido);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormUsuario";
            Text = "USUARIOS";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtId;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvUsuarios;
        private Button button2;
        private Button button3;
        private TextBox txtPais;
        private Label label7;
        private TextBox txtGamerTag;
        private Label label8;
        private TextBox txtRol;
        private Label label9;
    }
}