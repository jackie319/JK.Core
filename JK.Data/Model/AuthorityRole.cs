using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class AuthorityRole
    {
        public AuthorityRole()
        {
            AuthorityRoleInFunction = new HashSet<AuthorityRoleInFunction>();
            AuthorityUserInRole = new HashSet<AuthorityUserInRole>();
        }

        public Guid RoleGuid { get; set; }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int DisplayOrder { get; set; }
        public string RoleEnumName { get; set; }
        public string Remark { get; set; }
        public string RoleType { get; set; }
        public bool Enable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        public ICollection<AuthorityRoleInFunction> AuthorityRoleInFunction { get; set; }
        public ICollection<AuthorityUserInRole> AuthorityUserInRole { get; set; }
    }
}
