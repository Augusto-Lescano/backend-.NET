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

            if (!usuario.Admin)
            {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }

            cmbFiltro.Items.AddRange(new String[] { "Nombre Torneo", "Juego", "Organizador", "Region", "Estado" });
            cmbFiltro.SelectedIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private List<TorneoDTO> torneosCargados = new List<TorneoDTO>();
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

            torneosCargados = torneos.ToList();

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarTorneos(txtBuscar.Text);
        }

        private void FiltrarTorneos(string texto)
        {
            texto = texto.ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvListaTorneos.DataSource = torneosCargados;
                return;
            }

            string campo = cmbFiltro.SelectedItem?.ToString() ?? "Nombre";
            IEnumerable<TorneoDTO> filtrados = torneosCargados;

            switch (campo)
            {
                case "Nombre Torneo":
                    filtrados = torneosCargados.Where(t =>
                        t.Nombre != null && t.Nombre.ToLower().Contains(texto));
                    break;

                case "Juego":
                    filtrados = torneosCargados.Where(t =>
                        t.JuegoNombre != null && t.JuegoNombre.ToLower().Contains(texto));
                    break;

                case "Organizador":
                    filtrados = torneosCargados.Where(t =>
                        t.OrganizadorNombre != null && t.OrganizadorNombre.ToLower().Contains(texto));
                    break;

                case "Region":
                    filtrados = torneosCargados.Where(t =>
                        t.Region != null && t.Region.ToLower().Contains(texto));
                    break;

                case "Estado":
                    filtrados = torneosCargados.Where(t =>
                        t.Estado != null && t.Estado.ToLower().Contains(texto));
                    break;
            }

            dgvListaTorneos.DataSource = filtrados.ToList();
        }
    }
}
