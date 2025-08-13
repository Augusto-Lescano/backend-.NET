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
    public partial class FormTorneo : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5000")
        };
        public FormTorneo()
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
                txtFechaInicio.Text,
                txtFechaFin.Text,
                txtFechaInicioInscripciones.Text,
                txtFechaFinInscripciones.Text,
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
                torneoSeleccionado.FechaInicio = txtFechaInicio.Text;
                torneoSeleccionado.FechaFin = txtFechaFin.Text;
                torneoSeleccionado.FechaInicioDeInscripciones = txtFechaInicioInscripciones.Text;
                torneoSeleccionado.FechaFinDeInscripciones = txtFechaFinInscripciones.Text;
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
                txtFechaInicio.Text = torneo.FechaInicio;
                txtFechaFin.Text = torneo.FechaFin;
                txtFechaInicioInscripciones.Text = torneo.FechaInicioDeInscripciones;
                txtFechaFinInscripciones.Text = torneo.FechaFinDeInscripciones;
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

        private void txtReglas_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvListaTorneos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
