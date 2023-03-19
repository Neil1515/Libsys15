using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginAndSignup
{
    public partial class Home : Form
    {
        private string username;

        public Home(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            

            string usernameFormatted = username.Substring(0, 1).ToUpper() + username.Substring(1);
            label1.Text = $"Welcome, {usernameFormatted}!";
        }

        private void borrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrower barrow = new Borrower();
            barrow.ShowDialog();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {    
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrow barrow = new Borrow();
            barrow.ShowDialog();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksDetails booksDetails = new BooksDetails();
            booksDetails.ShowDialog();
        }

        private void LogOutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
