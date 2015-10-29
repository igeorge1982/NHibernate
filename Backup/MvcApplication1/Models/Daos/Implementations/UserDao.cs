using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models.Entities;

namespace MvcApplication1.Models.Daos.Implementations
{
    public class UserDao : GenericHibernateDao<User, int>, IUserDao
    {
    }
}