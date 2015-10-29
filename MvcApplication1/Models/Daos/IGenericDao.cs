using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication1.Models.Daos
{
    public interface IGenericDao<ENTITY_TYPE, ID_TYPE>
    {
        ENTITY_TYPE Get(ID_TYPE id);
        void Save(ENTITY_TYPE entity);
        void Update(ENTITY_TYPE entity);
        void Delete(ENTITY_TYPE entity);
        IList<ENTITY_TYPE> GetAll();
    }
}
