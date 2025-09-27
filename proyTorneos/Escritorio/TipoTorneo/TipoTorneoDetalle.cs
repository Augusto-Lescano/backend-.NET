using Domain.Model;
using Domain.Services;
using API.Clients;
using DTOs;
using Microsoft.Data.SqlClient.DataClassification;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escritorio
{
    public partial class TipoTorneoDetalle : Form
    {
        private TipoTorneoDTO TipotorneoDTO { set; get; }
        public TipoTorneoDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar un tipo de torneo";
        }

        public TipoTorneoDetalle(TipoTorneoDTO dto)
        {
            InitializeComponent();
            this.Text = "Actualizar un tipo de torneo";
            btnAceptar.Text = "Actualizar";
            txtNombre.Text = dto.Nombre;
            txtDescripcion.Text = dto.Descripcion;
            TipotorneoDTO = dto;
        }

        public async Task AgregaryActualizarTipoTorneo()
        {

            TipoTorneoDTO dto = new TipoTorneoDTO
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
            };

            if (btnAceptar.Text == "Actualizar")
            {
                dto.Id = TipotorneoDTO.Id;
                await API.TipoTorneo.TipoTorneoApiClient.UpdateAsync(dto);
                MessageBox.Show("tipo de torneo actualizado exitosamente", "Exito al actualizar");
            }
            else
            {
                await API.TipoTorneo.TipoTorneoApiClient.AddAsync(dto);
                MessageBox.Show("tipo de torneo agregado exitosamente", "Exito al agregar");
            }
            this.DialogResult = DialogResult.OK;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarTipoTorneo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

