using API.Clients;
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

namespace Escritorio
{
    public partial class Login : Form
    {
        public UsuarioDTO usuarioActual { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private async Task OtorgarAcceso()
        {
            var listaUsuarios = await UsuarioApiClient.GetAllAsync();
            bool usuarioEncontrado = false;

            foreach (var usuario in listaUsuarios)
            {
                if (txtUsuario.Text == usuario.NombreUsuario && txtClave.Text == usuario.Clave)
                {
                    usuarioEncontrado = true;
                    MessageBox.Show("Ingreso exitoso", "Aviso de ingreso");
                    this.usuarioActual = usuario;
                    DialogResult = DialogResult.OK;
                    return;
                }
            }

            // Si no encontró el usuario
            if (!usuarioEncontrado)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Los controles se rehabilita en el método btnAceptar_Click
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitar todos los controles
            DeshabilitarControles();

            // Cambiar texto del botón
            btnAceptar.Text = "Entrando...";

            await OtorgarAcceso();

            // Rehabilitar controles si falla el login
            if (this.DialogResult != DialogResult.OK)
            {
                HabilitarControles();
                btnAceptar.Text = "Aceptar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtClave.Clear();
        }

        private void linkNuevoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsuarioDetalle usuarioDetalle = new UsuarioDetalle(false);
            Shared.AjustarFormMDI(usuarioDetalle);
            usuarioDetalle.ShowDialog();
        }

        private void DeshabilitarControles()
        {
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            txtUsuario.Enabled = false;
            txtClave.Enabled = false;
            linkNuevoUsuario.Enabled = false;
        }

        private void HabilitarControles()
        {
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            txtUsuario.Enabled = true;
            txtClave.Enabled = true;
            linkNuevoUsuario.Enabled = true;
        }
    }
}
