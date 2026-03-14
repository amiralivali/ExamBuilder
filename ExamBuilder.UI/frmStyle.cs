using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBuilder.UI
{
    public class frmStyle : Form
    {
        public void ShowSuccess(string message)
        {
            MessageBox.Show(message,"پیغام",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message,"خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        public DialogResult ShowWarningQuestion(string message)
        {
            var result = MessageBox.Show(message,"اخطار",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            return result;
        }
    }
}
