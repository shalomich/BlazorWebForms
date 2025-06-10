namespace BlazorWebForms.Web.Common.Web
{
    public static class NewAppPaths
    {
        public const string IdTemplate = "{id:int}";
        public const string ProjectDetailsTemplate = "projects/" + IdTemplate;

        /// <inheritdoc/>
        public static string GetProjectDetails(int projectId)
        {
            return ProjectDetailsTemplate.Replace(IdTemplate, projectId.ToString());
        }
    }
}