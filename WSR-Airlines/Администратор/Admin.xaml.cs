using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using WSR_Airlines.DataSet1TableAdapters;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace WSR_Airlines.Администратор
{

    public partial class Admin : Window
    {
        DataSet1 dataSet1 = new DataSet1();
        UsersTableAdapter UTA = new UsersTableAdapter();
        string ConnectionString = Settings1.Default.ConnectionString;

        public Admin()
        {
            InitializeComponent();

            UTA.Fill(dataSet1.Users);
            data.ItemsSource = dataSet1.Users.DefaultView;
            
            office.Items.Add("Все офисы");
            string Sql1 = "select Title from dbo.Offices";
            SqlConnection connection1 = new SqlConnection(ConnectionString);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(Sql1, connection1);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                office.Items.Add(reader1["Title"].ToString());
            }
            reader1.Close();
            connection1.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add_user go = new Add_user();
            go.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(data.SelectedItem != null) {

                DataRowView row = (DataRowView)data.SelectedItems as DataRowView;
                String email = row.Row["email"].ToString();
                String familia = row.Row["familia"].ToString();
                String name = row.Row["email"].ToString();

                Edit_user go = new Edit_user(email, familia, name);
                go.Show();
                this.Close();
            }
        }

        private void Enable_disable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
