using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class AuthorityFunction
    {
        public AuthorityFunction()
        {
            AuthorityRoleInFunction = new HashSet<AuthorityRoleInFunction>();
        }

        public Guid FunctionGuid { get; set; }
        public int Id { get; set; }
        public Guid ParentGuid { get; set; }
        public string FunctionName { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string ActionUrl { get; set; }
        public string FunctionType { get; set; }
        public string PlatForm { get; set; }
        public bool Enable { get; set; }
        public DateTime TimeCreated { get; set; }

        public ICollection<AuthorityRoleInFunction> AuthorityRoleInFunction { get; set; }
    }
}
