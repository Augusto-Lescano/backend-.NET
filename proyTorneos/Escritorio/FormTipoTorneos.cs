using Domain.Model;
using Domain.Services;
using DTOs;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escritorio
{
    public partial class FormTipoTorneos : Form
    {

        #region TipoTorneoDetalle
        public enum FormMode
        {
            Add,
            Update
        }
        private TipoTorneoDTO cliente;
        private FormMode mode;
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

        private void SetTipoTorneo()
        {
            //this.txtNombre;
        }
        private void SetFormMode(FormMode value)
        {
            mode = value;

            if (Mode == FormMode.Add)
            {
                nombreLabel.Visible = true;
                txtNombre.Visible = true;
                descLabel.Visible = true;
                txtDescripcion.Visible = true;
            }

            if (Mode == FormMode.Update)
            {
                nombreLabel.Visible = true;
                txtNombre.Visible = true;
                descLabel.Visible = true;
                txtDescripcion.Visible = true; ;
            }
        }
        #endregion

        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:5000")
        };
        public FormTipoTorneos()
        {
            InitializeComponent();
        }

        private async void FormTipoTorneo_Load(object sender, EventArgs e)
        {
            await CargarTipoTorneosAsync();
            Shared.AjustarDataGridView(dgvListaTipoTorneo);
        }

        private async Task CargarTipoTorneosAsync()
        {
            try
            {
                var tipoTorneos = await _httpClient.GetFromJsonAsync<IEnumerable<TipoTorneo>>("tipoTorneos");
                dgvListaTipoTorneo.DataSource = tipoTorneos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando tipo de torneo: " + ex.Message);
            }
        }
        // private async void btnAgregar_Click(object sender, EventArgs e)
        // {
        //    TipoTorneoService tipoTorneoService = new TipoTorneoService();
        //TipoTorneoDTO tipoTorneoNuevo = new TipoTorneoDTO;
        //var tipoTorneo = new TipoTorneo(
        //tipoTorneoService.GetNextId(),
        // txtNombre.Text,
        //txtDescripcion.Text
        //     );

        //var response = await _httpClient.PostAsJsonAsync("tipoTorneos", tipoTorneo);

        // if (response.IsSuccessStatusCode)
        //   {
        //   MessageBox.Show("Tipo de torneo agregado con éxito");
        //         await CargarTipoTorneosAsync();
        //  }
        //  else
        //{
        //    MessageBox.Show("Error al agregar el tipo de torneo");
        //       }
        //  }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListaTipoTorneo.CurrentRow?.DataBoundItem is TipoTorneo tipoTorneoSeleccionado)
            {
                tipoTorneoSeleccionado.Nombre = txtNombre.Text;
                tipoTorneoSeleccionado.Descripcion = txtDescripcion.Text;

                var response = await _httpClient.PutAsJsonAsync<TipoTorneo>($"tipoTorneos/{tipoTorneoSeleccionado.Id}", tipoTorneoSeleccionado);
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Tipo de torneo modificado con éxito");
                    await CargarTipoTorneosAsync();
                }
                else
                {
                    MessageBox.Show("Error al modificar el tipo de torneo");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de torneo de la grilla");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaTipoTorneo.CurrentRow?.DataBoundItem is TipoTorneo tipoTorneoSeleccionado)
            {
                var confirm = MessageBox.Show($"¿Eliminar el tipo de torneo {tipoTorneoSeleccionado.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var response = await _httpClient.DeleteAsync($"tipoTorneos/{tipoTorneoSeleccionado.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Tipo de torneo eliminado");
                        await CargarTipoTorneosAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar al tipo de torneo");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un tipo torneo de la grilla");
                }
            }

        }

        private void dgvListaTipoTorneo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListaTipoTorneo.CurrentRow?.DataBoundItem is TipoTorneo tipoTorneo)
            {
                txtNombre.Text = tipoTorneo.Nombre;
                txtDescripcion.Text = tipoTorneo.Descripcion;
            }
        }

        
    }
}

