namespace Common.Web
{
    public static class NewAppPaths
    {
        public const string Logout = "logout";

        public const string Projects = "projects";

        public const string ProjectDetailsTemplate = Projects + "/{id:int}";

        /// <inheritdoc/>
        public static string GetProjectDetails(int projectId)
        {
            return ProjectDetailsTemplate.Replace("{id:int}", projectId.ToString());
        }
    }
}