using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Dtos
{
    public class ProjectCreateDto : IValidatableObject
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required");
            }

            if (string.IsNullOrEmpty(UserId))
            {
                yield return new ValidationResult("User id is required");
            }
        }
    }
}
