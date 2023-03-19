using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginAndSignup
{
    public partial class Borrower : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public Borrower()
        {
            InitializeComponent();
        }

        private void Borrower_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentDataSet.Student);
        }

        private void ClearFields()
        {
            studentidTextBox.Text = "";
            nameTextBox.Text = "";
            courseTextBox.Text = "";
            departmentTextBox.Text = "";
        }

        private void studentidTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void courseTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void departmentTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Student ( studentid, name, Course, department) VALUES ( @studentid, @name, @course, @department)";
                command.Parameters.AddWithValue("@studentid", studentidTextBox.Text);
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                command.Parameters.AddWithValue("@course", courseTextBox.Text);
                command.Parameters.AddWithValue("@department", departmentTextBox.Text);

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

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Neil_Property\3rd year\2nd Sem\07310-INFORMATION MANAGEMENT (DB SYS. 2)\Login\LoginAndSignup\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Student WHERE studentid = @studentid";
                command.Parameters.AddWithValue("@studentid", studentidTextBox.Text);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data deleted successfully.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Data not deleted.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
