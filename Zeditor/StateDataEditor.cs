using SoulsFormats.ESD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Zeditor
{
    public partial class StateDataEditor : Form
    {
        public long StateID => Convert.ToInt64(idBox.Value);
        public string StateName => nameBox.Text.Trim();
        public StateDataEditor(ESD.State state)
        {
            InitializeComponent();
            nameBox.Text = state.Name;
            idBox.Value = state.ID;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(StateName, @"State(0|1)-\d+"))
            {
                nameBox.Text = StateName.Substring(0, 7) + StateID;
            }
        }
    }
}
