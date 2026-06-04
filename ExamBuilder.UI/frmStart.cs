using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;

namespace ExamBuilder.UI
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var frmAddQuestion = new frmAddQuestions();
            frmAddQuestion.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            var frmManagement = new frmManagementQuestion();
            frmManagement.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var frmCreateExam = new frmCreateExam();
            frmCreateExam.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var frmAddBook = new frmAddBook();
            frmAddBook.Show();
        }
    }
}
