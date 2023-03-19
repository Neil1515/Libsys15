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
    public partial class BooksDetails : Form
    {
        public BooksDetails()
        {
            InitializeComponent();
        }

        private void BooksDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.BorrowedBooks' table. You can move, or remove it, as needed.
            this.borrowedBooksTableAdapter.Fill(this.studentDataSet.BorrowedBooks);

        }
    }
}
