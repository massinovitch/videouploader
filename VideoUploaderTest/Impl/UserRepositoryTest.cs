using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploader;

namespace VideoUploaderTest.Impl
{
    class UserRepositoryTest
    {
             static void Main(string[] args)
                {
                    try
                    {
                        UserRepositoryTest userRT = new UserRepositoryTest();
                        var user = new VUUser
                        {
                            Login = "massinovicth",
                            Nom = "sekhi",
                            Prenom = "massinissa",
                            GroupeIdGroupe = 1,
                            DateCreation = Convert.ToDateTime("2012-02-25"),
                            DateMAJ = DateTime.Now,
                            Password = "pass"
                        };
                        EntitySearch entitySearch = new EntitySearch(user, "", "");
                        UserRepository userTest = new UserRepository();
                        List<VUUser> userfind = userTest.FindByCriteria(entitySearch);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                public void addUser()
                {
                    var user = new VUUser
                    {
                        Login = "massinovicth",
                        Nom = "sekhi",
                        Prenom = "massinissa",
                        GroupeIdGroupe = 1,
                        DateCreation = Convert.ToDateTime("2012-02-25"),
                        DateMAJ = DateTime.Now,
                        Password = "pass"
                    };
                    UserRepository userTest = new UserRepository();
                    userTest.Create(user);
                }

                public List<VUUser> findUser(VUUser userSearch)
                {
                    EntitySearch entitySearch = new EntitySearch(userSearch, "", "");
                    UserRepository userTest = new UserRepository();
                    List<VUUser> userfind = userTest.FindByCriteria(entitySearch);
                    foreach (VUUser result in userfind)
                    {
                        Console.WriteLine("User Last Name: {0}; First Name: {1} ====== IdUser :: {2} ",
                                result.Nom, result.Prenom, result.IdUser);
                    }
                    Console.ReadKey();
                    return userfind;

                }
   
         
    }


}
