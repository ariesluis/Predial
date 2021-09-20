using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avaluos.Util
{
    class Controller
    {
        public static void ClearControl(Control control)
        {
            var textbox = control as TextBox;
            if (textbox != null)
                textbox.Text = string.Empty;

            var nud = control as NumericUpDown;
            if (nud != null)
                nud.Value = nud.Minimum;

            var cbo = control as ComboBox;
            if (cbo != null)
                cbo.SelectedIndex = 0;

            var dgv = control as DataGridView;
            if (dgv != null)
                dgv.Columns.Clear();

            foreach (Control childControl in control.Controls)
            {
                ClearControl(childControl);
            }
        }

        public static bool nullBlank(Control control)
        {
            bool b = true;

            var textbox = control as TextBox;
            if (textbox != null)
            {
                if (textbox.Text.Trim() == "")
                    b = false;
            }
            else
                b = false;
            foreach (Control childControl in control.Controls)
            {
                ClearControl(childControl);
            }
            return b;
        }

        public static bool nullcbo(Control control)
        {
            bool b = true;

            var cbo = control as ComboBox;
            if (cbo != null)
            {
                if (cbo.SelectedIndex < 0)
                    b = false;
            }
            else
                b = false;

            foreach (Control childControl in control.Controls)
            {
                ClearControl(childControl);
            }
            return b;
        }

        public static void clearCombobox(Control control)
        {
            var cbo = control as ComboBox;
            if (cbo != null)
            {
                if(cbo.Items.Count < 17)
                    cbo.Items.Clear();
            }

            foreach (Control childControl in control.Controls)
            {
                clearCombobox(childControl);
            }
        }
    }
}
