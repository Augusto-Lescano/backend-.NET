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

namespace Escritorio.Juego
{
    public partial class JuegoLista : Form
    {
        private bool Admin { get; set; }
        public JuegoLista(bool admin)
        {
            InitializeComponent(); 
            Admin = admin;
            if (!admin) {
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }


        public async Task CargarJuegos()
        {
            dgvListaJuegos.DataSource = await JuegoApiClient.GetAllAsync();
        }

        public JuegoDTO SeleccionarJuego()
        {
            JuegoDTO dto = (JuegoDTO)dgvListaJuegos.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarJuego()
        {
            JuegoDetalle detalle = new JuegoDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarJuegos();
            }
        }

        public async Task ActualizarJuego()
        {
            var juego = SeleccionarJuego();
            if (juego == null)
            {
                MessageBox.Show("No puede actualizar un juego sin haber seleccionado uno anteriormente", "Error al actualizar juego");
            }
            else
            {
                var detalle = new JuegoDetalle(juego);
                Shared.AjustarFormMDI(detalle);
                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarJuegos();
                }
            }
        }
        public async Task BorrarJuego()
        {
            var juego = SeleccionarJuego();
            if (juego == null)
            {
                MessageBox.Show("No puede borrar un juego sin haber seleccionado uno anteriormente", "Error al borrar juego");
            }
            else
            {
                await JuegoApiClient.DeleteAsync(juego.Id);
                MessageBox.Show("Juego borrado exitosamente", "Exito al borrar");
            }
            await CargarJuegos();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarJuego();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualizarJuego();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarJuego();
        }
    }
    
}
