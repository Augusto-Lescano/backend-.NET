using DTOs;
using API.Clients;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Escritorio.FormTipoTorneos;

namespace Escritorio
{
    public partial class UsuarioDetalle : Form
    {

        private UsuarioDTO usuario;
        private FormMode mode;
        // Agrega el campo errorProvider como miembro de la clase UsuarioDetalle
        private ErrorProvider errorProvider = new ErrorProvider();
        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                this.SetUsuario();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        public UsuarioDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }

        private void SetUsuario()
        {
            this.txtId.Text = this.Usuario.Id.ToString();
            this.txtNombre.Text = this.Usuario.Nombre;
            this.txtApellido.Text = this.Usuario.Apellido;
            this.txtEmail.Text = this.Usuario.Email;
            this.txtPais.Text = this.Usuario.Pais;
            this.txtGamerTag.Text = this.Usuario.GamerTag;
            this.txtRol.Text = this.Usuario.Rol;
        }
        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                IdLabel.Visible = false;
                txtId.Visible = false;
                RolLabel.Visible = false;
                txtRol.Visible = false;
            }

            if (Mode == FormMode.Update)
            {
                IdLabel.Visible = true;
                txtId.Visible = true;
                RolLabel.Visible = true;
                txtRol.Visible = true;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarUsuario())
            {
                try
                {
                    this.Usuario.Nombre = txtNombre.Text;
                    this.Usuario.Apellido = txtApellido.Text;
                    this.Usuario.Email = txtEmail.Text;
                    this.Usuario.Pais = txtPais.Text;
                    this.Usuario.GamerTag = txtGamerTag.Text;

                    if (this.Mode == FormMode.Update)
                    {
                        await UsuarioApiClient.UpdateAsync(this.Usuario);
                    }
                    else
                    {
                        await UsuarioApiClient.AddAsync(this.Usuario);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarUsuario()
        {
            bool isValid = true;

            errorProvider.SetError(txtNombre, string.Empty);
            errorProvider.SetError(txtApellido, string.Empty);
            errorProvider.SetError(txtEmail, string.Empty);
            errorProvider.SetError(txtPais, string.Empty);
            errorProvider.SetError(txtGamerTag, string.Empty);
            errorProvider.SetError(txtRol, string.Empty);

            if (this.txtNombre.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtNombre, "El Nombre es requerido");
            }

            if (this.txtApellido.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtApellido, "El Apellido es requerido");
            }

            if (this.txtEmail.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtEmail, "El Email es requerido");
            }
            else if (!EsEmailValido(this.txtEmail.Text))
            {
                isValid = false;
                errorProvider.SetError(txtEmail, "El formato del Email no es válido");
            }
            else if (this.txtPais.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtPais, "El Pais es requerido");
            }
            else if (this.txtGamerTag.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtGamerTag, "El Tag es requerido");
            }
            else if (this.txtRol.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(txtRol, "El Rol es requerido");
            }

            return isValid;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
