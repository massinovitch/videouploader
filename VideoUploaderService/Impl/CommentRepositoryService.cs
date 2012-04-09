using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using VideoUploaderDAO.Impl;
using VideoUploaderModel;


namespace VideoUploaderService.Impl
{
    class CommentRepositoryService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommentRepositoryService));
        //création d'un groupe
        public void Create(VUComment commentaire)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                commentRepositoryDao.Create(commentaire);
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
        public void DeleteAll()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin DeleteAll");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                commentRepositoryDao.DeleteAll();
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
        public void Delete(VUComment commentaire)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                commentRepositoryDao.Delete(commentaire);
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
        public List<VUComment> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                return commentRepositoryDao.GetList();
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
        public override VUComment FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                return commentRepositoryDao.FindById(id);
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
        public override List<VUComment> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                CommentRepository commentRepositoryDao = new CommentRepository();
                return commentRepositoryDao.FindByCriteria(criteria);
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
