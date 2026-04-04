using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamBuilder.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamBuilder.UI
{
    public partial class UC_FillInBlankItem : UserControl
    {
        public string Item_Text => txtItemName.Text.Trim();
        public UC_FillInBlankItem(int _count)
        {
            InitializeComponent();
            lblCount.Text = _count.ToString();
        }

        private void btnAddBlank_Click(object sender, EventArgs e)
        {
            int selectionStart = txtItemName.SelectionStart;
            int selectionLength = txtItemName.SelectionLength;
            if (selectionLength > 0)
            {
                txtItemName.Text = txtItemName.Text.Remove(selectionStart, selectionLength);
            }
            txtItemName.Text = txtItemName.Text.Insert(selectionStart, Messages.Blank_Marker);
            txtItemName.SelectionStart = selectionStart + Messages.Blank_Marker.Length;
            txtItemName.ScrollToCaret();
            txtItemName.Focus();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
