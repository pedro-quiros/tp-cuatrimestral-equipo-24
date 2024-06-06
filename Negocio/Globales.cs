using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Negocio
{
    public class Globales
    {
        public static object decimales(TextBox Cajatexto, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && (~Cajatexto.Text.IndexOf(".")) != 0)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return null;
        }
        public static void DiseñoDtv(ref DataGridView listado)
        {
            listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            listado.BackgroundColor = Color.FromArgb(128, 128, 255);
            listado.EnableHeadersVisualStyles = false;
            listado.BorderStyle = BorderStyle.None;
            listado.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            listado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            listado.RowHeadersVisible = true;
            

            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.FromArgb(29, 29, 29);
            cabecera.ForeColor = Color.White;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
        public static void OcultarColumnas(ref DataGridView listado)
        {
            listado.Columns[0].Visible = false;
            listado.Columns[5].Visible = false;
        }
    }
}
