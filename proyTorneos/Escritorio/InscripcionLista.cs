using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Domain.Model;

namespace Escritorio
{
    public partial class InscripcionLista : Form
    {
        public InscripcionLista(bool admin)
        {
            InitializeComponent();
            if (!admin)
            {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
        public async Task CargarInscripciones()
        {
            dgvInscripciones.DataSource = await API.Clients.InscripcionApiClient.GetAllAsync();
        }

        public InscripcionDTO SeleccionarInscripcion()
        {
            return (InscripcionDTO)dgvInscripciones.SelectedRows[0].DataBoundItem;
        }

        public async Task AgregarInscripcion()
        {
            InscripcionDetalle detalle = new InscripcionDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarInscripciones();

            }
        }

        public async Task ActualizarInscripcion()
        {
            var inscripcion = SeleccionarInscripcion();
            if (inscripcion == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción para actualizar.", "Error");
                return;
            }

            var detalle = new InscripcionDetalle(inscripcion);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarInscripciones();
            }
        }

        public async Task BorrarInscripcion()
        {
            var inscripcion = SeleccionarInscripcion();
            if (inscripcion == null)
            {
                MessageBox.Show("Debe seleccionar una inscripción para eliminar.", "Error");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Desea eliminar la inscripción seleccionada?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await API.Clients.InscripcionApiClient.DeleteAsync(inscripcion.Id);
                MessageBox.Show("Inscripción eliminada exitosamente", "Éxito");
            }

            await CargarInscripciones();
        }

        private async void InscripcionLista_Load(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvInscripciones);
            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            await CargarInscripciones();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarInscripcion();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualizarInscripcion();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarInscripcion();
        }
    }
}
