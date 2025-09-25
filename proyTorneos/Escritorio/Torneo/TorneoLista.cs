using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class TorneoLista : Form
    {
        public TorneoLista()
        {
            InitializeComponent();
        }

        public async Task CargarTorneos()
        {
            dgvListaTorneos.DataSource = await TorneoApiClient.GetAllAsync();
        }

        public TorneoDTO SeleccionarTorneo()
        {

            TorneoDTO dto = (TorneoDTO)dgvListaTorneos.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarTorneo()
        {
            TorneoDetalle detalle = new TorneoDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarTorneos();
            }
        }

        public async Task ActualziarTorneo()
        {
            var torneo = SeleccionarTorneo();
            if (torneo == null)
            {
                MessageBox.Show("No puede actualizar un torneo sin haber seleccionado uno anteriormente", "Error al actualizar torneo");
            }
            else
            {
                var detalle = new TorneoDetalle(torneo);
                Shared.AjustarFormMDI(detalle);
                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarTorneos();
                }
            }
        }

        public async Task BorrarTorneo() {
            var torneo = SeleccionarTorneo();
            if (torneo == null)
            {
                MessageBox.Show("No puede borrar un torneo sin haber seleccionado uno anteriormente", "Error al borrar torneo");
            }
            else
            {
                await TorneoApiClient.DeleteAsync(torneo.Id);
                MessageBox.Show("Torneo borrado exitosamente", "Exito al borrar");
            }
            await CargarTorneos();
        }
        
        
        

        private async void TorneoLista_Load(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvListaTorneos);
            await CargarTorneos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarTorneo();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualziarTorneo();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarTorneo();
        }
    }
}
