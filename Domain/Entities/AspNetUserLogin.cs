using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class AspNetUserLogin : IdentityUserLogin<string>
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
