using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordParser
{
    public partial class Form2 : Form
    {
        public Form2(List<Keyword> lKeyword)
        {
            InitializeComponent();
            dataGridView1.DataSource = lKeyword;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = (dataGridView1.DataSource as List<Keyword>)[e.RowIndex].isIgnored?Color.Gray: Color.White;
            
        }
    }
}
