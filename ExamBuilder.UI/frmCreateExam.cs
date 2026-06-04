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

namespace ExamBuilder.UI
{
    public partial class frmCreateExam : frmStyle
    {
        private UserControl currentControl;
        private int _currentStep = 1;
        private UC_ExamInfo _step1;
        private UC_LessonSelection _step2;
        private UC_HeaderSettings _step3;
        private UC_ExamInfo _step4;
        private UC_Output _step5;

        public frmCreateExam()
        {
            InitializeComponent();
            _step1 = new UC_ExamInfo();
            _step2 = new UC_LessonSelection();
            _step3 = new UC_HeaderSettings();
            _step4 = new UC_ExamInfo();
            _step5 = new UC_Output();
        }

        private void frmCreateExam_Load(object sender, EventArgs e)
        {
            LoadControl(_step1);
        }
        private void GoToStep(int step)
        {
            _currentStep = step;

            switch (step)
            {
                case 1:
                    step1.Checked = true;
                    LoadControl(_step1);
                    break;

                case 2:
                    step2.Checked = true;
                    _step2.BookName = _step1.BookName;
                    LoadControl(_step2);
                    break;

                case 3:
                    step3.Checked = true;
                    LoadControl(_step3);
                    break;

                case 4:
                    step4.Checked = true;
                    LoadControl(_step4);
                    break;

                case 5:
                    step5.Checked = true;
                    LoadControl(_step5);
                    break;
            }
            UpdateNavigationButtons();
        }
        private void UpdateNavigationButtons()
        {
            btnPrivious.Enabled = _currentStep > 1;

            if (_currentStep == 5)
                btnNext.Text = "تولید آزمون";
            else
                btnNext.Text = "بعدی";
        }
        private OprationResult ValidateCurrentStep()
        {
            switch (_currentStep)
            {
                case 1:
                    return _step1.ValidateData();

                case 2:
                    return _step2.ValidateData();

                //case 4:
                //    return _step4.ValidateData();

                default:
                    return OprationResult.Success();
            }
        }
        private void LoadControl(UserControl control)
        {
            if (currentControl != null)
            {
                guna2Transition1.HideSync(currentControl);

                pnlContainer.Controls.Remove(currentControl);
            }
            pnlContainer.Controls.Add(control);
            control.BringToFront();
            guna2Transition1.ShowSync(control);
            currentControl = control;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var valid = ValidateCurrentStep();
            if (!valid.IsSuccess)
            {
                ShowError(valid.Message);
                return;
            }

            if (_currentStep < 5)
            {
                GoToStep(_currentStep + 1);
            }
            else
            {
                ShowSuccess("آزمون ساخته شد");
            }
        }

        private void btnPrivious_Click(object sender, EventArgs e)
        {
            if (_currentStep > 1)
            {
                GoToStep(_currentStep - 1);
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
