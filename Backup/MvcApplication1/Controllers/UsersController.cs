using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MvcApplication1.Models.Entities;
using MvcApplication1.Services;
using NHibernate;

namespace MvcApplication1.Controllers
{
    public class UsersController : ApiController
    {
        [Dependency]
        public UserService UserService { private get; set; }

        public IEnumerable<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            User user = UserService.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        public HttpResponseMessage PostUser(User user)
        {
            UserService.Save(user);

            HttpResponseMessage response = this.Request.CreateResponse<User>(HttpStatusCode.Created, user);
            string uri = Url.Link("DefaultApi", new { id = user.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutUser(int id, User user)
        {
            User persistentUser = UserService.GetUser(id);
            if (persistentUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            persistentUser.Username = user.Username;
            UserService.UpdateUser(persistentUser);

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Accepted);
            return response;
        }

        public void DeleteUser(int id)
        {
            User user = UserService.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            UserService.DeleteUser(user);
        }
    }
}
