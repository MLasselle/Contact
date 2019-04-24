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
using tpGestionContact.Model;
using BLL;



namespace tpGestionContact
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {


            User user = new User
            {
                NickName = txtUser.Text,
                PassWord = txtPassword.Text
            };


            List<User> j = Metodes.ReturneUser();

            int flag = Metodes.ReturneUser().Count;

            for (int i = 0; i < Metodes.ReturneUser().Count; i++)
            {

                if (user.NickName == j[i].NickName && user.PassWord == j[i].PassWord)
                {
                    user.Name = j[i].Name;
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                    flag++;
                }

                flag--;
                if (flag == 0)
                {

                    MessageBox.Show("Password incorrect");

                    txtUser.Text = "";
                    txtPassword.Text = "";


                }
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 createN = new Window3();
            createN.Show();
            this.Hide();

        }

        private void TxtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
