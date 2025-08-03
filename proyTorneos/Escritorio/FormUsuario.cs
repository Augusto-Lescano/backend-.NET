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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
            //LoadTheme(); por alguna razon no funciona como corresponde por lo tanto lo dejo así
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = ThemeColor.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
        }
    }
}
