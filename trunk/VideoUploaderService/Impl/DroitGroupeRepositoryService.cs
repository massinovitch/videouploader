using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using VideoUploaderDAO.Impl;
using VideoUploaderModel;

namespace VideoUploaderService.Impl
{
    class DroitGroupeRepositoryService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DroitGroupeRepositoryService));
        //création d'un groupe
        public override void Create(VUDroit droit)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                droitGroupeRepositoryDao.Create(droit);
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

        //Supprimer tous les groupe
        public override void DeleteAll()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin DeleteAll");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                droitGroupeRepositoryDao.DeleteAll();
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

        //Supprimer un groupe
        public override void Delete(VUDroit droit)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                droitGroupeRepositoryDao.Delete(droit);
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

        //Récupérer tous les groupes
        public override List<VUDroit> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                return droitGroupeRepositoryDao.GetList();
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

        //Récupérer un groupe avec son Id
        public override VUDroit FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                return droitGroupeRepositoryDao.FindById(id);
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

        //Récupérer une liste d'groupes avec un critère de recherche
        public override List<VUDroit> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                DroitGroupeRepository droitGroupeRepositoryDao = new DroitGroupeRepository();
                return droitGroupeRepositoryDao.FindByCriteria(criteria);
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
