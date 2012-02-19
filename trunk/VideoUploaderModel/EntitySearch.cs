using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoUploaderModel
{
    /*
     * Class permetant de créer des objet de recherche pour les recherche comportant les dates
     */
    public class EntitySearch
    {
        public Object Entity;
        public String DateDebut;
        public String DateFin;

        public EntitySearch(Object Entity,String DateDebut, String DateFin)
        {
            this.Entity = Entity;
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
        }
    }

}
