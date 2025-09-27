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
            foreach (var usuario in listaUsuarios)
            {
                if (txtUsuario.Text == usuario.NombreUsuario && txtClave.Text == usuario.Clave)
                {
                    MessageBox.Show("Ingreso exitoso","Aviso de ingreso");
                    this.usuarioActual=usuario;
                    DialogResult = DialogResult.OK;
                    
                }
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await OtorgarAcceso();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtClave.Clear();
        }

        private void linkNuevoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsuarioDetalle usuarioDetalle = new UsuarioDetalle();
            usuarioDetalle.PermitirAdmin = false;
            Shared.AjustarFormMDI(usuarioDetalle);
            usuarioDetalle.ShowDialog();
        }
    }
}
