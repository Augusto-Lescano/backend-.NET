using API.Clients;
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
            TorneoLista torneoLista = new TorneoLista(usuarioActual);
            mostrarFormularios(torneoLista);
        }

        private void mnuTipoDeTorneo_Click(object sender, EventArgs e)
        {
            TipoTorneoLista formTipoTorneoLista = new TipoTorneoLista(usuarioActual.Admin);
            mostrarFormularios(formTipoTorneoLista);
        }

        private void mnuJuegos_Click(object sender, EventArgs e)
        {
            JuegoLista juegoLista = new JuegoLista(usuarioActual.Admin);
            mostrarFormularios(juegoLista);
        }

        private async void mnuActualizarPerfil_Click(object sender, EventArgs e)
        {
            //Cuando actualizo un usuario y luego vuelvo a querer actualizarlo, el mismo
            //no aparece con los cambios realizados
            //por eso se implementa la siguiente linea de codigo
            UsuarioDTO usuarioActualizado = await UsuarioApiClient.GetAsync(usuarioActual.Id);
            UsuarioDetalle detalle = new UsuarioDetalle(usuarioActualizado, false);
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
                TorneoApiClient.SetUsuarioConectado(usuarioActual.Id);

                //Ocultar menús de administración si no es admin
                if (!usuarioActual.Admin)
                {
                    mnuUsuarios.Visible = false;
                    mnuTipoDeTorneo.Visible = false;
                    mnuJuegos.Visible = false;
                    mnuInscripciones.Visible = false;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void mnuInscripciones_Click(object sender, EventArgs e)
        {
            InscripcionLista inscripcionLista = new InscripcionLista(usuarioActual.Admin);
            mostrarFormularios(inscripcionLista);
        }

        private void mnuEquipos_Click(object sender, EventArgs e)
        {
            EquipoLista equipoLista = new EquipoLista(usuarioActual);
            mostrarFormularios(equipoLista);
        }
    }
}
