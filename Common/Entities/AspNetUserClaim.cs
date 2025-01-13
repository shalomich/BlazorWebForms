using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Common.Entities
{
    public partial class AspNetUserClaim : IdentityUserClaim<string>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
