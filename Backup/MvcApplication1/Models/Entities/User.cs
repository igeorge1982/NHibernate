using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
    }
}