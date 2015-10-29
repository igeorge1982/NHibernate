using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.Models.Entities;

namespace MvcApplication1.Models.Daos
{
    public interface IUserDao : IGenericDao<User, int>
    {
    }
}
