using Domain.Model;
using Domain.Services;
using API.Clients;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio
{
    public partial class EquipoDetalle : Form
    {
        private EquipoDTO EquipoDTO { set; get; }
        private int usuarioConectadoId;

        public EquipoDetalle(int usuarioConectado)
            {
            InitializeComponent();
            this.Text = "Agregar un equipo";
            usuarioConectadoId = usuarioConectado;
        }   

        public EquipoDetalle(EquipoDTO dto)
        {   
            InitializeComponent();
            this.Text = "Actualizar un equipo";
            btnAceptar.Text = "Actualizar";
            txtNombre.Text = dto.Nombre;
            EquipoDTO = dto;
        }

        public async Task AgregaryActualizarEquipo()
        {
            EquipoDTO dto = new EquipoDTO
            {
                Id = 0,
                Nombre = txtNombre.Text
            };

            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id = EquipoDTO.Id;
                await API.Clients.EquipoApiClient.UpdateAsync(dto);
                MessageBox.Show("Equipo actualizado exitosamente", "Éxito al actualizar");
            }
            else
            {
                dto.LiderId = usuarioConectadoId;
                await API.Clients.EquipoApiClient.AddAsync(dto);
                MessageBox.Show("Equipo agregado exitosamente", "Éxito al agregar");
            }

            this.DialogResult = DialogResult.OK;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarEquipo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
