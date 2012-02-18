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

namespace VideoUploader
{
    public class UserRepository : BaseRepository <User>
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
        public override List<User> FindByCriteria(User criteria)
        {
            try
            {
                using (var context = new ModelContext())
                {

                    StringBuilder queryString =
                        new StringBuilder(@"SELECT VALUE User FROM ModelContext.User as user");

                    bool whereClause = false;
                    // Critère Nom
                    if (criteria.Nom != null)
                    {
                        queryString.Append(" WHERE user.Nom LIKE '" + criteria.Nom.ToString() + "'");
                        whereClause = true;
                    }
                    // Critère Prenom
                    if (criteria.Prenom != null)
                    {
                        if (whereClause == true)
                        {
                            queryString.Append(" AND user.Prenom LIKE '" + criteria.Prenom.ToString() + "'");
                        }
                        else
                        {
                            queryString.Append(" WHERE user.Prenom LIKE '" + criteria.Prenom.ToString() + "'");
                            whereClause = true;
                        }
                    }
                    // Critère Login
                    if (criteria.Login != null)
                    {
                        if (whereClause == true)
                        {
                            queryString.Append(" AND user.Login LIKE '" + criteria.Login.ToString() + "'");
                        }
                        else
                        {
                            queryString.Append(" WHERE user.Login LIKE '" + criteria.Login.ToString() + "'");
                            whereClause = true;
                        }
                    }
                    // Critère Groupe
                    if (criteria.GroupeIdGroupe != 0)
                    {
                        if (whereClause == true)
                        {
                            queryString.Append(" AND cast(user.GroupeIdGroupe as System.String) = '" + criteria.GroupeIdGroupe.ToString() + "'");
                        }
                        else
                        {
                            queryString.Append(" WHERE cast(user.GroupeIdGroupe as System.String) = '" + criteria.GroupeIdGroupe.ToString() + "'");
                            whereClause = true;
                        }
                    }
                    //var users = context.User.ToList();
                    //return users;

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
