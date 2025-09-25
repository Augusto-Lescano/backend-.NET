using DTOs;
using API.Clients;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Escritorio.FormTipoTorneos;

namespace Escritorio
{
    public partial class UsuarioDetalle : Form
    {
        public UsuarioDTO UsuarioCreado { get; set; }

        // Constructor para AGREGAR
        public UsuarioDetalle()
        {
            InitializeComponent();
            this.Text = "Agregar Usuario";
        }

        // Constructor para MODIFICAR
        public UsuarioDetalle(UsuarioDTO dto)
        {
            InitializeComponent();
            Text = "Modificar Usuario";
            btnAceptar.Text = "Modificar";
            txtNombre.Text = dto.Nombre;
            txtApellido.Text = dto.Apellido;
            txtEmail.Text = dto.Email;
            txtClave.Text = dto.Clave;
            txtPais.Text = dto.Pais;
            txtNombreUsuario.Text = dto.NombreUsuario;
            txtRol.Text = dto.Rol;
            UsuarioCreado = dto;
        }

        public async Task AgregaryActualizarUsuario()
        {
            UsuarioDTO dto = new UsuarioDTO
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Clave = txtClave.Text,
                Pais = txtPais.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Rol = txtRol.Text,

            };
            if (btnAceptar.Text == "Modificar")
            {
                dto.Id = UsuarioCreado.Id;
                await UsuarioApiClient.UpdateAsync(dto);
                MessageBox.Show("Usuario modificado exitosamente", "Exito al modificar");
            }
            else
            {
                await UsuarioApiClient.AddAsync(dto);
                MessageBox.Show("Usuario agregado exitosamente", "Exito al agregar");
            }
            this.DialogResult = DialogResult.OK;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await AgregaryActualizarUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
