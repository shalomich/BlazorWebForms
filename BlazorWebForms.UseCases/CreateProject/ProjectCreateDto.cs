using System.ComponentModel.DataAnnotations;

namespace BlazorWebForms.UseCases.CreateProject
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
