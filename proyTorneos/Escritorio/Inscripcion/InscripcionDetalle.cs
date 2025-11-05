using Domain.Model;
using Domain.Services;
using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class InscripcionDetalle : Form
    {
        private InscripcionDTO InscripcionDTO { get; set; }

        public InscripcionDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar una inscripción";
        }

        public InscripcionDetalle(InscripcionDTO dto)
        {
            InitializeComponent();
            this.Text = "Actualizar una inscripción";
            btnAceptar.Text = "Actualizar";
            txtEstado.Text = dto.Estado;
            dtpFechaApertura.Value = dto.FechaApertura;
            dtpFechaCierre.Value = dto.FechaCierre;
            InscripcionDTO = dto;
        }

        public async Task AgregaryActualizarInscripcion()
        {
            try
            {
                var dto = new InscripcionDTO
                {
                    Id = btnAceptar.Text == "Actualizar" ? InscripcionDTO.Id : 0,
                    Estado = txtEstado.Text,
                    FechaApertura = dtpFechaApertura.Value,
                    FechaCierre = dtpFechaCierre.Value,
                    TorneoId = InscripcionDTO?.TorneoId
                };

                if (btnAceptar.Text == "Actualizar")
                {
                    // Actualiza la inscripción
                    await InscripcionApiClient.UpdateAsync(dto);

                    // Actualiza solo las fechas de inscripción del torneo
                    if (InscripcionDTO?.TorneoId != null)
                    {
                        await TorneoApiClient.UpdateFechasInscripcionAsync(
                            InscripcionDTO.TorneoId.Value,
                            dtpFechaApertura.Value,
                            dtpFechaCierre.Value
                        );
                    }

                    MessageBox.Show("Inscripción actualizada exitosamente", "Éxito al actualizar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await InscripcionApiClient.AddAsync(dto);

                    MessageBox.Show("Inscripción agregada exitosamente", "Éxito al agregar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la inscripción: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarInscripcion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
