using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploader;
using VideoUploaderModel;
using VideoUploader.DAO;
using System.Linq.Expressions;
using VideoUploader.Util;
using System.Data.Objects;
using VideoUploaderDAO.Util;

namespace VideoUploaderDAO.Impl
{
    public class GroupeRepository : BaseRepository<Groupe, EntitySearch>
    {
        //création d'un utilisateur
        public override void Create(Groupe grp)
        {
            using (var context = new ModelContext())
            {
                context.AddToGroupe(grp);
                context.SaveChanges();
            }
        }

        //Supprimer tous les utilisateurs
        public override void DeleteAll()
        {
            using (var context = new ModelContext())
            {
                var grpList = context.Groupe;
                foreach (var grp in grpList)
                {
                    context.DeleteObject(grp);
                }
                context.SaveChanges();
            }
        }

        //Supprimer un utilisateur
        public override void Delete(Groupe grp)
        {
            using (var context = new ModelContext())
            {
                var pers = context.Groupe.Where(u => u.IdGroupe == grp.IdGroupe).First();
                context.DeleteObject(pers);
                context.SaveChanges();
            }
        }

        //Récupérer tous les utilisateurs
        public override List<Groupe> GetList()
        {
            using (var context = new ModelContext())
            {
                return context.Groupe.ToList();
            }
        }

        //Récupérer un utilisateur avec son Id
        public override Groupe FindById(int id)
        {
            using (var context = new ModelContext())
            {
                var grp = context.Groupe.Where(u => u.IdGroupe == id);
                return grp.First();
            }
        }

        //Récupérer une liste d'utilisateurs avec un critère de recherche
        public override List<Groupe> FindByCriteria(EntitySearch criteria)
        {
            using (var context = new ModelContext())
            {

                StringBuilder queryString =
                    new StringBuilder(@"SELECT VALUE Groupe FROM ModelContext.Groupe as grp");
                SelectBuilder sb = new SelectBuilder();

                Groupe grp = (Groupe)criteria.Entity;
                // Critère Nom
                if (grp.Nom != null && !grp.Equals(""))
                {
                    sb.AndSearchLike("grp.Nom", grp.Nom.ToString());
                }

                // Critère Description
                if (grp.Descritpion != null && !grp.Equals(""))
                {
                    sb.AndSearchLike("grp.Descritpion", grp.Descritpion.ToString());
                }

                // Critère de date de creation
                if (criteria.DateDebut != null && !criteria.DateDebut.Equals(""))
                {
                    if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                    {
                        sb.AndSearchBetween("cast(grp.DateCreation as System.String)", criteria.DateDebut, criteria.DateFin);
                    }
                    else
                    {
                        sb.AndSearchAfter("cast(grp.DateCreation as System.String)", criteria.DateDebut);
                    }
                }
                else if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                {
                    sb.AndSearchBefore("cast(grp.DateCreation as System.String)", criteria.DateFin);
                }

                // Critère Droit, si on recherche les groupes qui ont un droit admin par exemple
                if (grp.DroitIdDroit != 0)
                {
                    sb.AndSearch("cast(user.DroitIdDroit as System.String)", grp.DroitIdDroit.ToString());
                }

                queryString.Append(sb.getQueryString());
                ObjectQuery<Groupe> query = new ObjectQuery<Groupe>(queryString.ToString(), context);
                return query.ToList();
            }
        }
    }
}
