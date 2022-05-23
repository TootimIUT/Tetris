using projet_tetris.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using projet_tetris.view;
using System.Data.OleDb;

namespace projet_tetris.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Tetris : Window
    {
        public string Mail = "";
        public int Score = 0;

        public Tetris()
        {
            InitializeComponent();
        }

        Classements classements = new Classements();

        private void Disconnect_Click(object sender, RoutedEventArgs e) { 
            Login login = new Login();
            login.Show();
            Close();
        }

        private void Classement_Click(object sender, RoutedEventArgs e)
        {
            Classements classemnts = new Classements();
            classements.Show();

        }

        private void Gamemode_Click(object sender, RoutedEventArgs e)
        {
        }

        public void Save_Score(object sender, RoutedEventArgs e)
        {
            string Pseudo = "";
            String filePath = "../../../data/tetrisDb.accdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + filePath;
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "select Pseudo from players WHERE Mail = @mail";
            command.Parameters.AddWithValue("mail", Mail);
 
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Pseudo = reader.GetString(0);
            }

            connection.Close();

            OleDbCommand command2 = connection.CreateCommand();
            command2.Parameters.Clear();
            command2.CommandText = "INSERT INTO scores (Pseudo, Score) VALUES (@pseudo, @score)";
            command2.Parameters.AddWithValue("pseudo", Pseudo);
            command2.Parameters.AddWithValue("score", Score);
            connection.Open();
            command2.ExecuteNonQuery();
            connection.Close();
        }
    }
}
