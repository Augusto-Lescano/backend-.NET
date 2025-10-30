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

        public TorneoDetalle(int usuarioConectado)
        {
            InitializeComponent();
            this.Text = "Agregar un Torneo";
            usuarioConectadoId = usuarioConectado;
            this.Load += TorneoDetalle_Load;
        }

        public TorneoDetalle(TorneoDTO dto)
        {
            InitializeComponent();
            this.Text = "Actualizar un torneo";
            btnAceptar.Text = "Actualizar";
            txtNombre.Text = dto.Nombre;
            txtReglas.Text = dto.DescripcionDeReglas;
            txtCantJugadores.Text = Convert.ToString(dto.CantidadDeJugadores);
            dtpFechaInicio.Value = dto.FechaInicio;
            dtpFechaFin.Value = dto.FechaFin;
            dtpFechaInicioInscripciones.Value = dto.FechaInicioDeInscripciones;
            dtpFechaFinInscripciones.Value = dto.FechaFinDeInscripciones;
            txtResultado.Text = dto.Resultado;
            cmbRegion.SelectedItem = dto.Region;
            cmbEstado.SelectedItem = dto.Estado;
            torneoDTO = dto;
        }

        public async Task AgregaryActualizarTorneo()
        {
            if (!int.TryParse(txtCantJugadores.Text, out int numero) || numero <= 0)
            {
                MessageBox.Show("Por favor, en cantidad de jugadores, ingrese un numero entero positivo.", "Error de Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantJugadores.Focus();
                return;
            }

            if (cmbJuego.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un juego.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbJuego.Focus();
                return;
            }

            if (cmbTipoTorneo.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de torneo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoTorneo.Focus();
                return;
            }

            if (cmbRegion.SelectedItem == null || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una región y un estado válidos.");
                return;
            }


            TorneoDTO dto = new TorneoDTO
            {
                Id = 0,
                Nombre = txtNombre.Text,
                DescripcionDeReglas = txtReglas.Text,
                CantidadDeJugadores = Convert.ToInt32(txtCantJugadores.Text),
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value,
                FechaInicioDeInscripciones = dtpFechaInicioInscripciones.Value,
                FechaFinDeInscripciones = dtpFechaFinInscripciones.Value,
                Resultado = txtResultado.Text,
                Region = cmbRegion.SelectedItem.ToString(),
                Estado = cmbEstado.SelectedItem.ToString(),
                JuegoId = (int)cmbJuego.SelectedValue,
                TipoDeTorneoId = (int)cmbTipoTorneo.SelectedValue
            };

            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id = torneoDTO.Id;
                await TorneoApiClient.UpdateAsync(dto);
                MessageBox.Show("Torneo actualizado exitosamente", "Exito al actualizar");
            }
            else
            {
                await TorneoApiClient.AddAsync(dto);
                MessageBox.Show("Torneo agregado exitosamente", "Exito al agregar");
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


        private async Task CargarComboboxes()
        {
            try
            {
                // Cargar juegos
                var juegos = await JuegoApiClient.GetAllAsync();
                if (juegos == null || !juegos.Any())
                {
                    MessageBox.Show("No se encontraron juegos en la base de datos.");
                }
                else
                {
                    cmbJuego.DataSource = juegos;
                    cmbJuego.DisplayMember = "Nombre";
                    cmbJuego.ValueMember = "Id";
                }

                // Cargar tipos de torneo
                var tipos = await TipoTorneoApiClient.GetAllAsync();
                if (tipos == null || !tipos.Any())
                {
                    MessageBox.Show("No se encontraron tipos de torneo en la base de datos.");
                }
                else
                {
                    cmbTipoTorneo.DataSource = tipos;
                    cmbTipoTorneo.DisplayMember = "Nombre";
                    cmbTipoTorneo.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void TorneoDetalle_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            await CargarComboboxes();
            CargarCombosEstaticos();

            if (torneoDTO != null)
            {
                if (torneoDTO.JuegoId > 0)
                    cmbJuego.SelectedValue = torneoDTO.JuegoId;

                if (torneoDTO.TipoDeTorneoId > 0)
                    cmbTipoTorneo.SelectedValue = torneoDTO.TipoDeTorneoId;

                cmbRegion.SelectedItem = torneoDTO.Region;
                cmbEstado.SelectedItem = torneoDTO.Estado;
            }
            btnAceptar.Enabled = true;
        }

        private void CargarCombosEstaticos()
        {
            // Región
            cmbRegion.Items.Clear();
            cmbRegion.Items.AddRange(new string[] { "LAS", "LAN", "NA", "EUW", "GLOBAL" });
            cmbRegion.SelectedIndex = 0; // por defecto

            // Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Pendiente", "En curso", "Finalizado" });
            cmbEstado.SelectedIndex = 0; // por defecto
        }


    }
}
