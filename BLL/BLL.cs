using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tpGestionContact.Model;
using DAL;
using System.IO;

namespace BLL
{

    public class Metodes
    {

        //metode pour ajoute un contact
        public static Contact AddSplit(Contact next)
        {

            string contact = (next.ContactID + "/" + next.FirstName + "/" + next.LastName + "/" + next.ContactNo + "/" + next.Address + "/" + next.Gender);


            string[] chaineComplet = contact.Split('/');

            CreateFicher.AddContact(chaineComplet);

            return next;
        }



        //Lire contacts
        public static List<Contact> RemplirTableau()
        {

            List<Contact> x = new List<Contact>();

            string[] contacts = CreateFicher.ReturneContacs();

            Contact total = new Contact();

            int k = CreateFicher.ReturneContacs().Length;

            for (int i = 0; i < k; i++)
            {

                string[] list = contacts[i].Split('/');
                if (list[0] != "")
                {
                    x.Add(new Contact { ContactID = Convert.ToInt32(list[0]), FirstName = list[1], LastName = list[2], ContactNo = list[3], Address = list[4], Gender = list[5] });
                }

            };


            return x;
        }



        //Create un Fichier Vide
        public static string[] TableauContact()
        {

            return CreateFicher.ReturneContacs();

        }


        //efacer
        public static void RemoveContenu(string x)
        {

            CreateFicher.RemoveList(x);


        }

        //Modifique un Contact

        public static void ModifiqueContact(string x)
        {


            CreateFicher.RemoveList(x);


        }

        public static void AjouterUser(User x)
        {

            string[] user = new string[3];

            user[0] = x.Name;
            user[1] = x.NickName;
            user[2] = x.PassWord;

            CreateFicher.WritePassword(user);


        }

        //Returne List User
        public static List<User> ReturneUser()
        {
            List<User> user = new List<User>();

            string[] x = CreateFicher.ReturnPassword();

            int k = CreateFicher.ReturnPassword().Length;

            for (int i = 0; i < k; i++)
            {

                string[] list = x[i].Split('/');
                if (list[0] != "")
                {
                    user.Add(new User { Name = list[0], NickName = list[1], PassWord = list[2] });
                }

            };

            return user;

        }


    }
}
