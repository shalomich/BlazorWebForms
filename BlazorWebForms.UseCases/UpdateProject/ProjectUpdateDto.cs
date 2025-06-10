using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWebForms.UseCases.UpdateProject
{
    public class ProjectUpdateDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
