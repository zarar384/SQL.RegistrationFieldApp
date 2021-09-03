using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleSQLApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Enter your name";
            surname.Text = "Enter your surname";
            passField.Text = "Enter your password";
            loginField.Text = "Enter your login";
            userNameField.ForeColor = Color.Gray;
            surname.ForeColor = Color.Gray;
            passField.ForeColor = Color.Gray;
            loginField.ForeColor = Color.Gray;
        }

        private void topText_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        Point lastPoint;

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void CloseButton_MouseLeave_1(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Enter your name")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Enter your name";
                userNameField.ForeColor = Color.Gray;
            }

        }

        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Enter your surname")
            {
                surname.Text = "";
                surname.ForeColor = Color.Black;
            }
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "Enter your surname";
                surname.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Enter your login")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Enter your login";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Enter your password")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Enter your password";
                passField.ForeColor = Color.Gray;
            }
        }

        private void ButtonBottom_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            if (userNameField.Text == "Enter your name")
            {
                MessageBox.Show("Enter your name");
                return;
            }
            if (surname.Text == "Enter your surname")
            {
                MessageBox.Show("Enter your surname");
                return;
            }
            if (loginField.Text == "Enter your login")
            {
                MessageBox.Show("Enter your login");
                return;
            }
            if (passField.Text == "Enter your password")
            {
                MessageBox.Show("Enter your password");
                return;
            }

            if (isUserExist())
            {
                return;
            }

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `Login`, `Password`, `Name`, `Surname`) " +
                "VALUES (@lU, @pU, @nU, @sU);", db.getConnection());

            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@nU", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@sU", MySqlDbType.VarChar).Value = surname.Text;

            //open connection
            db.openConnection();

            //if the sql command we are running is 1 (successful) = account created
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account was created");
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Account wasn't created");
            }

            db.closeConnection();

        }

        public Boolean isUserExist()
        {
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` =" +
                "@uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;



            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This login already exists, please enter another");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
