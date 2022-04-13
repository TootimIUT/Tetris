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

using Oracle.ManagedDataAccess.Client;

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
            /*using (OracleConnection oc = new OracleConnection())
            {
                
                oc.ConnectionString = "User ID=USER1; Password=PASS2; Data Source=DS_TEST;";
                oc.Open();

                //string sql = "SELECT COL_NO, COL_NAME FROM EMP ORDER BY 1";

                OracleDataAdapter oda = new OracleDataAdapter(sql, oc);
                DataTable dt = new DataTable();
                oda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(String.Format("{0} : {1}", dr["COL_NO"], dr["COL_NAME"]));
                }

                ////Dapperテスト
                //oc.Query("SELECT COL_NO, COL_NAME FROM EMP ORDER BY 1")
                //  .ToList()
                //  .ForEach(r => Console.WriteLine(String.Format("{0} : {1}", r.COL_NO, r.COL_NAME)));
            }*/
        }
        Registration registration = new Registration();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
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
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;

                // Connexion BDD  
               /* SqlConnection con = new SqlConnection(@"Data Source=USER;Initial Catalog=admin;Integrated Security=True");  
                con.Open();

                //Verification Compte existant
                SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {  
                    MainWindow.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Le mail ou le mot de passe est incorrect.";
                }
                //Fermeture connexion BDD
                con.Close();*/
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
}
