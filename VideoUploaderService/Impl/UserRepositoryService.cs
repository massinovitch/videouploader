using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using VideoUploaderModel;
using VideoUploader;

namespace VideoUploaderService.Impl
{
    public class UserRepositoryService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserRepositoryService));
        private UserRepository userRepository;

        public UserRepository UserRepository
        {
            get { return userRepository; }
            set { userRepository = value; }
        }
        private static volatile UserRepositoryService instance;
        private static object syncRoot = new Object();

        private UserRepositoryService() { }

        public static UserRepositoryService getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new UserRepositoryService();
                }
            }

            return instance;
        }

        //création d'un utilisateur
        public void Create(VUUser user)
        {
            try
            {
                /*La construction de chaîne de caractères est très consommatrice en ressources.
                Afin de ne pas en construire inutilement, vérifier que le logger est bien configuré avec un niveau de log suffisant*/
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                userRepository.Create(user);
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
        public void DeleteAll()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin DeleteAll");
                }
                userRepository.DeleteAll();
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
        public void Delete(VUUser user)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                userRepository.Delete(user);
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
        public List<VUUser> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                return userRepository.GetList();
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
        public VUUser FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                return userRepository.FindById(id);
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
        public List<VUUser> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                return userRepository.FindByCriteria(criteria);
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
