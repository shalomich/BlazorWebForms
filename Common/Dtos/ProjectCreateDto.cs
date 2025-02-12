using System.ComponentModel.DataAnnotations;

namespace Common.Dtos
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
