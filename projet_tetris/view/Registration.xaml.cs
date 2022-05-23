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
    /// Interaction logic for Registration.xaml  
    /// </summary>  
    /// 

    public partial class Registration : Window
    {

        public const string dossierDonnees = @"..\..\..\data\";

        public List<CJoueurs> joueurs = new List<CJoueurs>();
        public List<CScores> scores = new List<CScores>();

        public Registration()
        {
            InitializeComponent();

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxFirstName.Text.Length == 0)
            {
                errormessage.Text = "Entrer un pseudo.";
                textBoxEmail.Focus();
            }

            else if (textBoxEmail.Text.Length == 0)
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

            else if (passwordBox1.Password.Length == 0)
            {
                errormessage.Text = "Entrer un mot de passe.";
                passwordBox1.Focus();
            }

            else if (passwordBoxConfirm.Password.Length == 0)
            {
                errormessage.Text = "Confirmer le mot de passe.";
                passwordBoxConfirm.Focus();
            }

            else if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                errormessage.Text = "Les mots de passe ne correspondent pas.";
                passwordBoxConfirm.Focus();
            }

            else
            {
                String filePath = "../../../data/tetrisDb.accdb";
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + filePath;
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "select count(mail) from players where Mail = @mail";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("mail", textBoxEmail.Text);
                int mail = 0;
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    mail = reader.GetInt32(0);
                }

                connection.Close();

                command = connection.CreateCommand();
                command.Parameters.Clear();
                command.CommandText = "select count(Pseudo) from players where Pseudo = @Pseudo";
                command.Parameters.AddWithValue("Pseudo", textBoxFirstName.Text);
                int pseudo = 0;
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pseudo = reader.GetInt32(0);
                }

                connection.Close();

                if (mail != 0)
                {
                    errormessage.Text = "Ce mail est déja utilisé.";
                    textBoxEmail.Focus();
                }

                else if (pseudo != 0)
                {
                    errormessage.Text = "Ce pseudo est déja utilisé.";
                    textBoxEmail.Focus();
                }

                else
                {

                    errormessage.Text = "";

                    OleDbCommand command2 = connection.CreateCommand();
                    command2.Parameters.Clear();
                    command2.CommandText = "INSERT INTO players (Pseudo, Pwd, Mail) VALUES (@pseudo, @password, @mail)";
                    command2.Parameters.AddWithValue("pseudo", textBoxFirstName.Text);
                    command2.Parameters.AddWithValue("password", passwordBox1.Password);
                    command2.Parameters.AddWithValue("mail", textBoxEmail.Text);
                    connection.Open();
                    command2.ExecuteNonQuery();
                    connection.Close();

                    Login login = new Login();
                    login.Show();
                    Close();
                }
            }
        }
    }
}

