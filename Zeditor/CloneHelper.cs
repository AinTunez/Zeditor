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
    public partial class CloneHelper : Form
    {
        public long TargetID => Convert.ToInt64(stateSelect.Value);

        public CloneHelper()
        {
            InitializeComponent();
        }

        private void cloneBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void abortBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
