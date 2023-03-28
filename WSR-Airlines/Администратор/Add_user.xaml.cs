using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

namespace WSR_Airlines.Администратор
{
    /// <summary>
    /// Логика взаимодействия для Add_user.xaml
    /// </summary>
    public partial class Add_user : Window
    {
        DataSet1 dataSet1 = new DataSet1();
        UsersTableAdapter UTA = new UsersTableAdapter();
        RolesTableAdapter RTA = new RolesTableAdapter();
        OfficesTableAdapter OTA = new OfficesTableAdapter();
        string ConnectionString = Settings1.Default.ConnectionString;

        public Add_user()
        {
            InitializeComponent();
            UTA.Fill(dataSet1.Users);
            RTA.Fill(dataSet1.Roles);
            OTA.Fill(dataSet1.Offices);

            //role.DisplayMemberPath = "Roles";
            //role.ItemsSource = dataSet1.Roles.AsDataView();
            //role.SelectedIndex = -1;

            //office.DisplayMemberPath = "Offices";
            //office.ItemsSource = dataSet1.Offices.AsDataView();
            //office.SelectedIndex = -1;

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int roleint;
            DateTime? selectedDate = date.SelectedDate.Value.Date;
            UTA.Insert(role.Text, email.Text, password.Text, familia.Text, name.Text, office.Text, selectedDate, true );
            UTA.Fill(dataSet1.Users);

            MessageBox.Show("Пользователь: " + email.Text + " добавлен!");

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
