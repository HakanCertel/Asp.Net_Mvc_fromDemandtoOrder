using Senfoni.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senfoni.Entity
{
    [NotMapped]
    public class AspNetUsers:BaseUserEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
    }
}
