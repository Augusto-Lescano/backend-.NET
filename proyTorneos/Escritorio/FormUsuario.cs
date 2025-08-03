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
using Domain.Model;

namespace Escritorio
{
    public partial class FormUsuario : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7216")
        };

        public FormUsuario()
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
            if (!int.TryParse(txtId.Text, out var id))
            {
                MessageBox.Show("El ID debe ser un número entero válido");
                return;
            }

            var usuario = new Usuario()
            {
                Id = id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Pais = txtPais.Text,
                GamerTag = txtGamerTag.Text,
                Rol = txtRol.Text,
            };

            var response = await _httpClient.PostAsJsonAsync("usuarios", usuario);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuario agregado con éxito");
                await CargarUsuariosAsync();
            }
            else
            {
                MessageBox.Show("Error al agregar el usuario");
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var id))
            {
                MessageBox.Show("El ID debe ser un número entero válido");
                return;
            }

            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuario usuarioSeleccionado)
            {
                usuarioSeleccionado.Id = id;
                usuarioSeleccionado.Nombre = txtNombre.Text;
                usuarioSeleccionado.Apellido = txtApellido.Text;
                usuarioSeleccionado.Email = txtEmail.Text;
                usuarioSeleccionado.Pais = txtPais.Text;
                usuarioSeleccionado.GamerTag = txtGamerTag.Text;
                usuarioSeleccionado.Rol = txtRol.Text;

                var response = await _httpClient.PutAsJsonAsync($"usuarios/{usuarioSeleccionado.Id}", usuarioSeleccionado);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Usuario modificado con éxito");
                    await CargarUsuariosAsync();
                }
                else
                {
                    MessageBox.Show("Error al modificar usuario");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario de la grilla");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuario usuarioSeleccionado)
            {
                var confirm = MessageBox.Show($"¿Eliminar al usuario {usuarioSeleccionado.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    var response = await _httpClient.DeleteAsync($"usuarios/{usuarioSeleccionado.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario eliminado");
                        await CargarUsuariosAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar al usuario");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario de la grilla");
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuario usuario)
            {
                txtId.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtEmail.Text = usuario.Email;
                txtPais.Text = usuario.Pais;
                txtGamerTag.Text = usuario.GamerTag;
                txtRol.Text = usuario.Rol;
            }
        }
    }
}
