using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tpGestionContact.Model;

namespace DAL
{
    public class CreateFicher
    {

        //Liste pour Favorites
        public static void AddList(string nom)
        {


            List<string> viejo = new List<string>();
            string[] compare = File.ReadAllLines("../../Password.txt");

            for (int i = 0; i < File.ReadAllLines("../../Password.txt").Length; i++)
            {
                if (nom != compare[i])
                {

                    viejo.Add(compare[i]);
                }

            }

            viejo.Add(nom);

            File.WriteAllLines("../../Default.txt", viejo);
        }

        //maxime
        //Ajoute Contacte Split
        //edite delete
        //Pour Ecrire Tout Separe par un Char
        public static void AddContact(string[] x)
        {
            string contact = x[0] + "/" + x[1] + "/" + x[2] + "/" + x[3] + "/" + x[4] + "/" + x[5];

            List<string> viejo = new List<string>();

            string[] compare = File.ReadAllLines("../../ContactList.txt");

            for (int i = 0; i < File.ReadAllLines("../../ContactList.txt").Length; i++)
            {
                if (contact != compare[i])
                {
                    viejo.Add(compare[i]);
                }

            }

            viejo.Add(contact);

            File.WriteAllLines("../../ContactList.txt", viejo);

        }


        //maxime
        //Donne Les Contacts
        //Edite contacts et delete

        public static void RemoveList(string x)
        {
            File.WriteAllText("../../ContactList.txt", x);
            //File.Create("../../ContactList.txt");


        }


        public static string[] ReturneContacs()
        {
            return File.ReadAllLines("../../ContactList.txt");

        }

        public static string[] ReturnPassword()
        {
            return File.ReadAllLines("../../Password.txt");

        }



        public static void WritePassword(string[] password)
        {

            string contact = password[0] + "/" + password[1] + "/" + password[2];


            List<string> viejo = new List<string>();

            string[] compare = File.ReadAllLines("../../Password.txt");

            for (int i = 0; i < File.ReadAllLines("../../Password.txt").Length; i++)
            {
                if (contact != compare[i])
                {
                    viejo.Add(compare[i]);
                }

            }

            viejo.Add(contact);


            File.WriteAllLines("../../Password.txt", viejo);

        }


        //  lecture de toutes les lignes d'un fichier

        // SEARCH
        public static Contact LireunFichier(string nomFichier)
        {
            Contact unContact = new Contact();
            string[] persone;
            try
            {
                persone = File.ReadAllLines("../../" + nomFichier);
                unContact.FirstName = persone[0];
                unContact.LastName = persone[1];
                unContact.ContactNo = persone[2];
                unContact.Address = persone[3];
                unContact.Gender = persone[4];
            }
            catch (Exception)
            {



            }


            // var engine = new FileHelperEngine<Contact>();






            return unContact;

        }

    }
}
