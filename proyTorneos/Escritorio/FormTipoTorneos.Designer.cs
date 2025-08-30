namespace Escritorio
{
    partial class FormTipoTorneos
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
            label1 = new Label();
            label2 = new Label();
            nombreLabel = new Label();
            label4 = new Label();
            descLabel = new Label();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dgvListaTipoTorneo = new DataGridView();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListaTipoTorneo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 19);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 0;
            label1.Text = "Datos del Tipo de Torneo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 88);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(23, 175);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 19);
            label4.Name = "label4";
            label4.Size = new Size(177, 20);
            label4.TabIndex = 3;
            label4.Text = "Lista de Tipos de Torneos";
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(23, 243);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(87, 20);
            descLabel.TabIndex = 4;
            descLabel.Text = "Descripcion";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(299, 390);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(116, 27);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(467, 390);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(116, 27);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(632, 390);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 27);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvListaTipoTorneo
            // 
            dgvListaTipoTorneo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaTipoTorneo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaTipoTorneo.Location = new Point(305, 60);
            dgvListaTipoTorneo.Name = "dgvListaTipoTorneo";
            dgvListaTipoTorneo.RowHeadersWidth = 51;
            dgvListaTipoTorneo.Size = new Size(443, 301);
            dgvListaTipoTorneo.TabIndex = 8;
            dgvListaTipoTorneo.SelectionChanged += dgvListaTipoTorneo_SelectionChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(116, 175);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(136, 27);
            txtNombre.TabIndex = 9;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(116, 240);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(136, 27);
            txtDescripcion.TabIndex = 10;
            // 
            // FormTipoTorneo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(dgvListaTipoTorneo);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(descLabel);
            Controls.Add(label4);
            Controls.Add(nombreLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormTipoTorneo";
            Text = "TipoTorneos";
            Load += FormTipoTorneo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaTipoTorneo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label nombreLabel;
        private Label label4;
        private Label descLabel;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private DataGridView dgvListaTipoTorneo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
    }
}