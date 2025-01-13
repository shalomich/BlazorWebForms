namespace Common.Web
{
    public static class NewAppPaths
    {
        public const string ProjectDetailsTemplate = "/projects/{id:int}";

        public const string Logout = "Logout";

        /// <inheritdoc/>
        public static string GetProjectDetails(int projectId)
        {
            return ProjectDetailsTemplate.Replace("{id:int}", projectId.ToString());
        }
    }
}