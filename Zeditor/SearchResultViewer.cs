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

namespace Zeditor
{
    public partial class SearchResultViewer : Form
    {
        public SearchResultViewer(Dictionary<ESD.Condition, List<long>> results)
        {
            InitializeComponent();
            dgv.Columns.Add("Condition", "Condition");
            dgv.Columns.Add("States", "States");
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (var kv in results)
            {
                dgv.Rows.Add(kv.Key.Name, string.Join(",", kv.Value));
            }
        }
    }
}
