using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploader;
using VideoUploaderDAO.Impl;

namespace VideoUploaderTest
{
    class Program
    {
        static void Main(string[] args)
        {


            //var user = new User
            //{
            //    IdUser = 2,
            //    Login = "massinovicth",
            //    Nom = "sekhi",
            //    Prenom = "massinissa",
            //    GroupeIdGroupe = 1,
            //    DateCreation = Convert.ToDateTime("01-01-2012"),
            //    DateMAJ = DateTime.Now,
            //    Password = "pass"
            //};
            //userTest.Create(user);
            /*UserRepository userTest = new UserRepository();
            var userVide = new User();
            var userSearch = new User
            {
                Login = "massinovicth",
                Nom = "sekhi",
                GroupeIdGroupe = 1
            };
            EntitySearch entitySearch = new EntitySearch(userSearch, "2012-01-01", "");
            List<User> userfind = userTest.FindByCriteria(entitySearch);
            foreach (User result in userfind)
            {
                Console.WriteLine("User Last Name: {0}; First Name: {1} ====== IdUser :: {2} ",
                        result.Nom, result.Prenom, result.IdUser);
            }*/            
            ItemRepository itemRepository = new ItemRepository();
            List<VUItem> listElement = itemRepository.FindByCriteria(null);
            Console.ReadKey();
    }
    }
}
