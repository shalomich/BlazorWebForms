using System;
using BlazorWebForms.Domain.Entities;

namespace BlazorWebForms.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        DbSet<ApplicationUser> AspNetUsers { get; set; }
        DbSet<Developer> Developers { get; set; }
        DbSet<MigrationHistory> MigrationHistory { get; set; }
        DbSet<Project> Projects { get; set; }
    }
}
