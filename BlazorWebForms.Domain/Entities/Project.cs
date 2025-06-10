using System;
using System.Collections.Generic;

namespace BlazorWebForms.Domain.Entities
{
    public class Project
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<Developer> Developers { get; private set; } = new List<Developer>();
    }
}
