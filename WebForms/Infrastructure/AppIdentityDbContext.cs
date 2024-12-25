using System.Data.Entity;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebForms.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, AspNetRole, string, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}