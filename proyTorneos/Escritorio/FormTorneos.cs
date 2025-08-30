using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;
using Domain.Services;

namespace Escritorio
{
    public partial class FormTorneos : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5000")
        };
        public FormTorneos()
        {
            InitializeComponent();
            //LoadTheme(); se desactiva porque causa problemas con los colores de los botones
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            labelListaTorneos.ForeColor = ThemeColor.SecondaryColor;
            labelDatosTorneo.ForeColor = ThemeColor.PrimaryColor;
        }

        private async void FormTorneo_Load(object sender, EventArgs e)
        {
            
            await CargarTorneosAsync();
            MejorarCabeceras();
            Shared.AjustarDataGridView(dgvListaTorneos);
        }

        private async Task CargarTorneosAsync()
        {
            try
            {
                var torneos = await _httpClient.GetFromJsonAsync<IEnumerable<Torneo>>("torneos");
                dgvListaTorneos.DataSource = torneos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando torneos: " + ex.Message);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            TorneoService torneoService = new TorneoService();
            var torneo = new Torneo(
                torneoService.GetNextId(),
                txtNombre.Text,
                txtReglas.Text,
                Convert.ToInt32(txtCantJugadores.Text),
                dtpFechaInicio.Value,
                dtpFechaFin.Value,
                dtpFechaInicioInscripciones.Value,
                dtpFechaFinInscripciones.Value,
                txtResultado.Text,
                txtRegion.Text,
                txtEstado.Text
             );
            var response = await _httpClient.PostAsJsonAsync("torneos", torneo);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Torneo agregado con éxito");
                await CargarTorneosAsync();
            }
            else
            {
                MessageBox.Show("Error al agregar el torneo");
            }

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListaTorneos.CurrentRow?.DataBoundItem is Torneo torneoSeleccionado)
            {
                torneoSeleccionado.Nombre = txtNombre.Text;
                torneoSeleccionado.DescripcionDeReglas = txtReglas.Text;
                torneoSeleccionado.CantidadDeJugadores = Convert.ToInt32(txtCantJugadores.Text);
                torneoSeleccionado.FechaInicio = dtpFechaInicio.Value;
                torneoSeleccionado.FechaFin = dtpFechaFin.Value;
                torneoSeleccionado.FechaInicioDeInscripciones = dtpFechaInicioInscripciones.Value;
                torneoSeleccionado.FechaFinDeInscripciones = dtpFechaFinInscripciones.Value;
                torneoSeleccionado.Resultado = txtResultado.Text;
                torneoSeleccionado.Region = txtRegion.Text;
                torneoSeleccionado.Estado = txtEstado.Text;

                var response = await _httpClient.PutAsJsonAsync<Torneo>($"torneos/{torneoSeleccionado.Id}", torneoSeleccionado);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Torneo modificado con éxito");
                    await CargarTorneosAsync();
                }
                else
                {
                    MessageBox.Show("Error al modificar torneo");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un torneo de la grilla");
            }

        }



        private void dgvListaTorneos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaTorneos.CurrentRow?.DataBoundItem is Torneo torneo)
            {
                txtNombre.Text = torneo.Nombre;
                txtReglas.Text = torneo.DescripcionDeReglas;
                txtCantJugadores.Text = torneo.CantidadDeJugadores.ToString();
                dtpFechaInicio.Value = torneo.FechaInicio;
                dtpFechaFin.Value = torneo.FechaFin;
                dtpFechaInicioInscripciones.Value = torneo.FechaInicioDeInscripciones;
                dtpFechaFinInscripciones.Value = torneo.FechaFinDeInscripciones;
                txtResultado.Text = torneo.Resultado;
                txtRegion.Text = torneo.Region;
                txtEstado.Text = torneo.Estado;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaTorneos.CurrentRow?.DataBoundItem is Torneo torneoSeleccionado)
            {
                var confirm = MessageBox.Show($"¿Eliminar al torneo {torneoSeleccionado.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    var response = await _httpClient.DeleteAsync($"torneos/{torneoSeleccionado.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Torneo eliminado");
                        await CargarTorneosAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar al torneo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un torneo de la grilla");
            }
        }
        private void MejorarCabeceras() {
            dgvListaTorneos.Columns[2].HeaderText = "Descripcion de reglas";
            dgvListaTorneos.Columns[3].HeaderText = "Cantidad de jugadores";
            dgvListaTorneos.Columns[4].HeaderText = "Fecha de Inicio";
            dgvListaTorneos.Columns[5].HeaderText = "Fecha de Fin";
            dgvListaTorneos.Columns[6].HeaderText = "Fecha de Inicio de Inscripciones";
            dgvListaTorneos.Columns[7].HeaderText = "Fecha de Fin de Inscripciones";

        }
    }
}
