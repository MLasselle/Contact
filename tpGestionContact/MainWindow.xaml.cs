using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tpGestionContact.Model;
using BLL;

namespace tpGestionContact
{

    public partial class MainWindow : Window
    {

        //Constructeur, Star par Default
        public MainWindow()
        {

            InitializeComponent();

            this.Hide();

            List<Contact> j = Metodes.RemplirTableau().OrderBy(o => o.FirstName).ToList();


            for (int i = 0; i < Metodes.RemplirTableau().Count; i++)
            {
                DataTable.Items.Add(j[i]);
            }


        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Add a new Contact Button
        //Ajouter Version 2
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {


            //Validation Ameiore(



            string[] entres = new string[5] { txtFirstName.Text, txtLastName.Text, txtContactNo.Text, txtAdress.Text, cmbGender.Text };

            if (entres[0].Length < 3 || entres[1].Length < 3)
            {

                MessageBox.Show("Minimum 3 Characteres! et remplir tout les champs");

            }
            else
            {

                List<Contact> test = Metodes.RemplirTableau();

                int v = Metodes.RemplirTableau().Count;
                int index = 0;
                if (v > 0)
                {
                    index = test[v - 1].ContactID;
                }
                index++;


                Contact ajoute = new Contact
                {
                    ContactID = index,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    ContactNo = txtContactNo.Text,
                    Address = txtAdress.Text,
                    Gender = cmbGender.Text
                };

                Metodes.AddSplit(ajoute);
                //  Metodes.LireToute(c.FirstName);




                MessageBox.Show("Contact Ajoute!!");
                BtnUpdate_Click(null, null);
                //*********Message success or failed a revenir **********

            }

        }


        int indexDelete = 0;
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var s = DataTable.SelectedCells[0].Item as Contact;

                indexDelete = s.ContactID;
                txtFirstName.Text = s.FirstName;
                txtLastName.Text = s.LastName;
                txtContactNo.Text = s.ContactNo;
                txtAdress.Text = s.Address;
                cmbGender.Text = s.Gender;
            }
            catch (Exception x)
            {

            }
        }

        private void TxtContactID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //ici pour delete
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // DataTable.Items.Remove(DataTable.SelectedItem);

            List<Contact> contacts = Metodes.RemplirTableau();
            int x = Metodes.RemplirTableau().Count;
            string y = "";
            for (int i = 0; i < x; i++)
            {

                if (contacts[i].ContactID != indexDelete)
                {
                    y += contacts[i].ContactID + "/" + contacts[i].FirstName + "/" + contacts[i].LastName + "/" + contacts[i].ContactNo + "/" + contacts[i].Address + "/" + contacts[i].Gender + '\n';

                }

            }

            Metodes.RemoveContenu(y);
            DataTable.Items.Remove(DataTable.SelectedItem);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

