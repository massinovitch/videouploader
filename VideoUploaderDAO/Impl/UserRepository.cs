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

namespace VideoUploader
{
    public class UserRepository : BaseRepository <User,EntitySearch>
    {
        //création d'un utilisateur
        public override void Create(User user)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    context.AddToUser(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Supprimer tous les utilisateurs
        public override void DeleteAll()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var userList = context.User;
                    foreach (var user in userList)
                    {
                        context.DeleteObject(user);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Supprimer un utilisateur
        public override void Delete(User user)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var pers = context.User.Where(u => u.IdUser == user.IdUser).First();
                    context.DeleteObject(pers);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Récupérer tous les utilisateurs
        public override List<User> GetList()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    return context.User.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Récupérer un utilisateur avec son Id
        public override User FindById(int id)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    var user = context.User.Where(u => u.IdUser == id);
                    return user.First();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Récupérer une liste d'utilisateurs avec un critère de recherche
        public override List<User> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                using (var context = new ModelContext())
                {
                    StringBuilder queryString = new StringBuilder(@"SELECT VALUE User FROM ModelContext.User as user");
                    SelectBuilder sb = new SelectBuilder();
                    User user = (User)criteria.Entity;
                    // Critère Nom
                    if (user.Nom != null && !user.Nom.Equals(""))
                    {
                        sb.AndSearchLike("user.Nom", user.Nom.ToString());
                    }
                    // Critère Prenom
                    if (user.Prenom != null && !user.Prenom.Equals(""))
                    {
                        sb.AndSearchLike("user.Prenom", user.Prenom.ToString());
                    }
                    // Critère Login
                    if (user.Login != null && !user.Login.Equals(""))
                    {
                        sb.AndSearchLike("user.Login", user.Login.ToString());                        
                    }
                    // Critère de date de creation
                    if (criteria.DateDebut != null && !criteria.DateDebut.Equals(""))
                    {
                        if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                        {
                            sb.AndSearchBetween("cast(user.DateCreation as System.String)", criteria.DateDebut, criteria.DateFin);
                        }
                        else
                        {
                            sb.AndSearchAfter("cast(user.DateCreation as System.String)", criteria.DateDebut);
                        }
                    }
                    else if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                    {
                        sb.AndSearchBefore("cast(user.DateCreation as System.String)", criteria.DateFin);                        
                    }

                    // Critère Groupe
                    if (user.GroupeIdGroupe != 0)
                    {
                        sb.AndSearch("cast(user.GroupeIdGroupe as System.String)", user.GroupeIdGroupe.ToString());
                    }
                    queryString.Append(sb.getQueryString());
                    ObjectQuery<User> query = new ObjectQuery<User>(queryString.ToString(), context);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
