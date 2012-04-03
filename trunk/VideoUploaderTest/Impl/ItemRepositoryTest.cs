using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploaderDAO.Impl;
namespace VideoUploaderTest.Impl
{
    class ItemRepositoryTest
    {
        static void Main(string[] args)
        {
            try
            {
                ItemRepository itmRT = new ItemRepository();
                var itm = new VUItem
                {
                    Nom = "Item01",
                    Description = "description de Item01",
                    DateCreation = Convert.ToDateTime("2012-02-25"),
                    DateMAJ = DateTime.Now,
                    Type = "Text",
                    UserIdUser = 1
                };
                //itmRT.Create(itm);
                //grpRT.Delete(grp);
                //grpRT.DeleteAll();
                EntitySearch entitySearch = new EntitySearch(itm, "", "");

                List<VUItem> grpList = itmRT.FindByCriteria(entitySearch);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