            DataTable.Items.Clear();
        }
        //buton search

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Contact> readContacts = Metodes.RemplirTableau();

            DataTable.Items.Clear();

            for (int i = 0; i < Metodes.RemplirTableau().Count; i++)
            {

                if (readContacts[i].FirstName.Contains(txtSearch.Text) || readContacts[i].LastName.Contains(txtSearch.Text))
                {
                    DataTable.Items.Add(readContacts[i]);

                }
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataTable.Items.Clear();
            List<Contact> j = Metodes.RemplirTableau();

            for (int i = 0; i < Metodes.RemplirTableau().Count; i++)
            {
                DataTable.Items.Add(j[i]);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void User_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnUser(object sender, RoutedEventArgs e)
        {



        }

        private void TxtModifique_Click(object sender, RoutedEventArgs e)
        {

            List<Contact> contacts = Metodes.RemplirTableau();
            int x = Metodes.RemplirTableau().Count;
            string y = "";
            for (int i = 0; i < x; i++)
            {

                if (contacts[i].ContactID != indexDelete)
                {
                    y += contacts[i].ContactID + "/" + contacts[i].FirstName + "/" + contacts[i].LastName + "/" + contacts[i].ContactNo + "/" + contacts[i].Address + "/" + contacts[i].Gender + '\n';

                }
                else
                {
                    y += indexDelete + "/" + txtFirstName.Text + "/" + txtLastName.Text + "/" + txtContactNo.Text + "/" + txtAdress.Text + "/" + cmbGender.Text + '\n';

                }

            }

            Metodes.ModifiqueContact(y);
            BtnUpdate_Click(null, null);

            //DataTable.Items.Remove(DataTable.SelectedItem);

        }



        private void TxtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("Tex ");
            if (num)
            {
                FirstName = txtFirstName.Text;
                num = true;
            }
            else
            {
                txtFirstName.Text = FirstName;
                num = true;
            }

            txtFirstName.Select(txtFirstName.Text.Length, 0);
        }


        private bool num = true;
        private bool lastNum = true;
        private bool contacNum = true;

        private string FirstName = "";
        private string LastName = "";
        private string ContacNum = "";
        private void TxtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            //testKey
            //MessageBox.Show(((int)e.Key).ToString());

            if (((int)e.Key <= 43 || (int)e.Key >= 70) && e.Key != Key.CapsLock && e.Key != Key.LeftShift && e.Key != Key.RightShift)
            {

                // MessageBox.Show(((int)e.Key).ToString());
                txtFirstName.Text = FirstName;
                num = false;

            }
        }

        private void TxtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtLastName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (lastNum)
            {
                LastName = txtLastName.Text;
                lastNum = true;
            }
            else
            {
                txtLastName.Text = LastName;
                lastNum = true;
            }

            txtLastName.Select(txtLastName.Text.Length, 0);
        }

        private void TxtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(((int)e.Key).ToString());

            if ((int)e.Key < 34 || (int)e.Key > 43)
            {
                //MessageBox.Show("holi");
                txtContactNo.Text = ContacNum;
                contacNum = false;

            }




        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            DataTable.Items.Clear();
            List<Contact> j = Metodes.RemplirTableau().OrderBy(o => o.FirstName).ToList();


            for (int i = 0; i < Metodes.RemplirTableau().Count; i++)
            {

                if (cbxOrder.Text == "male")
                {
                    if (j[i].Gender == "Male")
                    {

                        DataTable.Items.Add(j[i]);

                    }

                }
                if (cbxOrder.Text == "female")
                {

                    if (j[i].Gender == "Female")
                    {

                        DataTable.Items.Add(j[i]);

                    }

                }
                if (cbxOrder.Text == "none")
                {




                    DataTable.Items.Add(j[i]);


                }
            }

        }

        private void RadioButton_Checkedza(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(cbxOrder.Text);
            DataTable.Items.Clear();
            List<Contact> j = Metodes.RemplirTableau().OrderByDescending(o => o.FirstName).ToList();


            for (int i = 0; i < Metodes.RemplirTableau().Count; i++)
            {

                if (cbxOrder.Text == "male")
                {
                    if (j[i].Gender == "Male")
                    {

                        DataTable.Items.Add(j[i]);

                    }

                }
                if (cbxOrder.Text == "female")
                {

                    if (j[i].Gender == "Female")
                    {

                        DataTable.Items.Add(j[i]);

                    }

                }
                if (cbxOrder.Text == "none")
                {




                    DataTable.Items.Add(j[i]);


                }
            }

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void TxtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.Key <= 43 || (int)e.Key >= 70) && e.Key != Key.CapsLock && e.Key != Key.LeftShift && e.Key != Key.RightShift)
            {

                // MessageBox.Show(((int)e.Key).ToString());
                txtFirstName.Text = FirstName;
                lastNum = false;

            }
        }

        private void TxtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (contacNum)
            {
                ContacNum = txtContactNo.Text;
                contacNum = true;
            }
            else
            {
                txtContactNo.Text = ContacNum;
                contacNum = true;
            }

            txtContactNo.Select(txtContactNo.Text.Length, 0);
        }

        private void btnFermer_Sesion(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Window2 Login = new Window2();
            Login.Show();

        }
    }
}
