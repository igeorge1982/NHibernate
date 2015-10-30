using NHibernate.Mapping.Attributes;

namespace MvcApplication1.Models.Entities
{
    [Class]
    public class User
    {
        [Id(0, Name = "Id", TypeType = typeof (int), Column = "Id")]
        [Generator(1, Class = "User")]
        public virtual int Id { get; set; }

        [Property(Name = "Username", Column = "Username", TypeType = typeof (string), Length = 50)]
        public virtual string Username { get; set; }
    }
}