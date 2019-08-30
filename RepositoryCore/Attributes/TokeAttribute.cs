using System;

namespace RepositoryCore.Attributes
{
    public class TokenAttribute : Attribute
    {
        public string Name { get; set; }
        public bool Required { get; set; }
    }
}
