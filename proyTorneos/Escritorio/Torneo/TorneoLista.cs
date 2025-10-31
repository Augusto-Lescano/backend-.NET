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
        //private bool Admin { get; set; }
        private UsuarioDTO usuarioActual;

        public TorneoLista(UsuarioDTO usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        
            if (!usuario.Admin) {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        public async Task CargarTorneos()
        {
            var torneos = await TorneoApiClient.GetAllAsync();
            dgvListaTorneos.DataSource = torneos.ToList();

            //se hace de esta forma porque si los mostramos de la otra forma crea un objeto anonimo 
            //y no se puede hacer el cast para eliminar. Entonces se elije que columnas no mostrar
            dgvListaTorneos.Columns["TipoDeTorneoId"].Visible = false;
            dgvListaTorneos.Columns["JuegoId"].Visible = false;
            dgvListaTorneos.Columns["InscripcionId"].Visible = false;
            dgvListaTorneos.Columns["OrganizadorId"].Visible = false;
            dgvListaTorneos.Columns["DescripcionDeReglas"].Visible = false;
            
        }

        public TorneoDTO SeleccionarTorneo()
        {

            TorneoDTO dto = (TorneoDTO)dgvListaTorneos.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarTorneo()
        {
            TorneoDetalle detalle = new TorneoDetalle(usuarioActual.Id);

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

        public async Task BorrarTorneo()
        {
            var torneo = SeleccionarTorneo();
            if (torneo == null)
            {
                MessageBox.Show("No puede borrar un torneo sin haber seleccionado uno anteriormente", "Error al borrar torneo");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "¿Desea eliminar el torneo seleccionado?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await TorneoApiClient.DeleteAsync(torneo.Id);
                    MessageBox.Show("Torneo borrado exitosamente", "Exito al borrar");
                }
                else
                {
                    MessageBox.Show("Operación cancelada", "Confirmacion");
                }
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
