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
    public partial class EquipoLista : Form
    {
        public EquipoLista(bool admin)
        {
            InitializeComponent();
            if (!admin)
            {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

    public async Task CargarEquipos()
        {
            dgvEquipo.DataSource = await API.Clients.EquipoApiClient.GetAllAsync();
        }

        public EquipoDTO SeleccionarEquipo()
        {
            return (EquipoDTO)dgvEquipo.SelectedRows[0].DataBoundItem;
        }

        public async Task AgregarEquipo()
        {
            EquipoDetalle detalle = new EquipoDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarEquipos();
            }
        }

        public async Task ActualizarEquipo()
        {
            var equipo = SeleccionarEquipo();
            if (equipo == null)
            {
                MessageBox.Show("Debe seleccionar un equipo para actualizar.", "Error");
                return;
            }

            var detalle = new EquipoDetalle(equipo);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarEquipos();
            }
        }

        public async Task BorrarEquipo()
        {
            var equipo = SeleccionarEquipo();
            if (equipo == null)
            {
                MessageBox.Show("Debe seleccionar un equipo para eliminar.", "Error");
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
                await API.Clients.EquipoApiClient.DeleteAsync(equipo.Id);
                MessageBox.Show("Equipo eliminado exitosamente", "Éxito");
            }

            await CargarEquipos();
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
    }
}
