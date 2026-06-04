using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using ExamBuilder.Shared;
using Guna.UI2.WinForms;

namespace ExamBuilder.UI
{
    public class frmStyle : Form
    {
        public void ShowSuccess(string message)
        {
            SystemSounds.Asterisk.Play();
            var bunifuSnackbar = new BunifuSnackbar();
            bunifuSnackbar.Show(
                this,
                message,
                BunifuSnackbar.MessageTypes.Success,
                3000,
                null,
                BunifuSnackbar.Positions.BottomLeft
            );
        }

        public void ShowError(string message)
        {
            SystemSounds.Hand.Play();
            var bunifuSnackbar = new BunifuSnackbar();
            bunifuSnackbar.Show(
                this,
                message,
                BunifuSnackbar.MessageTypes.Error,
                5000, 
                null,
                BunifuSnackbar.Positions.BottomLeft
            );
        }
        public DialogResult ShowWarningQuestion(string message)
        {
            var result = MessageBox.Show(message, Messages.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            return result;
        }
    }
}
