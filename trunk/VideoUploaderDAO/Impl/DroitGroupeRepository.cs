using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderModel;
using VideoUploader;
using log4net;
using System.Data.Objects;
using VideoUploaderDAO.Util;

namespace VideoUploaderDAO.Impl
{
    public class DroitGroupeRepository : BaseRepository<VUDroit, EntitySearch>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DroitGroupeRepository));
        private static volatile DroitGroupeRepository instance;
        private static object syncRoot = new Object();

        private DroitGroupeRepository() { }

        public static DroitGroupeRepository getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new DroitGroupeRepository();
                }
            }

            return instance;
        }

        //création d'un groupe
        public override void Create(VUDroit grp)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                using (var context = new ModelContext())
                {
                    // il faut plutot utiliser ça : context.VUDroit.AddObject(grp);
                    context.VUDroit.AddObject(grp);
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
                    var grpList = context.VUDroit;
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
        public override void Delete(VUDroit grp)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                using (var context = new ModelContext())
                {
                    var pers = context.VUDroit.Where(u => u.IdDroit == grp.IdDroit).First();
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
        public override List<VUDroit> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                using (var context = new ModelContext())
                {
                    return context.VUDroit.ToList();
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
        public override VUDroit FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                using (var context = new ModelContext())
                {
                    var grp = context.VUDroit.Where(u => u.IdDroit == id);
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
        public override List<VUDroit> FindByCriteria(EntitySearch criteria)
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
                        new StringBuilder(@"SELECT VALUE grp FROM ModelContext.VUDroit as grp");
                    SelectBuilder sb = new SelectBuilder();

                    VUDroit grp = (VUDroit)criteria.Entity;
                    // Critère Nom
                    sb.AndSearch("cast(grp.Admin as System.String)", grp.Admin.ToString());

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
                    ObjectQuery<VUDroit> query = new ObjectQuery<VUDroit>(queryString.ToString(), context);
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
