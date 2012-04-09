using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using VideoUploaderModel;
using VideoUploaderDAO.Impl;

namespace VideoUploaderService.Impl
{
    class FolderRepositoryService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FolderRepositoryService));
        //création d'un element
        public void Create(VUFolder folder)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                folderRepositoryDao.Create(folder);
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

        //Supprimer tous les elements
        public void DeleteAll()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin DeleteAll");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                folderRepositoryDao.DeleteAll();
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

        //Supprimer un Item
        public void Delete(VUFolder folder)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                folderRepositoryDao.Delete(folder);
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

        //Récupérer tous les items
        public List<VUFolder> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                return folderRepositoryDao.GetList();
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

        //Récupérer un element avec son Id
        public VUFolder FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                return folderRepositoryDao.FindById(id);
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

        //Récupérer une liste d'elements avec un critère de recherche
        public List<VUFolder> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                FolderRepository folderRepositoryDao = new FolderRepository();
                return folderRepositoryDao.FindByCriteria(criteria);
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
