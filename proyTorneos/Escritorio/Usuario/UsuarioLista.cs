using Escritorio.Usuario;
using API.Clients;
using DTOs;
using FastReport;
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
            if (!admin)
            {
                btnEliminar.Visible = false;
            }
        }


        public async Task TablaSimple(DataGridView usuarios)
        {
            usuarios.AutoGenerateColumns = false;
            usuarios.Columns.Clear();

            // Id
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id"
            });

            // NickName
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NombreUsuario",
                DataPropertyName = "NombreUsuario"
            });

            // Email
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email"
            });

            // Nombre
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            });

            // Apellido
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Apellido",
                DataPropertyName = "Apellido"
            });

            // País
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "País",
                DataPropertyName = "Pais"
            });

            // Fecha Alta
            usuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha Alta",
                DataPropertyName = "FechaAlta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Admin (checkbox)
            usuarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Admin",
                DataPropertyName = "Admin"
            });

            usuarios.DataSource = await UsuarioApiClient.GetAllAsync();
        }


        public async Task CargarUsuarios()
        {
            if (Admin)
            {
                await TablaSimple(dgvUsuarios);
            }
            dgvUsuarios.DataSource = await UsuarioApiClient.GetAllAsync();
        }

        public UsuarioDTO SeleccionarUsuario()
        {

            UsuarioDTO dto = (UsuarioDTO)dgvUsuarios.SelectedRows[0].DataBoundItem;
            return dto;
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await BorrarUsuario();
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var usuarios = await UsuarioApiClient.GetAllAsync();
            

            Report report = new Report();

            try
            {

                report.Load("ReporteUsuarios.frx");

                report.RegisterData(usuarios, "proyTorneos");

                report.GetDataSource("proyTorneos").Enabled = true;

                report.Prepare();

                ReporteUsuario visorReporte = new ReporteUsuario(report);
                visorReporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}
