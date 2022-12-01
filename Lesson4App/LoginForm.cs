using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace Lesson4App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        { 
            string username = usernameTextBox.Text; 
            string password = passwordTextBox.Text; 

            if (username.Trim() == "" && password.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error");
            }
            else
            {
                string query = "SELECT * FROM user WHERE username = @username AND password = @password";
                SQLiteConnection conn = new SQLiteConnection("Data Source=lessonDb.db; Version=3");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Successfully loged in");
                }
                else
                {
                    MessageBox.Show("Wrong login details");
                }

            }

            /* if(username.Trim() == "" && password.Trim() == "")
             {
                 MessageBox.Show("Textbox are emty");
             }
             else
             {

                 string query = "SELECT * FROM user password = @password";
                 SQLiteConnection conn = new SQLiteConnection("Data Source=lessonDb.db; Version=3");
                 conn.Open();
                 SQLiteCommand cmd = new SQLiteCommand(query, conn);
                 cmd.Parameters.AddWithValue("@password", password);
                 SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);

                 if(dt.Rows.Count > 0)
                 {
                     MessageBox.Show("Login succesfully");
                 }
                 else
                 {
                     MessageBox.Show("Failed to logain");
                 }

             }*/

        }
    }
}
