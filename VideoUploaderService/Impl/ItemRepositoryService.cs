using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using VideoUploaderModel;
using VideoUploaderDAO.Impl;

namespace VideoUploaderService.Impl
{
    class ItemRepositoryService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ItemRepositoryService));
        //création d'un element
        public void Create(VUItem itm)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                ItemRepository itemRepositoryDao = new ItemRepository();
                itemRepositoryDao.Create(itm);
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
                ItemRepository itemRepositoryDao = new ItemRepository();
                itemRepositoryDao.DeleteAll();
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
        public void Delete(VUItem itm)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                ItemRepository itemRepositoryDao = new ItemRepository();
                itemRepositoryDao.Delete(itm);
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
        public List<VUItem> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                ItemRepository itemRepositoryDao = new ItemRepository();
                return itemRepositoryDao.GetList();
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
        public VUItem FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                ItemRepository itemRepositoryDao = new ItemRepository();
                return itemRepositoryDao.FindById(id);
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
        public List<VUItem> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                ItemRepository itemRepositoryDao = new ItemRepository();
                return itemRepositoryDao.FindByCriteria(criteria);
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
