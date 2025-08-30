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
using static Escritorio.FormTipoTorneos;

namespace Escritorio
{
    public partial class FormUsuarios : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5000")
        };

        public FormUsuarios()
        {
            InitializeComponent();
            //LoadTheme(); por alguna razon no funciona como corresponde por lo tanto lo dejo así
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
        }

        private async void FormUsuario_Load(object sender, EventArgs e)
        {
            await CargarUsuariosAsync();
            Shared.AjustarDataGridView(dgvUsuarios);
        }

        private async Task CargarUsuariosAsync()
        {
            try
            {
                var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Usuario>>("usuarios");
                dgvUsuarios.DataSource = usuarios.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando usuarios: " + ex.Message);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            UsuarioDetalle usuarioDetalle = new UsuarioDetalle();

            UsuarioDTO usuarioNuevo = new UsuarioDTO();

            usuarioDetalle.Mode = FormMode.Add;
            usuarioDetalle.Usuario = usuarioNuevo;

            if (usuarioDetalle.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Usuario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDetalle usuarioDetalle = new UsuarioDetalle();

                int id = this.SelectedItem().Id;

                UsuarioDTO usuario = await UsuarioApiClient.GetAsync(id);

                usuarioDetalle.Mode = FormMode.Update;
                usuarioDetalle.Usuario = usuario;

                if (usuarioDetalle.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuario para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuario = this.SelectedItem();

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el usuario {usuario.Nombre} {usuario.Apellido}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await UsuarioApiClient.DeleteAsync(usuario.Id);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private UsuarioDTO SelectedItem()
        {
            UsuarioDTO usuario;

            usuario = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;

            return usuario;
        }
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
