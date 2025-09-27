using DTOs;
using API.Clients;
using System.Threading.Tasks;

namespace Escritorio
{
    public partial class UsuarioLista : Form
    {
        private bool Admin { get; set; }
        public UsuarioLista(bool admin)
        {
            InitializeComponent();
            Admin = admin;
            if (!admin) {
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        public async Task TablaSimple(DataGridView usuarios) {

            usuarios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colNickName = new DataGridViewTextBoxColumn();
            colNickName.HeaderText = "NickName";
            colNickName.DataPropertyName = "NombreUsuario";
            usuarios.Columns.Add(colNickName);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            usuarios.Columns.Add(colEmail);

            usuarios.DataSource = await UsuarioApiClient.GetAllAsync();

        }
        public async Task CargarUsuarios()
        {
            if (!Admin) {
                await TablaSimple(dgvUsuarios);
            }
            dgvUsuarios.DataSource = await UsuarioApiClient.GetAllAsync();
        }

        public UsuarioDTO SeleccionarUsuario()
        {

            UsuarioDTO dto = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            return dto;
        }

        public async Task AgregarUsuario()
        {
            UsuarioDetalle detalle = new UsuarioDetalle(true);
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
                var detalle = new UsuarioDetalle(usuario, true);
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
