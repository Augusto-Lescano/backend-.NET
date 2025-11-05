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
        private bool _esIndividual = false;
        private int _inscripcionIdActual = 0;
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

            // OCULTAR LA COLUMNA TipoTorneoNombre
            if (dgvInscripciones.Columns["TipoTorneoNombre"] != null)
            {
                dgvInscripciones.Columns["TipoTorneoNombre"].Visible = false;
            }

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

            _inscripcionIdActual = inscripcionSeleccionada.Id; // Guardar el ID actual

            var inscripcionDetalle = await InscripcionApiClient.GetAsync(inscripcionSeleccionada.Id);

            if (inscripcionDetalle == null)
            {
                dgvInscriptos.DataSource = null;
                return;
            }

            // Detectar tipo de torneo
            string tipoTorneo = inscripcionDetalle.TipoTorneoNombre?.ToLower() ?? "";
            _esIndividual = tipoTorneo.Contains("1v1") || tipoTorneo.Contains("individual") || tipoTorneo.Contains("battle royale individual");

            var usuarios = inscripcionDetalle.Usuarios ?? new List<UsuarioDTO>();
            var equipos = inscripcionDetalle.Equipos ?? new List<EquipoDTO>();

            if (_esIndividual)
            {
                dgvInscriptos.DataSource = usuarios.Select(u => new
                {
                    Id = u.Id, // IMPORTANTE: Guardar el ID
                    NombreUsuario = u.NombreUsuario,
                    Email = u.Email
                }).ToList();

                if (dgvInscriptos.Columns.Count > 0)
                {
                    dgvInscriptos.Columns["Id"].Visible = false; // Ocultar columna ID
                    dgvInscriptos.Columns[0].HeaderText = "Nombre de Usuario";
                    dgvInscriptos.Columns[1].HeaderText = "Email";
                }
            }
            else
            {
                dgvInscriptos.DataSource = equipos.Select(e => new
                {
                    Id = e.Id, // IMPORTANTE: Guardar el ID
                    NombreEquipo = e.Nombre,
                    Lider = e.LiderNombre ?? "Sin líder"
                }).ToList();

                if (dgvInscriptos.Columns.Count > 0)
                {
                    dgvInscriptos.Columns["Id"].Visible = false; // Ocultar columna ID
                    dgvInscriptos.Columns[0].HeaderText = "Nombre del Equipo";
                    dgvInscriptos.Columns[1].HeaderText = "Líder";
                }
            }

            btnEliminarInscripto.Enabled = dgvInscriptos.Rows.Count > 0;
        }

        private async void btnEliminarInscripto_Click(object sender, EventArgs e)
        {
            if (dgvInscriptos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un participante para eliminar.");
                return;
            }

            var selectedRow = dgvInscriptos.SelectedRows[0];
            int idAEliminar = (int)selectedRow.Cells["Id"].Value;

            try
            {
                if (_esIndividual)
                {
                    await InscripcionApiClient.EliminarUsuarioDeInscripcionAsync(_inscripcionIdActual, idAEliminar);
                }
                else
                {
                    await InscripcionApiClient.EliminarEquipoDeInscripcionAsync(_inscripcionIdActual, idAEliminar);
                }

                MessageBox.Show("Participante eliminado exitosamente.");
                // Recargar datos...
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
