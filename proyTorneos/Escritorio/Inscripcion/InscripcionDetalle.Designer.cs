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
            dtpFechaApertura = new DateTimePicker();
            labelFechaCierre = new Label();
            dtpFechaCierre = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(249, 139);
            label1.Name = "label1";
            label1.Size = new Size(210, 20);
            label1.TabIndex = 0;
            label1.Text = "Ingrese datos de la inscripcion";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(310, 409);
            btnAceptar.Margin = new Padding(3, 4, 3, 4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(86, 31);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(463, 409);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(249, 213);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 3;
            label2.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 281);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha apertura";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(391, 209);
            txtEstado.Margin = new Padding(3, 4, 3, 4);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(266, 27);
            txtEstado.TabIndex = 5;
            // 
            // dtpFechaApertura
            // 
            dtpFechaApertura.Location = new Point(391, 281);
            dtpFechaApertura.Margin = new Padding(3, 4, 3, 4);
            dtpFechaApertura.Name = "dtpFechaApertura";
            dtpFechaApertura.Size = new Size(266, 27);
            dtpFechaApertura.TabIndex = 7;
            // 
            // labelFechaCierre
            // 
            labelFechaCierre.AutoSize = true;
            labelFechaCierre.Location = new Point(253, 343);
            labelFechaCierre.Name = "labelFechaCierre";
            labelFechaCierre.Size = new Size(90, 20);
            labelFechaCierre.TabIndex = 8;
            labelFechaCierre.Text = "Fecha Cierre";
            // 
            // dtpFechaCierre
            // 
            dtpFechaCierre.Location = new Point(391, 343);
            dtpFechaCierre.Name = "dtpFechaCierre";
            dtpFechaCierre.Size = new Size(266, 27);
            dtpFechaCierre.TabIndex = 9;
            // 
            // InscripcionDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(dtpFechaCierre);
            Controls.Add(labelFechaCierre);
            Controls.Add(dtpFechaApertura);
            Controls.Add(txtEstado);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
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
        private DateTimePicker dtpFechaApertura;
        private Label labelFechaCierre;
        private DateTimePicker dtpFechaCierre;
    }
}