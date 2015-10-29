using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace MvcApplication1.Models.Daos.Implementations
{
    public class GenericHibernateDao<ENTITY_TYPE, ID_TYPE> : IGenericDao<ENTITY_TYPE, ID_TYPE>
    {
        public ISessionFactory SessionFactory { private get; set; }

        protected ISession CurrentSession
        {
            get
            {
                return SessionFactory.GetCurrentSession();
            }
        }

        public virtual ENTITY_TYPE Get(ID_TYPE id)
        {
            return CurrentSession.Get<ENTITY_TYPE>(id);
        }

        public virtual void Save(ENTITY_TYPE entity)
        {
            CurrentSession.Save(entity);
        }

        public virtual void Update(ENTITY_TYPE entity)
        {
            CurrentSession.Update(entity);
        }

        public virtual void Delete(ENTITY_TYPE entity)
        {
            CurrentSession.Delete(entity);
        }

        public virtual IList<ENTITY_TYPE> GetAll()
        {
            return CurrentSession.CreateCriteria(typeof(ENTITY_TYPE))
                        .List<ENTITY_TYPE>();
        }
    }
}