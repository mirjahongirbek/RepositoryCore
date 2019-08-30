using RepositoryCore.Interfaces;
using System.Collections.Generic;

namespace RepositoryCore.Models.Auth
{
    public  class User<TUserRole, TKey> : IEntity<TKey>
        where TUserRole: UserRole<TKey>
    {
       public TKey Id { get; set; }
       public string UserName { get; set; }
       public string Email { get; set; }
       public string Salt { get; set; }
       public string Password { get; set; }
       public int Position { get; set; }
       public ICollection<TUserRole> UserRoles { get; set; }
    }

}
