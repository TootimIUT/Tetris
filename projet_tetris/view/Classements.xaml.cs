using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace projet_tetris.view
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Classements : Window
    {
        public Classements()
        {
            InitializeComponent();

            String filePath = "../../../data/tetrisDb.accdb";
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + filePath;
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "select Pseudo, Score from scores ORDER BY Score DESC";
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            int i = 1;

            while (reader.Read())
            {
                if (i <= 10)
                {
                    BestPlayersTextArea.Text += i + "\t";
                    BestPlayersTextArea.Text += reader.GetString(0) + " : " + reader.GetInt32(1);
                    BestPlayersTextArea.Text += "\n";
                    i++;
                }
            }

            connection.Close();
        }
    }
}
