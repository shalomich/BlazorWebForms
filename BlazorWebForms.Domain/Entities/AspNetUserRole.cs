using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlazorWebForms.Domain.Entities
{
    public partial class AspNetUserRole : IdentityUserRole<string>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
