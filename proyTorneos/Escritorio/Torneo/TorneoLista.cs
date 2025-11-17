using API.Clients;
using Domain.Model;
using Domain.Services;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using Escritorio.Torneo;

namespace Escritorio
{
    public partial class TorneoLista : Form
    {
        private readonly UsuarioDTO usuarioActual;
        private List<TorneoDTO> torneosCargados = new();

        public TorneoLista(UsuarioDTO usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            if (!usuario.Admin)
            {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                btnGenerarReporte.Visible = false;
            }

            cmbFiltro.Items.AddRange(new[] { "Nombre Torneo", "Juego", "Organizador", "Region", "Estado" });
            cmbFiltro.SelectedIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private async void TorneoLista_Load(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvListaTorneos);
            await CargarTorneos();

            if (dgvListaTorneos.Rows.Count > 0)
                dgvListaTorneos_SelectionChanged(sender, e);
        }

        //Verifica si el torneo tiene la inscripción abierta
        public bool EstaActivo(TorneoDTO torneo)
        {
            DateTime hoy = DateTime.Now;
            return hoy >= torneo.FechaInicioDeInscripciones && hoy <= torneo.FechaFinDeInscripciones;
        }

        //Cargar torneos desde la API
        public async Task CargarTorneos()
        {
            var torneos = await TorneoApiClient.GetAllAsync();
            torneosCargados = torneos.ToList();

            dgvListaTorneos.DataSource = torneosCargados;

            /*se hace de esta forma porque si los mostramos de la otra forma crea un objeto anonimo y no se puede hacer el cast para eliminar. Entonces se elije que columnas no mostrar*/

            dgvListaTorneos.Columns["TipoDeTorneoId"].Visible = false;
            dgvListaTorneos.Columns["JuegoId"].Visible = false;
            dgvListaTorneos.Columns["InscripcionId"].Visible = false;
            dgvListaTorneos.Columns["OrganizadorId"].Visible = false;
            dgvListaTorneos.Columns["DescripcionDeReglas"].Visible = false;
        }

        //Retorna el torneo seleccionado en la grilla
        public TorneoDTO SeleccionarTorneo()
        {
            if (dgvListaTorneos.SelectedRows.Count == 0)
                return null;

            return (TorneoDTO)dgvListaTorneos.SelectedRows[0].DataBoundItem;
        }

        //Agregar torneo (solo admin)
        public async Task AgregarTorneo()
        {
            var detalle = new TorneoDetalle(usuarioActual.Id);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
                await CargarTorneos();
        }

