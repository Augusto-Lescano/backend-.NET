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
            button1.Location = new Point(469, 531);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(91, 45);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(49, 113);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtId.Location = new Point(125, 109);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(114, 27);
            txtId.TabIndex = 4;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtNombre.Location = new Point(125, 164);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(114, 27);
            txtNombre.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(49, 168);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtApellido.Location = new Point(125, 221);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(114, 27);
            txtApellido.TabIndex = 8;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(49, 225);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 7;
            label3.Text = "Apellido";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtEmail.Location = new Point(125, 281);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(114, 27);
            txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(49, 285);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 9;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(469, 31);
            label5.Name = "label5";
            label5.Size = new Size(118, 20);
            label5.TabIndex = 11;
            label5.Text = "Lista de usuarios";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 31);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 12;
            label6.Text = "Datos del usuario";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(469, 69);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(398, 443);
            dgvUsuarios.TabIndex = 15;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // button2
            // 
            button2.Location = new Point(618, 531);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(91, 45);
            button2.TabIndex = 16;
            button2.Text = "Actualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnActualizar_Click;
            // 
            // button3
            // 
            button3.Location = new Point(775, 531);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(91, 45);
            button3.TabIndex = 17;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnEliminar_Click;
            // 
            // txtPais
            // 
            txtPais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtPais.Location = new Point(125, 332);
            txtPais.Margin = new Padding(3, 4, 3, 4);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(114, 27);
            txtPais.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(49, 336);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 18;
            label7.Text = "País";
            // 
            // txtGamerTag
            // 
            txtGamerTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtGamerTag.Location = new Point(125, 385);
            txtGamerTag.Margin = new Padding(3, 4, 3, 4);
            txtGamerTag.Name = "txtGamerTag";
            txtGamerTag.Size = new Size(114, 27);
            txtGamerTag.TabIndex = 21;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(49, 389);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 20;
            label8.Text = "GamerTag";
            // 
            // txtRol
            // 
            txtRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtRol.Location = new Point(125, 436);
            txtRol.Margin = new Padding(3, 4, 3, 4);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(114, 27);
            txtRol.TabIndex = 23;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(49, 440);
            label9.Name = "label9";
            label9.Size = new Size(31, 20);
            label9.TabIndex = 22;
            label9.Text = "Rol";
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
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
            Margin = new Padding(3, 4, 3, 4);
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