using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoulsFormats;
using SoulsFormats.ESD;

namespace Zeditor
{
    public partial class PropertyEditor : Form
    {

        ESD currentESD;

        public PropertyEditor(ESD esd)
        {
            currentESD = esd;
            InitializeComponent();
            compressionBox.DataSource = Enum.GetValues(typeof(DCX.Type)).Cast<DCX.Type>().ToList();
            compressionBox.SelectedItem = currentESD.Compression;

            if (currentESD.DarkSoulsCount == 1) DS1_Btn.Checked = true;
            else if (currentESD.DarkSoulsCount == 2) DS2BB_Btn.Checked = true;
            else if (currentESD.DarkSoulsCount == 3) DS3_Btn.Checked = true;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            currentESD.Compression = (DCX.Type) compressionBox.SelectedItem;
            if (DS1_Btn.Checked) currentESD.DarkSoulsCount = 1;
            else if (DS2BB_Btn.Checked) currentESD.DarkSoulsCount = 2;
            else if (DS3_Btn.Checked) currentESD.DarkSoulsCount = 3;
            currentESD.Name = String.IsNullOrWhiteSpace(nameBox.Text) ? null : nameBox.Text.Trim();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
