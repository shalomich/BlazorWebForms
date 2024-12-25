using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<string, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}