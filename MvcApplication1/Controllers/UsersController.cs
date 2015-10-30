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
        [HttpGet]
        public User GetUserById(int id)
        {
            var user = UserService.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [Route("newbook/{id}/{username}")]
        [HttpPost]
        public User NewUser(int id, string username)
        {
            var user = new User {Id = id, Username = username};
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return user;
        }

        // This seems to be use the POST response
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

        [Route("delete/{id}")]
        [AcceptVerbs("DELETE")]
        [HttpDelete]
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