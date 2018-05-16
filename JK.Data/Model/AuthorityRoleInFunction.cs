using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class AuthorityRoleInFunction
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid RoleGuid { get; set; }
        public Guid FunctionGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public AuthorityFunction FunctionGu { get; set; }
        public AuthorityRole RoleGu { get; set; }
    }
}
