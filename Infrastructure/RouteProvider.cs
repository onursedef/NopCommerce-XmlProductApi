using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.XmlApi.Infrastructure;

public class RouteProvider : IRouteProvider
{
    /// <summary>
    /// Register routes
    /// </summary>
    /// <param name="endpointRouteBuilder">Route builder</param>
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(XmlApiDefaults.DefaultController, "Api/Products",
            new { controller = "XmlApi", action = "ProductList" });
    }

    /// <summary>
    /// Gets a priority of route provider
    /// </summary>
    public int Priority => 1;
}