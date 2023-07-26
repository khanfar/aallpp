using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR_General.Entity
{
    public class Users
    {
        public int UserId;
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string ProfilePic;
        public string Gender;
        public string WhatsappNo;
        public int Country_Id;
        public string City_Name;
        public int Is_Active;
        public int RoleId;

        public enum Genders { Male, Female }
    }
}
