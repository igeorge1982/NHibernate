using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MvcApplication1.Models.Entities;
using MvcApplication1.Services;

namespace MvcApplication1.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        [Dependency]
        public UserService UserService { private get; set; }

        [Route("books")]
        public IEnumerable<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }

        [Route("books/{id}")]
        public User GetUserById(int id)
        {
            var user = UserService.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [Route("newbooks/{user}")]
        [HttpPost]
        public HttpResponseMessage PostUser(User user)
        {
            UserService.Save(user);

            var response = Request.CreateResponse(HttpStatusCode.Created, user);
            var uri = Url.Link("DefaultApi", new {id = user.Id});
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutUser(int id, User user)
        {
            var persistentUser = UserService.GetUser(id);
            if (persistentUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            persistentUser.Username = user.Username;
            UserService.UpdateUser(persistentUser);

            var response = Request.CreateResponse(HttpStatusCode.Accepted);
            return response;
        }

        public void DeleteUser(int id)
        {
            var user = UserService.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            UserService.DeleteUser(user);
        }
    }
}