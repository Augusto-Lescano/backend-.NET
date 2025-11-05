using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace Escritorio
{
    public partial class EquipoLista : Form
    {
        private readonly UsuarioDTO usuarioActual;

        public EquipoLista(UsuarioDTO usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        public async Task CargarEquipos()
        {
            dgvEquipo.DataSource = await EquipoApiClient.GetAllAsync();
        }

        public EquipoDTO SeleccionarEquipo()
        {
            if (dgvEquipo.SelectedRows.Count == 0)
                return null;

            return (EquipoDTO)dgvEquipo.SelectedRows[0].DataBoundItem;
        }

        public async Task AgregarEquipo()
        {
            var detalle = new EquipoDetalle(usuarioActual.Id);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
                await CargarEquipos();
        }

        public async Task ActualizarEquipo()
        {
            var equipo = SeleccionarEquipo();
            if (equipo == null)
            {
                MessageBox.Show("Debe seleccionar un equipo para actualizar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detalle = new EquipoDetalle(equipo);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
                await CargarEquipos();
        }

        public async Task BorrarEquipo()
        {
            var equipo = SeleccionarEquipo();
            if (equipo == null)
            {
                MessageBox.Show("Debe seleccionar un equipo para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Desea eliminar el equipo seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await EquipoApiClient.DeleteAsync(equipo.Id);
                MessageBox.Show("Equipo eliminado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarEquipos();
            }
        }

        private async void EquipoLista_Load(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvEquipo);
            dgvEquipo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            await CargarEquipos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarEquipo();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualizarEquipo();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarEquipo();
        }

        private async void dgvEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquipo.SelectedRows.Count == 0)
                return;

            var equipoSeleccionado = (EquipoDTO)dgvEquipo.SelectedRows[0].DataBoundItem;

            // Mostrar u ocultar botones según si es líder
            bool esLider = equipoSeleccionado.LiderId == usuarioActual.Id;
            btnActualizar.Visible = esLider;
            btnEliminar.Visible = esLider;
            btnAgregarJugadores.Visible = esLider;

            // Cargar jugadores del equipo seleccionado
            await CargarJugadoresDelEquipo(equipoSeleccionado.Id);
        }

        private async Task CargarJugadoresDelEquipo(int equipoId)
        {
            try
            {
                var equipo = await EquipoApiClient.GetAsync(equipoId);

                if (equipo.Usuarios != null && equipo.Usuarios.Any())
                {
                    dgvJugadoresEquipo.DataSource = equipo.Usuarios
                        .Select(u => new
                        {
                            u.NombreUsuario
                        })
                        .ToList();
                }
                else
                {
                    dgvJugadoresEquipo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregarJugadores_Click(object sender, EventArgs e)
        {
            if (dgvEquipo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un equipo para agregar jugadores.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var equipoSeleccionado = (EquipoDTO)dgvEquipo.SelectedRows[0].DataBoundItem;

            // Traer lista de usuarios disponibles
            var usuarios = await UsuarioApiClient.GetUsuariosDisponiblesAsync();

            if (usuarios == null || !usuarios.Any())
            {
                MessageBox.Show("No hay usuarios disponibles para agregar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar ventana para elegir usuarios
            var seleccionarUsuariosForm = new SeleccionarUsuarios(usuarios);
            if (seleccionarUsuariosForm.ShowDialog() == DialogResult.OK)
            {
                var usuariosSeleccionados = seleccionarUsuariosForm.UsuariosSeleccionados;

                if (usuariosSeleccionados == null || !usuariosSeleccionados.Any())
                    return;

                // Enviar al backend
                await EquipoApiClient.AgregarUsuariosAlEquipoAsync(
                    equipoSeleccionado.Id,
                    usuariosSeleccionados.Select(u => u.Id).ToList()
                );

                MessageBox.Show("Usuarios agregados exitosamente al equipo.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarEquipos(); // refrescar lista
                await CargarJugadoresDelEquipo(equipoSeleccionado.Id); // refresca jugadores
            }
        }
    }
}
