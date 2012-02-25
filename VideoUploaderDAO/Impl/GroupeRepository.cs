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

namespace VideoUploaderDAO.Impl
{
    public class GroupeRepository : BaseRepository<VUGroupe, EntitySearch>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GroupeRepository));
        //création d'un groupe
        public override void Create(VUGroupe grp)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                using (var context = new ModelContext())
                {
                    context.AddToVUGroupe(grp);
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
                    var grpList = context.VUGroupe;
                    foreach (var grp in grpList)
                    {
                        context.DeleteObject(grp);
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
        public override void Delete(VUGroupe grp)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                using (var context = new ModelContext())
                {
                    var pers = context.VUGroupe.Where(u => u.IdGroupe == grp.IdGroupe).First();
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
        public override List<VUGroupe> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                using (var context = new ModelContext())
                {
                    return context.VUGroupe.ToList();
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
        public override VUGroupe FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                using (var context = new ModelContext())
                {
                    var grp = context.VUGroupe.Where(u => u.IdGroupe == id);
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
        public override List<VUGroupe> FindByCriteria(EntitySearch criteria)
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
                        new StringBuilder(@"SELECT VALUE VUGroupe FROM ModelContext.VUGroupe as grp");
                    SelectBuilder sb = new SelectBuilder();

                    VUGroupe grp = (VUGroupe)criteria.Entity;
                    // Critère Nom
                    if (grp.Nom != null && !grp.Nom.Equals(""))
                    {
                        sb.AndSearchLike("grp.Nom", grp.Nom.ToString());
                    }

                    // Critère Description
                    if (grp.Description != null && !grp.Description.Equals(""))
                    {
                        sb.AndSearchLike("grp.Descritpion", grp.Description.ToString());
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
                    ObjectQuery<VUGroupe> query = new ObjectQuery<VUGroupe>(queryString.ToString(), context);
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
