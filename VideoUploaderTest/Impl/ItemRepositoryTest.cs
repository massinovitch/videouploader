using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploaderDAO.Impl;
using System.IO;
namespace VideoUploaderTest.Impl
{
    class ItemRepositoryTest
    {
 /*       static void Main(string[] args)
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

                VUItem grpList = itmRT.FindById(1);
                Byte[] blob = grpList.FichierHD;
                FileStream fs = new FileStream(@"c:\massiFavoris.html", FileMode.Create, FileAccess.Write);

                fs.Write(blob, 0, blob.Length);
                fs.Close();
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        */
    }
}
