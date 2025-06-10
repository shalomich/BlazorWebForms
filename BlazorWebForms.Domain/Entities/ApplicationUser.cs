using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlazorWebForms.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}