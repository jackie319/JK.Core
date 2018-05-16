using System;
using System.Collections.Generic;

namespace JK.Data.Model
{
    public partial class AuthorityUserInRole
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public Guid RoleGuid { get; set; }
        public DateTime TimeCreated { get; set; }

        public AuthorityRole RoleGu { get; set; }
    }
}
