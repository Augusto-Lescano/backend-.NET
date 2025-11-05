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
        private bool Admin { get; set; }
        public InscripcionLista(bool admin)
        {
            InitializeComponent();
            if (!admin)
            {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
            else
            {
                btnActualizar.Visible = true;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
        public async Task CargarInscripciones()
        {
            var inscripciones = await InscripcionApiClient.GetAllAsync();
            dgvInscripciones.AutoGenerateColumns = true;
            dgvInscripciones.DataSource = inscripciones.ToList();

        }

        public InscripcionDTO SeleccionarInscripcion()
        {
            return dgvInscripciones.SelectedRows.Count > 0
                ? (InscripcionDTO)dgvInscripciones.SelectedRows[0].DataBoundItem
                : null;
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
            Shared.AjustarDataGridView(dgvInscriptos);

            dgvInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInscriptos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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

        private async void dgvInscripciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInscripciones.SelectedRows.Count == 0)
                return;

            var inscripcionSeleccionada = (InscripcionDTO)dgvInscripciones.SelectedRows[0].DataBoundItem;

            if (inscripcionSeleccionada == null)
                return;

            // Traer la inscripción completa con usuarios o equipos
            var inscripcionDetalle = await InscripcionApiClient.GetAsync(inscripcionSeleccionada.Id);

            if (inscripcionDetalle == null)
            {
                dgvInscriptos.DataSource = null;
                return;
            }

            // Detectar tipo de torneo
            string tipoTorneo = inscripcionDetalle.TipoTorneoNombre?.ToLower() ?? "";

            bool esIndividual = tipoTorneo.Contains("1v1")
                             || tipoTorneo.Contains("individual")
                             || tipoTorneo.Contains("battle royale individual");

            if (esIndividual)
            {
                // Mostrar usuarios inscriptos
                dgvInscriptos.DataSource = inscripcionDetalle.Usuarios?.Select(u => new
                {
                    NombreUsuario = u.NombreUsuario,
                    Email = u.Email
                }).ToList();
            }
            else
            {
                // Mostrar equipos inscriptos
                dgvInscriptos.DataSource = inscripcionDetalle.Equipos?.Select(e => new
                {
                    NombreEquipo = e.Nombre,
                    Lider = e.LiderNombre
                }).ToList();
            }
        }


    }
}
