using Escritorio.Torneo;
using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio.Usuario
{
    public partial class ReporteUsuario : Form
    {
        public ReporteUsuario()
        {
            InitializeComponent();
        }
        private Report? miReporte;
        public ReporteUsuario(Report reporte)
        {
            InitializeComponent();

            this.miReporte = reporte;

            this.miReporte.Preview = pcReporteUsuario;

            this.miReporte.ShowPrepared();

        }

        private void ReporteUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(miReporte != null)
            {
                miReporte.Dispose();
            }
        }
    }
}
