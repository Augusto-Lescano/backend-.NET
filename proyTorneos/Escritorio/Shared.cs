using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escritorio
{
    public static class Shared
    {
        public static void AjustarDataGridView(DataGridView tabla)
        {
            //Oculta la primer columna que sale por defecto en un datagridview
            tabla.RowHeadersVisible = false;

        
            //Si el contenido de una celda es muy largo, se divide en varias lineas
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            
            //Hace que se agrande el tamaño de las celdas para que entre todo el contenido
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            //Hace que las columnas ocupen todo el ancho del datagridview
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }
        public static void AjustarFormMDI(Form formulario) {
            formulario.MinimizeBox = false;
            formulario.MaximizeBox = false;
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.StartPosition=FormStartPosition.CenterParent;
        }
    }
}
