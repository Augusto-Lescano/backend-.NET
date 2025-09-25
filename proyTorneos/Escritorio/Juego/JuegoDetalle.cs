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

namespace Escritorio.Juego
{
    public partial class JuegoDetalle : Form

    {
        private JuegoDTO juegoDTO { set; get; }
        public JuegoDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar un Juego";
        }

        public JuegoDetalle(JuegoDTO dto)
        {
            InitializeComponent();
            this.Text = "Actualizar un juego";
            btnAceptar.Text = "Actualizar";
            txtNombre.Text = dto.Nombre;
            txtDescripcion.Text = dto.Descripcion;
            juegoDTO = dto;
        }

        public async Task AgregaryActualizarJuego()
        {
            JuegoDTO dto = new JuegoDTO
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
            };
            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id = juegoDTO.Id;
                await JuegoApiClient.UpdateAsync(dto);
                MessageBox.Show("Juego actualizado exitosamente", "Exito al actualizar");
            }
            else
            {
                await JuegoApiClient.AddAsync(dto);
                MessageBox.Show("Juego agregado exitosamente", "Exito al agregar");
            }
            this.DialogResult = DialogResult.OK;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarJuego();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

}
