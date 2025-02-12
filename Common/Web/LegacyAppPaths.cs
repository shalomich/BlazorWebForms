using Microsoft.Extensions.Options;

namespace Common.Web
{
    public static class LegacyAppPaths
    {
        public const string ProjectsPath = "/projects";

        public const string LoginPath = "/Login";

        public const string LogoutPath = "/Logout";
        public static string ProjectUpdatePath(int projectId) => $"{ProjectsPath}/update?id={projectId}";
    }
}
