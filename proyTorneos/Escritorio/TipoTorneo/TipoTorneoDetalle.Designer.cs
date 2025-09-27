namespace Escritorio
{
    partial class TipoTorneoDetalle
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
            descLabel = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(238, 66);
            label1.Name = "label1";
            label1.Size = new Size(174, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese datos del tipo de torneo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 66);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(222, 123);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 2;
            nombreLabel.Text = "Nombre";
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(222, 174);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(69, 15);
            descLabel.TabIndex = 4;
            descLabel.Text = "Descripcion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(304, 123);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(120, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(304, 172);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(120, 23);
            txtDescripcion.TabIndex = 10;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(222, 236);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(349, 236);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // TipoTorneoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(descLabel);
            Controls.Add(nombreLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TipoTorneoDetalle";
            Text = "TipoTorneos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label nombreLabel;
        private Label descLabel;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}