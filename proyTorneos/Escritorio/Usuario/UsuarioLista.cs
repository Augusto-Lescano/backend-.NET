using Domain.Model;
using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Escritorio.TipoTorneoDetalle;

namespace Escritorio
{
    public partial class UsuarioLista : Form
    {
        public UsuarioLista()
        {
            InitializeComponent();
        }

        public async Task CargarUsuarios()
        {
            dgvUsuarios.DataSource = await UsuarioApiClient.GetAllAsync();
        }

        public UsuarioDTO SeleccionarUsuario()
        {

            UsuarioDTO dto = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarUsuario()
        {
            UsuarioDetalle detalle = new UsuarioDetalle();
            Shared.AjustarFormMDI(detalle);

            if (detalle.ShowDialog() == DialogResult.OK)
            {
                await CargarUsuarios();
            }
        }

        public async Task ActualizarUsuario()
        {
            var usuario = SeleccionarUsuario();
            if (usuario == null)
            {
                MessageBox.Show("No puede modificar un usuario sin haber seleccionado uno anteriormente", "Error al modificar usuario");
                return;
            }
            else
            {
                var detalle = new UsuarioDetalle(usuario);
                Shared.AjustarFormMDI(detalle);
                if (detalle.ShowDialog() == DialogResult.OK)
                {
                    await CargarUsuarios();
                }
            }
        }

        public async Task BorrarUsuario()
        {
            var usuario = SeleccionarUsuario();
            if (usuario == null)
            {
                MessageBox.Show("No puede borrar un usuario sin haber seleccionado uno anteriormente", "Error al borrar usuario");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "¿Desea eliminar el usuario seleccionado?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await UsuarioApiClient.DeleteAsync(usuario.Id);
                    MessageBox.Show("Usuario borrado exitosamente", "Exito al borrar");
                }
                else
                {
                    MessageBox.Show("Operación cancelada", "Confirmacion");
                }
            }
            await CargarUsuarios();
        }

        private async void Usuarios_Load(object sender, EventArgs e)
        {
            Shared.AjustarDataGridView(dgvUsuarios);
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            await CargarUsuarios();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            await AgregarUsuario();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ActualizarUsuario();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarUsuario();
        }
    }
}
