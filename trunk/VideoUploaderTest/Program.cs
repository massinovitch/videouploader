using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploader;

namespace VideoUploaderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userTest = new UserRepository();
            
            var user = new User
            {
                IdUser = 1,
                Login = "massinovicth",
                Nom = "sekhi",
                Prenom = "massinissa",
                GroupeIdGroupe = 1,
                DateCreation = DateTime.Now,
                DateMAJ = DateTime.Now,
                Password = "pass"
            };
            userTest.Create(user);
            
            var userSearch = new User
            {
                Login = "massinovicth",
                Nom = "sekhi",
                GroupeIdGroupe = 1
            };
            List<User> userfind = userTest.FindByCriteria(userSearch);
            foreach (User result in userfind)
            {
                Console.WriteLine("User Last Name: {0}; First Name: {1}",
                        result.Nom, result.Prenom);
            }
            Console.ReadKey();
        }
    }
}
