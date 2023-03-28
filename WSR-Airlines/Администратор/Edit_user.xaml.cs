using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WSR_Airlines.Администратор
{
    /// <summary>
    /// Логика взаимодействия для Edit_user.xaml
    /// </summary>
    public partial class Edit_user : Window
    {
        string ConnectionString = Settings1.Default.ConnectionString;

        public Edit_user(String email1, String familia1, String name1)
        {
            InitializeComponent();

            email.Text = email1;
            familia.Text = familia1;
            name.Text = name1;

            string Sql1 = "select Title from dbo.Roles";
            SqlConnection connection1 = new SqlConnection(ConnectionString);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(Sql1, connection1);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                role.Items.Add(reader1["Title"].ToString());
            }
            reader1.Close();
            connection1.Close();

            string Sql10 = "select Title from dbo.Offices";
            SqlConnection connection10 = new SqlConnection(ConnectionString);
            connection10.Open();
            SqlCommand command10 = new SqlCommand(Sql10, connection10);
            SqlDataReader reader10 = command10.ExecuteReader();
            while (reader10.Read())
            {
                office.Items.Add(reader10["Title"].ToString());
            }
            reader10.Close();
            connection10.Close();

        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            Admin go = new Admin();
            go.Show();
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Admin go = new Admin();
            go.Show();
            this.Close();
        }


    }
}
