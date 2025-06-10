using System;

namespace BlazorWebForms.UseCases.GetProjectId
{
    public class ProjectDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserName { get; set; }
    }
}
