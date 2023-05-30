using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactList.Data.Models
{
    public class User
    {
        public string Login { get; set;} = "admin";
        public string Password { get; set; } = "admin";

        public override string ToString()
        {
            return $"{Login} - {Password}";
        }

        public static void SerelizeUserDate(User user)
        {
            
            using (FileStream fs1 = new FileStream(App.UserDataPath, FileMode.Create))
            {
                string serialaized = JsonSerializer.Serialize(user);
                fs1.Write(Encoding.UTF8.GetBytes(serialaized));
            }
           
        }
        public static User DerelizeUserDate()
        {
            string deSerialaizedList = File.ReadAllText(App.UserDataPath);
            User tmpUser = JsonSerializer.Deserialize<User>(deSerialaizedList);
            return tmpUser;
        }
    }
}
