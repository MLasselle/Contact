using BLL;
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

namespace tpGestionContact
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Name = txtFirstName.Text,
                NickName = txtNickName.Text,
                PassWord = txtPassWord.Text
            };

            Metodes.AjouterUser(user);

            MessageBox.Show("User Creating Sucessfully!");
            Window2 login = new Window2();
            login.Show();
            this.Hide();
        }
    }
}
