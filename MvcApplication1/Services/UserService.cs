using System.Collections.Generic;
using MvcApplication1.Models.Daos;
using MvcApplication1.Models.Entities;
using MvcApplication1.Transactions;

namespace MvcApplication1.Services
{
    /// <summary>Data Access Object class that represents the following entity class: <see cref="User" /></summary>
    public class UserService
    {
        public IUserDao UserDao { private get; set; }

        [Transactional]
        public virtual IList<User> GetAllUsers()
        {
            // throw new Exception("Ha!");
            return UserDao.GetAll();
        }

        [Transactional]
        public virtual User GetUser(int id)
        {
            return UserDao.Get(id);
        }

        [Transactional]
        public virtual void Save(User user)
        {
            UserDao.Save(user);
        }

        [Transactional]
        public virtual void DeleteUser(User user)
        {
            UserDao.Delete(user);
        }

        [Transactional]
        public virtual void UpdateUser(User user)
        {
            UserDao.Update(user);
        }
    }
}