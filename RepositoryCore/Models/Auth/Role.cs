using RepositoryCore.Enums.Enum;
using RepositoryCore.Interfaces;


namespace RepositoryCore.Models.Auth
{
    public class Role<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
       public string Name { get; set; }
       public int Position { get; set; }
       public string Description { get; set; }
       public RoleEnum Roles { get; set; }
    }


}
