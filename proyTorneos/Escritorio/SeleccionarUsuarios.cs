using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace Escritorio
{
    public partial class SeleccionarUsuarios : Form
    {
        private readonly List<UsuarioDTO> _usuariosDisponibles;
        public List<UsuarioDTO> UsuariosSeleccionados { get; private set; } = new();

        public SeleccionarUsuarios(IEnumerable<UsuarioDTO> usuarios)
        {
            InitializeComponent();
            _usuariosDisponibles = usuarios.ToList();

            this.Text = "Seleccionar usuarios";
            this.StartPosition = FormStartPosition.CenterParent;

            // Configurar el CheckedListBox
            clbUsuarios.Items.Clear();
            clbUsuarios.CheckOnClick = true;

            foreach (var usuario in _usuariosDisponibles)
            {
                clbUsuarios.Items.Add($"{usuario.Id} - {usuario.NombreUsuario}");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var seleccionados = new List<UsuarioDTO>();

            for (int i = 0; i < clbUsuarios.Items.Count; i++)
            {
                if (clbUsuarios.GetItemChecked(i))
                {
                    seleccionados.Add(_usuariosDisponibles[i]);
                }
            }

            if (!seleccionados.Any())
            {
                MessageBox.Show("Debe seleccionar al menos un usuario.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuariosSeleccionados = seleccionados;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void SeleccionarUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}

