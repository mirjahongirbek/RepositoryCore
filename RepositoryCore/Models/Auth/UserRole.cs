using RepositoryCore.Interfaces;

namespace RepositoryCore.Models.Auth
{
    public class UserRole<TKey>:IEntity<TKey>
    {
        public TKey Id { get; set; }
     public   int UserId { get; set; }
     public   User<UserRole<TKey>,TKey> User { get; set;}
     public   int RoleId { get; set; }
     public   Role<TKey> Role { get; set; }
    }


}
