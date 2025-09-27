using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;
using Domain.Model;

namespace Escritorio
{
    public partial class TipoTorneoLista : Form
    {
        public TipoTorneoLista()
        {
            InitializeComponent();
        }

        public async Task CargarTipoTorneos()
        {
            dgvTipoTorneo.DataSource = await API.TipoTorneo.TipoTorneoApiClient.GetAllAsync();
        }

        public TipoTorneoDTO SeleccionarTipoTorneo()
        {

            TipoTorneoDTO dto = (TipoTorneoDTO)dgvTipoTorneo.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarTipoTorneo()
        {
            TipoTorneoDetalle detalle = new TipoTorneoDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarTipoTorneos();
            }
        }

        public async Task ActualizarTipoTorneo()
        {
            var tipoTorneo = SeleccionarTipoTorneo();
            if (tipoTorneo == null)
            {
                MessageBox.Show("No puede actualizar un tipo de torneo sin haber seleccionado uno anteriormente", "Error al actualizar tipo de torneo");
            }
            else
            {
                var detalle = new TipoTorneoDetalle(tipoTorneo);
                Shared.AjustarFormMDI(detalle);
                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarTipoTorneos();
                }
            }
        }

        public async Task BorrarTipoTorneo()
        {
            var tipoTorneo = SeleccionarTipoTorneo();
            if (tipoTorneo == null)
            {
                MessageBox.Show("No puede borrar un tipo de torneo sin haber seleccionado uno anteriormente", "Error al borrar tipo de torneo");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "¿Desea eliminar el tipo de torneo seleccionado?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await API.TipoTorneo.TipoTorneoApiClient.DeleteAsync(tipoTorneo.Id);
                    MessageBox.Show("Tipo de torneo borrado exitosamente", "Exito al borrar");
                }
                else
                {
                    MessageBox.Show("Operación cancelada", "Confirmacion");
                }
            }
            await CargarTipoTorneos();
        }

        private async void TipoTorneosLoad(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvTipoTorneo);
            dgvTipoTorneo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            await CargarTipoTorneos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarTipoTorneo();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualizarTipoTorneo();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarTipoTorneo();
        }
    }
}
