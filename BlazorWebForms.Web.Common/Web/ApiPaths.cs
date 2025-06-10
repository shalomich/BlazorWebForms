namespace BlazorWebForms.Web.Common.Web
{
    public static class ApiPaths
    {
        public const string IdTemplate = "{id:int}";

        public const string Logout = "logout";

        private const string Projects = "projects";

        public const string UpdateProjectTemplate = Projects + "/" + IdTemplate;

        public const string CreateProject = Projects;

        public static string UpdateProject(int projectId)
        {
            return UpdateProjectTemplate.Replace(IdTemplate, projectId.ToString());
        }
    }
}
