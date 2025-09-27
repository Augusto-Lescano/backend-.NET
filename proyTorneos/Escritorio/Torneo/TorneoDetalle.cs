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
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Escritorio
{
    public partial class TorneoDetalle : Form
    {
        private TorneoDTO torneoDTO { set; get; }
        public TorneoDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar un Torneo";
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
            txtRegion.Text = dto.Region;
            txtEstado.Text = dto.Estado;
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
                Region = txtRegion.Text,
                Estado = txtEstado.Text
            };

            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id=torneoDTO.Id;
                await TorneoApiClient.UpdateAsync(dto);
                MessageBox.Show("Torneo actualizado exitosamente","Exito al actualizar");
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
    }
}
