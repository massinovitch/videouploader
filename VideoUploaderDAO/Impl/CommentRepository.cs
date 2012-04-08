using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using log4net;
using VideoUploader;
using VideoUploaderDAO.Util;
using System.Data.Objects;

namespace VideoUploaderDAO.Impl
{
    public class CommentRepository : BaseRepository<VUComment, EntitySearch>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GroupeRepository));
        //création d'un groupe
        public override void Create(VUComment commentaire)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                using (var context = new ModelContext())
                {
                    // il faut plutot utiliser ça : context.VUGroupe.AddObject(grp);
                    context.VUComment.AddObject(commentaire);
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

        //Supprimer tous les groupe
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
                    var commentaireList = context.VUComment;
                    foreach (var commentaire in commentaireList)
                    {
                        context.DeleteObject(commentaire);
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

        //Supprimer un groupe
        public override void Delete(VUComment commentaire)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                using (var context = new ModelContext())
                {
                    var pers = context.VUComment.Where(u => u.IdComment == commentaire.IdComment).First();
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

        //Récupérer tous les groupes
        public override List<VUComment> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                using (var context = new ModelContext())
                {
                    return context.VUComment.ToList();
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

        //Récupérer un groupe avec son Id
        public override VUComment FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                using (var context = new ModelContext())
                {
                    var grp = context.VUComment.Where(u => u.IdComment == id);
                    return grp.First();
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

        //Récupérer une liste d'groupes avec un critère de recherche
        public override List<VUComment> FindByCriteria(EntitySearch criteria)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindByCriteria");
                }
                using (var context = new ModelContext())
                {

                    StringBuilder queryString =
                        new StringBuilder(@"SELECT VALUE grp FROM ModelContext.VUComment as grp");
                    SelectBuilder sb = new SelectBuilder();

                    VUComment grp = (VUComment)criteria.Entity;
                    // Critère Nom
                    if (grp.Contenu != null && !grp.Contenu.Equals(""))
                    {
                        sb.AndSearchLike("grp.Contenu", grp.Contenu.ToString());
                    }

                    if (grp.ItemIdElement != 0)
                    {
                        sb.AndSearch("cast(grp.ItemIdElement as System.String)", grp.ItemIdElement.ToString());
                    }

                    if (grp.UserIdUser != 0)
                    {
                        sb.AndSearch("cast(grp.UserIdUser as System.String)", grp.UserIdUser.ToString());
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


                    queryString.Append(sb.getQueryString());
                    ObjectQuery<VUComment> query = new ObjectQuery<VUComment>(queryString.ToString(), context);
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
