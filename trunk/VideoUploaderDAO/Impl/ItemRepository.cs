using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using log4net;
using VideoUploaderModel;
using VideoUploaderDAO.Util;
using VideoUploader;

namespace VideoUploaderDAO.Impl
{
    public class ItemRepository : BaseRepository<VUItem, EntitySearch>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ItemRepository));
        //création d'un element
        public override void Create(VUItem itm)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Create");
                }
                using (var context = new ModelContext())
                {
                    context.AddToVUElement(itm);
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

        //Supprimer tous les elements
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
                    var itmList = context.VUElement.OfType<VUItem>();
                    foreach (var itm in itmList)
                    {
                        context.DeleteObject(itm);
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

        //Supprimer un Item
        public override void Delete(VUItem itm)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin Delete");
                }
                using (var context = new ModelContext())
                {
                    var pers = context.VUElement.Where(u => u.IdElement == itm.IdElement).First();
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

        //Récupérer tous les items
        public override List<VUItem> GetList()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin GetList");
                }
                using (var context = new ModelContext())
                {
                    return context.VUElement.OfType<VUItem>().ToList();
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

        //Récupérer un element avec son Id
        public override VUItem FindById(int id)
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Begin FindById");
                }
                using (var context = new ModelContext())
                {
                    var itm = context.VUElement.OfType<VUItem>().Where(u => u.IdElement == id);
                    return itm.First();
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

        //Récupérer une liste d'elements avec un critère de recherche
        public override List<VUItem> FindByCriteria(EntitySearch criteria)
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
                        new StringBuilder(@"SELECT VALUE elt FROM OFTYPE(VUElement,VideoUploaderModel.VUItem) as elt");
                    SelectBuilder sb = new SelectBuilder();
                    VUItem item = (VUItem)criteria.Entity;
                    // Critère Nom
                    if (item.Nom != null && !item.Nom.Equals(""))
                    {
                        sb.AndSearchLike("elt.Nom", item.Nom.ToString());
                    }
                    // Critère Prenom
                    if (item.Type != null && !item.Type.Equals(""))
                    {
                        sb.AndSearchLike("elt.Type", item.Type.ToString());
                    }
                    // Critère de date de creation
                    if (criteria.DateDebut != null && !criteria.DateDebut.Equals(""))
                    {
                        if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                        {
                            sb.AndSearchBetween("cast(elt.DateCreation as System.String)", criteria.DateDebut, criteria.DateFin);
                        }
                        else
                        {
                            sb.AndSearchAfter("cast(elt.DateCreation as System.String)", criteria.DateDebut);
                        }
                    }
                    else if (criteria.DateFin != null && !criteria.DateFin.Equals(""))
                    {
                        sb.AndSearchBefore("cast(elt.DateCreation as System.String)", criteria.DateFin);
                    }
                    queryString.Append(sb.getQueryString());
                    ObjectQuery<VUItem> query = new ObjectQuery<VUItem>(queryString.ToString(), context).OfType<VUItem>();

                    List<VUItem> elt = query.ToList();
                    return null;
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
