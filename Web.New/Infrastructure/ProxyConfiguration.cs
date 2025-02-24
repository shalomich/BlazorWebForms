namespace Web.New.Infrastructure;

public static class ProxyConfiguration
{
    public static void ConfigureProxy(this WebApplication app, IConfiguration configuration)
    {
        var legacyAppUrl = configuration["App:LegacyAppBasePath"];

        app.MapForwarder("/Scripts/{**catchAll}", legacyAppUrl).Add(static builder 
            => ((RouteEndpointBuilder)builder).Order = 1);
        
        app.MapForwarder("/Content/{**catchAll}", legacyAppUrl).Add(static builder 
            => ((RouteEndpointBuilder)builder).Order = 2);
        
        app.MapForwarder("/bundles/{**catchAll}", legacyAppUrl).Add(static builder 
            => ((RouteEndpointBuilder)builder).Order = 3);
        
        app.MapForwarder("/_framework/{**catchAll}", legacyAppUrl).Add(static builder 
            => ((RouteEndpointBuilder)builder).Order = 4);
        
        app.MapForwarder("/projects", legacyAppUrl).Add(static builder
            => ((RouteEndpointBuilder)builder).Order = 5);
        
        app.MapForwarder("/projects/update", legacyAppUrl).Add(static builder
            => ((RouteEndpointBuilder)builder).Order = 6);
    }
}
