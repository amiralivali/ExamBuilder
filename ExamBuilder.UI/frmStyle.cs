using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
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
                BunifuSnackbar.Positions.BottomRight
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
                BunifuSnackbar.Positions.BottomRight
            );
        }
        public DialogResult ShowWarningQuestion(string message)
        {
            SystemSounds.Exclamation.Play();
            var guna2MessageDialog = new Guna2MessageDialog();
            guna2MessageDialog.Text = message; 
            guna2MessageDialog.Caption = "اخطار";
            guna2MessageDialog.Icon=MessageDialogIcon.Warning;
            guna2MessageDialog.Style = MessageDialogStyle.Light;
            guna2MessageDialog.Buttons = MessageDialogButtons.YesNo; 
            var result = guna2MessageDialog.Show();
            return result;
        }
    }
}
