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
        private InscripcionDTO InscripcionDTO { set; get; }
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
            dtpFecha.Value = dto.Fecha;
            InscripcionDTO = dto;
        }

        public async Task AgregaryActualizarInscripcion()
        {
            InscripcionDTO dto = new InscripcionDTO
            {
                Id = 0,
                Estado = txtEstado.Text,
                Fecha = dtpFecha.Value
            };

            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id = InscripcionDTO.Id;
                await API.Clients.InscripcionApiClient.UpdateAsync(dto);
                MessageBox.Show("Inscripción actualizada exitosamente", "Éxito al actualizar");
            }
            else
            {
                await API.Clients.InscripcionApiClient.AddAsync(dto);
                MessageBox.Show("Inscripción agregada exitosamente", "Éxito al agregar");
            }

            this.DialogResult = DialogResult.OK;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarInscripcion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
