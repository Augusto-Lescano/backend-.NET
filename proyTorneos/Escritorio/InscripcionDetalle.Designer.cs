namespace Escritorio
{
    partial class InscripcionDetalle
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            label3 = new Label();
            txtEstado = new TextBox();
            dtpFecha = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 104);
            label1.Name = "label1";
            label1.Size = new Size(166, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese datos de la inscripcion";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(265, 281);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(399, 281);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(218, 160);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 211);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 4;
            label3.Text = "Fecha apertura";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(342, 157);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(233, 23);
            txtEstado.TabIndex = 5;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(342, 211);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(233, 23);
            dtpFecha.TabIndex = 7;
            // 
            // InscripcionDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpFecha);
            Controls.Add(txtEstado);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Name = "InscripcionDetalle";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
        private TextBox txtEstado;
        private DateTimePicker dtpFecha;
    }
}