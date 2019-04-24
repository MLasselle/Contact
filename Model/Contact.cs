using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tpGestionContact.Model
{
    public class Contact
    {

        //Getter and Setter Properties
        public int ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }


    }


    public class User
    {
        public string NickName { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }


    }



}