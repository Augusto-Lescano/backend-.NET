using DTOs;
using API.Clients;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Escritorio.TipoTorneoDetalle;

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
        public UsuarioDetalle(UsuarioDTO dto, bool fromMenuPrincipal)
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
            
            if (fromMenuPrincipal) {
                checkBoxAdmin.Visible = false;
            }
            
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
                Clave = txtClave.Text?.Trim(),
                Pais = txtPais.Text,
                NombreUsuario = txtNombreUsuario.Text,
                
            };

            if (string.IsNullOrWhiteSpace(dto.Clave))
            {
                MessageBox.Show("La contraseña es obligatoria y no puede estar vacía.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (dto.Clave.Length < 8 || dto.Clave.Length > 15)  
            {
                MessageBox.Show("La contraseña debe contener entre 8 y 15 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show(
                    "El email debe contener '@' y un dominio válido (ej: usuario@dominio.com).",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtEmail.Focus();
                return;
            }

            if (btnAceptar.Text == "Modificar")
            {
                dto.Id = UsuarioCreado.Id;
                dto.FechaAlta = UsuarioCreado.FechaAlta;
                dto.Admin=checkBoxAdmin.Checked;
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
