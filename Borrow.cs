using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginAndSignup
{
    public partial class Borrow : Form
    {

        public Borrow()
        {
            InitializeComponent();
        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.studentDataSet.Books);
            // TODO: This line of code loads data into the 'studentDataSet.BorrowedBooks' table. You can move, or remove it, as needed.
            this.borrowedBooksTableAdapter.Fill(this.studentDataSet.BorrowedBooks);
            // TODO: This line of code loads data into the 'studentDataSet.BorrowedBooks' table. You can move, or remove it, as needed.
            this.borrowedBooksTableAdapter.Fill(this.studentDataSet.BorrowedBooks);
            // TODO: This line of code loads data into the 'studentDataSet.BorrowedBooks' table. You can move, or remove it, as needed.
            this.borrowedBooksTableAdapter.Fill(this.studentDataSet.BorrowedBooks);
            // TODO: This line of code loads data into the 'studentDataSet.BorrowedBooks' table. You can move, or remove it, as needed.
            this.borrowedBooksTableAdapter.Fill(this.studentDataSet.BorrowedBooks);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Retrieve the book ID from the textbox
            if (!int.TryParse(txtBookID.Text, out int bookID))
            {
                MessageBox.Show("Please enter a valid book ID.");
                return;
            }

            // Check if the book exists in the Books table
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Books WHERE [Book ID] = @BookID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    // The book doesn't exist in the Books table
                    MessageBox.Show("This book doesn't exist in the library.");
                    reader.Close();
                    return;
                }
                reader.Close();
            }

            // Check if the book is available for borrowing
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BorrowedBooks WHERE BookID = @BookID AND ReturnDate IS NULL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // The book is not available for borrowing
                    MessageBox.Show("This book is not available for borrowing at the moment.");
                    reader.Close();
                    return;
                }
                reader.Close();
            }

            // Retrieve the student ID from the textbox
            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid student ID.");
                return;
            }

            // Insert a new record into the BorrowedBooks table
            DateTime borrowDate = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO BorrowedBooks (BookID, StudentID, BorrowDate) VALUES (@BookID, @StudentID, @BorrowDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@BorrowDate", borrowDate);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Book borrowed successfully!");
                }
                else
                {
                    MessageBox.Show("An error occurred while borrowing the book.");
                }
            }
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookID.Text, out int bookID))
            {
                MessageBox.Show("Please enter a valid book ID.");
                return;
            }

            // Check if the book is already returned
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BorrowedBooks WHERE BookID = @BookID AND ReturnDate IS NOT NULL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // The book has already been returned
                    MessageBox.Show("This book has already been returned.");
                    reader.Close();
                    return;
                }
                reader.Close();
            }

            // Update the ReturnDate field in the BorrowedBooks table
            DateTime returnDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE BorrowedBooks SET ReturnDate = @ReturnDate WHERE BookID = @BookID AND ReturnDate IS NULL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@ReturnDate", returnDate);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Book returned successfully!");

                    // Update the Books table to set the book's status to "Available"
                    query = "UPDATE Books SET Status = 'Available' WHERE [Book ID] = @BookID";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    rowsAffected = command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("An error occurred while returning the book.");
                }
            }

        }

        private void BooksDeatailsbtn_Click(object sender, EventArgs e)
        {
            BooksDetails booksDetails = new BooksDetails();
            booksDetails.ShowDialog();
        }
    }
    
}
