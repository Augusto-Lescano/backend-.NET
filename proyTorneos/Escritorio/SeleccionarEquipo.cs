using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTOs;

namespace Escritorio
{
    public partial class SeleccionarEquipo : Form
    {
        public EquipoDTO? EquipoSeleccionado { get; private set; }

        public SeleccionarEquipo(IEnumerable<EquipoDTO> equipos)
        {
            InitializeComponent();
            this.Text = "Seleccionar equipo para inscribirse";
            this.StartPosition = FormStartPosition.CenterParent;

            // Configuración del ListBox
            ListaEquipos.DisplayMember = "Nombre";
            ListaEquipos.ValueMember = "Id";
            ListaEquipos.DataSource = equipos.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EquipoSeleccionado = ListaEquipos.SelectedItem as EquipoDTO;

            if (EquipoSeleccionado == null)
            {
                MessageBox.Show("Debes seleccionar un equipo antes de continuar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
