using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiMpge.HI;

namespace HiMpge
{
    public partial class Mp4Player : Form
    {
        public Mp4Player()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var decAttr = new hi_h264dec.hiH264_DEC_ATTR_S();
        }
    }
}
