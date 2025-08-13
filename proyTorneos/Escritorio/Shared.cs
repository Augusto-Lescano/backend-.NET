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
            tabla.RowHeadersVisible = false;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }
    }
}
