using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace LoginAndSignup
{
    public partial class Books : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public Books()
        {
            InitializeComponent();
        }
        private void ClearFields()
        {
            book_IDTextBox.Text = "";
            titleTextBox.Text = "";
            authorTextBox.Text = "";
            publisherTextBox.Text = "";
        }

        private void Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.studentDataSet.Books);
            // TODO: This line of code loads data into the 'studentDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.studentDataSet.Books);
            // TODO: This line of code loads data into the 'studentDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.studentDataSet.Books);

        }


        private void book_IDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void authorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void publisherTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void booksBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Books ([Book ID], Title, Author, Publisher) VALUES ( @BookID, @Title, @Author, @Publisher)";
                command.Parameters.AddWithValue("@BookID", book_IDTextBox.Text);
                command.Parameters.AddWithValue("@Title", titleTextBox.Text);
                command.Parameters.AddWithValue("@Author", authorTextBox.Text);
                command.Parameters.AddWithValue("@Publisher", publisherTextBox.Text);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data saved successfully.");
                }
                else
                {
                    MessageBox.Show("Data not saved.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "DELETE FROM Books WHERE book_ID = @book_ID";
                        command.Parameters.AddWithValue("@book_ID", book_IDTextBox.Text);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
