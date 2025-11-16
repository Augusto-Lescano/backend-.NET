namespace Escritorio.Torneo
{
    partial class ReporteTorneo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteTorneo));
            pcReporteTorneo = new FastReport.Preview.PreviewControl();
            report1 = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)report1).BeginInit();
            SuspendLayout();
            // 
            // pcReporteTorneo
            // 
            pcReporteTorneo.BackColor = SystemColors.AppWorkspace;
            pcReporteTorneo.ControlHScrollBarHeight = null;
            pcReporteTorneo.ControlVScrollBarWidth = null;
            pcReporteTorneo.Dock = DockStyle.Fill;
            pcReporteTorneo.Font = new Font("Tahoma", 8.25F);
            pcReporteTorneo.Location = new Point(0, 0);
            pcReporteTorneo.Name = "pcReporteTorneo";
            pcReporteTorneo.OutlineExpand = true;
            pcReporteTorneo.OutlineWidth = 150;
            pcReporteTorneo.PageOffset = new Point(10, 10);
            pcReporteTorneo.RightToLeft = RightToLeft.No;
            pcReporteTorneo.SaveInitialDirectory = null;
            pcReporteTorneo.Size = new Size(800, 450);
            pcReporteTorneo.TabIndex = 0;
            // 
            // report1
            // 
            report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // Reporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pcReporteTorneo);
            Name = "Reporte";
            Text = "Reporte";
            FormClosed += Reporte_FormClosed;
            ((System.ComponentModel.ISupportInitialize)report1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FastReport.Preview.PreviewControl pcReporteTorneo;
        private FastReport.Report report1;
    }
}