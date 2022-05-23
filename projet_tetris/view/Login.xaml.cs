using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using projet_tetris.view;
using System.IO;
using System.Data.OleDb;

namespace projet_tetris.model
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Registration registration = new Registration();
        MainWindow mainWindow = new MainWindow();
        Tetris tetris = new Tetris();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            

            String filePath = "../../../data/tetrisDb.accdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + filePath;
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "select Pwd from players where Mail = @mail";
            command.Parameters.AddWithValue("mail", textBoxEmail.Text);
            String password = "";
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                password = reader.GetString(0);
            }

            connection.Close();

            if (String.IsNullOrEmpty(textBoxEmail.Text))
            {
                errormessage.Text = "Entrer un mail.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Entrer un mail valide.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {

                if (password.ToString().Equals(passwordBox1.Password.ToString()))
                {
                    tetris.Show();
                    tetris.Mail = textBoxEmail.Text;
                    Close();
                }
                else
                {
                    errormessage.Text = "Le mail ou le mot de passe est incorrect.";
                }
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
}
