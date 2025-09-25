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
            UsuarioLista usuarioLista = new UsuarioLista();
            mostrarFormularios(usuarioLista);
        }

        private void mnuTorneos_Click(object sender, EventArgs e)
        {
            TorneoLista torneoLista = new TorneoLista();
            mostrarFormularios(torneoLista);
        }

        private void mnuTipoDeTorneo_Click(object sender, EventArgs e)
        {
            FormTipoTorneos formTipoTorneo = new FormTipoTorneos();
            mostrarFormularios(formTipoTorneo);
        }
    }
}
