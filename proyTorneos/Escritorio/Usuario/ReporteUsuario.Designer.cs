namespace Escritorio.Usuario
{
    partial class ReporteUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteUsuario));
            report1 = new FastReport.Report();
            pcReporteUsuario = new FastReport.Preview.PreviewControl();
            ((System.ComponentModel.ISupportInitialize)report1).BeginInit();
            SuspendLayout();
            // 
            // report1
            // 
            report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // pcReporteUsuario
            // 
            pcReporteUsuario.BackColor = SystemColors.AppWorkspace;
            pcReporteUsuario.ControlHScrollBarHeight = null;
            pcReporteUsuario.ControlVScrollBarWidth = null;
            pcReporteUsuario.Dock = DockStyle.Fill;
            pcReporteUsuario.Font = new Font("Tahoma", 8.25F);
            pcReporteUsuario.Location = new Point(0, 0);
            pcReporteUsuario.Name = "pcReporteUsuario";
            pcReporteUsuario.OutlineExpand = true;
            pcReporteUsuario.OutlineWidth = 150;
            pcReporteUsuario.PageOffset = new Point(10, 10);
            pcReporteUsuario.RightToLeft = RightToLeft.No;
            pcReporteUsuario.SaveInitialDirectory = null;
            pcReporteUsuario.Size = new Size(800, 450);
            pcReporteUsuario.TabIndex = 0;
            // 
            // ReporteUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pcReporteUsuario);
            Name = "ReporteUsuario";
            Text = "ReporteUsuario";
            FormClosed += ReporteUsuario_FormClosed;
            ((System.ComponentModel.ISupportInitialize)report1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FastReport.Report report1;
        private FastReport.Preview.PreviewControl pcReporteUsuario;
    }
}