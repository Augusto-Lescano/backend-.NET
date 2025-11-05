using API.Clients;
using API.TipoTorneo;
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
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Escritorio
{
    public partial class TorneoDetalle : Form
    {
        private TorneoDTO torneoDTO { set; get; }
        private int usuarioConectadoId;

        private bool EsActualizar => btnAceptar.Text == "Actualizar";

        public TorneoDetalle(int usuarioConectado)
        {
            InitializeComponent();
            this.Text = "Agregar un Torneo";
            usuarioConectadoId = usuarioConectado;
            this.Load += TorneoDetalle_Load;

            //Campo visible solo al actualizar
            txtResultado.Visible = false;
            labelResultado.Visible = false;
        }

        public TorneoDetalle(TorneoDTO dto)
        {
            InitializeComponent();
            this.Text = "Actualizar un torneo";
            btnAceptar.Text = "Actualizar";

            torneoDTO = dto;
            this.Load += TorneoDetalle_Load;

            // Fechas de inscripción solo visibles al agregar
            labelFechaInicioInscripciones.Visible = false;
            labelFechaFinInscripciones.Visible = false;
            dtpFechaInicioInscripciones.Visible = false;
            dtpFechaFinInscripciones.Visible = false;

            // Resultado visible solo al actualizar
            txtResultado.Visible = true;
            labelResultado.Visible = true;
        }

        private async void TorneoDetalle_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            await CargarComboboxes();
            CargarCombosEstaticos();

            if (EsActualizar && torneoDTO != null)
                CargarDatosDeTorneoExistente();

            btnAceptar.Enabled = true;
        }

        private void CargarDatosDeTorneoExistente()
        {
            txtNombre.Text = torneoDTO.Nombre;
            txtReglas.Text = torneoDTO.DescripcionDeReglas;
            txtCantJugadores.Text = torneoDTO.CantidadDeJugadores.ToString();
            dtpFechaInicio.Value = torneoDTO.FechaInicio;
            dtpFechaFin.Value = torneoDTO.FechaFin;
            txtResultado.Text = torneoDTO.Resultado ?? "";

            // Cargar comboboxes seleccionados
            if (torneoDTO.JuegoId > 0)
                cmbJuego.SelectedValue = torneoDTO.JuegoId;

            if (torneoDTO.TipoDeTorneoId > 0)
                cmbTipoTorneo.SelectedValue = torneoDTO.TipoDeTorneoId;

            if (!string.IsNullOrEmpty(torneoDTO.Region))
                cmbRegion.SelectedItem = torneoDTO.Region;
        }

        private async Task CargarComboboxes()
        {
            try
            {
                var juegos = await JuegoApiClient.GetAllAsync();
                cmbJuego.DataSource = juegos?.ToList();
                cmbJuego.DisplayMember = "Nombre";
                cmbJuego.ValueMember = "Id";

                var tipos = await TipoTorneoApiClient.GetAllAsync();
                cmbTipoTorneo.DataSource = tipos?.ToList();
                cmbTipoTorneo.DisplayMember = "Nombre";
                cmbTipoTorneo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombosEstaticos()
        {
            cmbRegion.Items.Clear();
            cmbRegion.Items.AddRange(new string[] { "LAS", "LAN", "NA", "EUW", "GLOBAL" });
            cmbRegion.SelectedIndex = 0;
        }

        public async Task AgregaryActualizarTorneo()
        {
            // === VALIDACIONES DE CAMPOS ===

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar un nombre para el torneo.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!int.TryParse(txtCantJugadores.Text, out int numero) || numero <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad de jugadores válida.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantJugadores.Focus();
                return;
            }

            if (cmbJuego.SelectedValue == null || cmbTipoTorneo.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un juego y un tipo de torneo.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRegion.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una región válida.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === VALIDACIONES DE FECHAS ===

            var hoy = DateTime.Now.Date;

            if (dtpFechaInicio.Value.Date < hoy)
            {
                MessageBox.Show("La fecha de inicio del torneo no puede ser anterior a hoy.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaInicio.Value >= dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio del torneo debe ser anterior a la fecha de fin.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validación de inscripciones solo si estamos agregando
            if (!EsActualizar)
            {
                if (dtpFechaInicioInscripciones.Value > dtpFechaFinInscripciones.Value)
                {
                    MessageBox.Show("La fecha de inicio de inscripciones no puede ser posterior a la fecha de fin de inscripciones.",
                        "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // === CREAR DTO ===
            var dto = new TorneoDTO
            {
                Nombre = txtNombre.Text.Trim(),
                DescripcionDeReglas = txtReglas.Text.Trim(),
                CantidadDeJugadores = numero,
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                Region = cmbRegion.SelectedItem.ToString(),
                JuegoId = (int)cmbJuego.SelectedValue,
                TipoDeTorneoId = (int)cmbTipoTorneo.SelectedValue
            };

            // === ACTUALIZAR O AGREGAR ===
            if (EsActualizar)
            {
                dto.Id = torneoDTO.Id;
                dto.Resultado = string.IsNullOrWhiteSpace(txtResultado.Text)
                    ? torneoDTO.Resultado
                    : txtResultado.Text;

                dto.FechaInicioDeInscripciones = torneoDTO.FechaInicioDeInscripciones;
                dto.FechaFinDeInscripciones = torneoDTO.FechaFinDeInscripciones;

                await TorneoApiClient.UpdateAsync(dto);
                MessageBox.Show("Torneo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dto.OrganizadorId = usuarioConectadoId;
                dto.FechaInicioDeInscripciones = dtpFechaInicioInscripciones.Value;
                dto.FechaFinDeInscripciones = dtpFechaFinInscripciones.Value;
                dto.Resultado = "Pendiente";

                await TorneoApiClient.AddAsync(dto);
                MessageBox.Show("Torneo agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
        }


        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarTorneo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
