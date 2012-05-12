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
using log4net;

namespace VideoUploader
{
    public class UserRepository : BaseRepository <VUUser,EntitySearch>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserRepository));
        private static volatile UserRepository instance;
        private static object syncRoot = new Object();

        private UserRepository() { }

        public static UserRepository getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new UserRepository();
                }
            }

            return instance;
        }

        //création d'un utilisateur
        public override void Create(VUUser user)
        {
            try
            {
                /*La construction de chaîne de caractères est très consommatrice en ressources.
                Afin de ne pas en construire inutilement, vérifier que le logger est bien configuré avec un niveau de log suffisant*/
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                using (var context = new ModelContext())
                {
                    context.VUUser.AddObject(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Create : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End Create");
                }
            }
        }

        //Supprimer tous les utilisateurs
        public override void DeleteAll()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin DeleteAll");
                }
                using (var context = new ModelContext())
                {
                    var userList = context.VUUser;
                    foreach (var user in userList)
                    {
                        context.DeleteObject(user);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("DeleteAll : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End DeleteAll");
                }
            }
        }

        //Supprimer un utilisateur
        public override void Delete(VUUser user)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                using (var context = new ModelContext())
                {
                    var pers = context.VUUser.Where(u => u.IdUser == user.IdUser).First();
                    context.DeleteObject(pers);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Error("Delete : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End Delete");
                }
            }
        }

        //Récupérer tous les utilisateurs
        public override List<VUUser> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                using (var context = new ModelContext())
                {
                    return context.VUUser.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("GetList : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End GetList");
                }
            }
        }

        //Récupérer un utilisateur avec son Id
        public override VUUser FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                using (var context = new ModelContext())
                {
                    var user = context.VUUser.Where(u => u.IdUser == id);
                    return user.First();
                }
            }
            catch (Exception ex)
            {
                log.Error("FindById : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End FindById");
                }
            }
        }

        //Récupérer une liste d'utilisateurs avec un critère de recherche
        public override List<VUUser> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                using (var context = new ModelContext())
                {
                    StringBuilder queryString = new StringBuilder(@"SELECT VALUE user FROM ModelContext.VUUser as user");
                    SelectBuilder sb = new SelectBuilder();
                    VUUser user = (VUUser)criteria.Entity;
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
                    log.Info("FindByCriteria requete : " +  queryString.ToString());
                    ObjectQuery<VUUser> query = new ObjectQuery<VUUser>(queryString.ToString(), context);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error("FindByCriteria : ", ex);
                throw;
            }
            finally
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("End FindByCriteria");
                }
            }
        }
    }
}