        //Actualizar torneo (solo admin)
        public async Task ActualizarTorneo()
        {
            var torneo = SeleccionarTorneo();
            if (torneo == null)
            {
                MessageBox.Show("Debe seleccionar un torneo para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detalle = new TorneoDetalle(torneo);
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
                await CargarTorneos();
        }

        //Borrar torneo (solo admin)
        public async Task BorrarTorneo()
        {
            var torneo = SeleccionarTorneo();
            if (torneo == null)
            {
                MessageBox.Show("Debe seleccionar un torneo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Desea eliminar el torneo \"{torneo.Nombre}\"?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await TorneoApiClient.DeleteAsync(torneo.Id);
                MessageBox.Show("Torneo eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTorneos();
            }
        }

        //Filtro de búsqueda
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
            IEnumerable<TorneoDTO> filtrados = campo switch
            {
                "Nombre Torneo" => torneosCargados.Where(t => t.Nombre?.ToLower().Contains(texto) == true),
                "Juego" => torneosCargados.Where(t => t.JuegoNombre?.ToLower().Contains(texto) == true),
                "Organizador" => torneosCargados.Where(t => t.OrganizadorNombre?.ToLower().Contains(texto) == true),
                "Region" => torneosCargados.Where(t => t.Region?.ToLower().Contains(texto) == true),
                "Estado" => torneosCargados.Where(t => t.Estado?.ToLower().Contains(texto) == true),
                _ => torneosCargados
            };

            dgvListaTorneos.DataSource = filtrados.ToList();
        }

        //Evento principal de inscripción
        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            var torneo = SeleccionarTorneo();
            if (torneo == null) return;

            string tipo = torneo.TipoTorneoNombre?.ToLower() ?? "";
            bool esIndividual = tipo.Contains("1v1") || tipo.Contains("individual") || tipo.Contains("battle royale individual");

            try
            {
                if (esIndividual)
                {
                    //Inscribir usuario individual
                    await InscripcionApiClient.InscribirUsuarioAsync(torneo.InscripcionId, usuarioActual.Id);

                    MessageBox.Show($"Te has inscrito al torneo {torneo.Nombre}",
                        "Inscripción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Inscribir equipo del usuario (solo líder)
                    var equipos = await EquipoApiClient.GetEquiposDelLiderAsync(usuarioActual.Id);

                    if (equipos == null || !equipos.Any())
                    {
                        MessageBox.Show("No tienes un equipo disponible para inscribir.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mostrar ventana para elegir equipo
                    using (var seleccionarEquipoForm = new SeleccionarEquipo(equipos))
                    {
                        if (seleccionarEquipoForm.ShowDialog() != DialogResult.OK || seleccionarEquipoForm.EquipoSeleccionado == null)
                        {
                            MessageBox.Show("Operación cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        var equipoSeleccionado = seleccionarEquipoForm.EquipoSeleccionado;

                        // Inscribir el equipo seleccionado
                        await InscripcionApiClient.InscribirEquipoAsync(torneo.InscripcionId, equipoSeleccionado.Id);

                        MessageBox.Show($"Tu equipo '{equipoSeleccionado.Nombre}' ha sido inscrito al torneo '{torneo.Nombre}'.",
                            "Inscripción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al inscribirse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Cambia texto y tamaño del botón al seleccionar torneo
        private void dgvListaTorneos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaTorneos.SelectedRows.Count == 0)
            {
                btnInscribirse.Visible = false;
                return;
            }

            var torneoSeleccionado = (TorneoDTO)dgvListaTorneos.SelectedRows[0].DataBoundItem;
            ActualizarTextoBotonInscribirse(torneoSeleccionado);
            btnInscribirse.Visible = EstaActivo(torneoSeleccionado);
        }

        //Ajusta texto y tamaño del botón “Inscribirse”
        private void ActualizarTextoBotonInscribirse(TorneoDTO? torneo = null)
        {
            if (torneo == null && dgvListaTorneos.SelectedRows.Count > 0)
                torneo = (TorneoDTO)dgvListaTorneos.SelectedRows[0].DataBoundItem;

            if (torneo == null)
            {
                btnInscribirse.Visible = false;
                return;
            }

            string tipo = torneo.TipoTorneoNombre?.ToLower() ?? "";
            bool esIndividual = tipo.Contains("1v1") || tipo.Contains("individual") || tipo.Contains("battle royale individual");

            btnInscribirse.Text = esIndividual ? "Inscribirme" : "Inscribir mi equipo";

            // Medir texto y ajustar tamaño dinámicamente
            var flags = TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix;
            Size textSize = TextRenderer.MeasureText(btnInscribirse.Text, btnInscribirse.Font,
                                                     new Size(int.MaxValue, int.MaxValue), flags);

            const int margenHorizontal = 20;
            const int margenVertical = 8;

            btnInscribirse.Width = textSize.Width + margenHorizontal;
            btnInscribirse.Height = textSize.Height + margenVertical;
            btnInscribirse.Visible = true;
        }

        //Botones de administración
        private async void btnAgregar_Click(object sender, EventArgs e) => await AgregarTorneo();
        private async void btnActualizar_Click(object sender, EventArgs e) => await ActualizarTorneo();
        private async void btnEliminar_Click(object sender, EventArgs e) => await BorrarTorneo();

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var torneos = await TorneoApiClient.GetAllAsync();

            Report report = new Report();

            try
            {
                report.Load("ReporteTorneo.frx");

                report.RegisterData(torneos, "proyTorneos");

                report.GetDataSource("proyTorneos").Enabled = true;

                report.Prepare();
                
                ReporteTorneo visorReporte = new ReporteTorneo(report);
                visorReporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
            
        }
    }
    
}
