using FastReport;
using FastReport.Preview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio.Torneo
{
    public partial class ReporteTorneo : Form
    {
        public ReporteTorneo()
        {
            InitializeComponent();
        }

        private Report? miReporte;
        public ReporteTorneo(Report reporte)
        {
            InitializeComponent();

            this.miReporte = reporte;

            this.miReporte.Preview = pcReporteTorneo;

            this.miReporte.ShowPrepared();


        }

        private void Reporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (miReporte != null)
            {
                miReporte.Dispose();
            }
        }
    }
}

