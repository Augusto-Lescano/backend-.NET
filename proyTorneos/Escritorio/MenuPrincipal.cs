using DTOs;
using Escritorio.Juego;
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
    public partial class MenuPrincipal : Form
    {
        private UsuarioDTO usuarioActual { get; set; }

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mostrarFormularios(Form form)
        {
            Shared.AjustarFormMDI(form);
            form.ShowDialog();
        }
        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            UsuarioLista usuarioLista = new UsuarioLista(usuarioActual.Admin);
            mostrarFormularios(usuarioLista);
        }

        private void mnuTorneos_Click(object sender, EventArgs e)
        {
            TorneoLista torneoLista = new TorneoLista(usuarioActual.Admin);
            mostrarFormularios(torneoLista);
        }

        private void mnuTipoDeTorneo_Click(object sender, EventArgs e)
        {
            TipoTorneoLista formTipoTorneoLista = new TipoTorneoLista();
            mostrarFormularios(formTipoTorneoLista);
        }

        private void mnuJuegos_Click(object sender, EventArgs e)
        {
            JuegoLista juegoLista = new JuegoLista(usuarioActual.Admin);
            mostrarFormularios(juegoLista);
        }

        private void mnuActualizarPerfil_Click(object sender, EventArgs e)
        {
            UsuarioDetalle detalle = new UsuarioDetalle(usuarioActual, false);
            
            Shared.AjustarFormMDI(detalle);
            detalle.ShowDialog();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            Shared.AjustarFormMDI(login);
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.usuarioActual = login.usuarioActual;
            }
            else {
                this.Dispose();
            }
        }
    }
}
