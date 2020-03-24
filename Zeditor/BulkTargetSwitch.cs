using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeditor
{
    public partial class BulkTargetSwitch : Form
    {
        public long ChangeFrom => Convert.ToInt64(fromBox.Value);
        public long ChangeTo => Convert.ToInt64(toBox.Value);

        public BulkTargetSwitch()
        {
            InitializeComponent();
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
    }
}
