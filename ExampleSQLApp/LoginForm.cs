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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 45);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
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

        private void ButtonBottom_Click(object sender, EventArgs e)
        {
            //подключили данные пользователя
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            //создали 3 объекта
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            /*indicated a specific command that should be executed in relation to the database here 
             * we indicated which database we are connecting to*/
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` =" +
                "@uL and `Password` = @uP", db.getConnection());

            // instead of stubs, specific variables were specified
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            //then chose the desired command - executed it
            adapter.SelectCommand = command;

            //all received data was placed inside the "table" object, which is a table
            adapter.Fill(table); /*some kind of table in which we can count the number of elements. 
                                  * In which we can already refer to each individual element, 
                                  * to each record, etc.*/

            /*checked how many rows (records) we have, if we have at least a few rows,
             * then we know that the user is authorized. Otherwise, no.*/
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Used is authorized");
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("User is not authorized");
            }

        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}
