using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamBuilder.UI
{
    public partial class UC_HeaderSettings : UserControl
    {
        [DefaultValue("")]
        public string LogoPicLocation { get; set; }
        [DefaultValue("")]
        public string HeaderPicLocation { get; set; }
        public UC_HeaderSettings()
        {
            InitializeComponent();
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chipCheckPicLogo.Visible = true;
                chipCheckPicLogo.BringToFront();
                chipCheckPicLogo.Parent = guna2ShadowPanel1;
                LogoPicLocation = ofd.FileName;
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                chipCheckPicHeader.Visible = true;
                chipCheckPicHeader.BringToFront();
                chipCheckPicHeader.Parent = guna2ShadowPanel1;
                HeaderPicLocation = ofd.FileName;
            }
        }
    }
}
