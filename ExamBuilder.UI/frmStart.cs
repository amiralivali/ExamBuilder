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

        private void guna2ShadowPanel1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void guna2ShadowPanel1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(217, 217, 217);
            label5.BackColor = Color.FromArgb(217, 217, 217);
        }

        private void btnAddQ_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.White;
            label5.BackColor = Color.White;
        }

        private void guna2Button1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(217, 217, 217);
            label1.BackColor = Color.FromArgb(217, 217, 217);
        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            label1.BackColor = Color.White;
        }

        private void guna2Button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(217, 217, 217);
            label2.BackColor = Color.FromArgb(217, 217, 217);
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
            label2.BackColor = Color.White;
        }

        private void guna2Button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(217, 217, 217);
            label3.BackColor = Color.FromArgb(217, 217, 217);
        }

        private void guna2Button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.White;
            label3.BackColor = Color.White;
        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            var frmAddQ = new frmAddQuestions();
            frmAddQ.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var frmAddB = new frmAddBook();
            frmAddB.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var frmManage = new frmManagementQuestion();
            frmManage.Show();
        }
    }
}
