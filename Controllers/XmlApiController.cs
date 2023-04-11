using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Catalog;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.XmlApi.Controllers;

public class XmlApiController : BasePluginController
{
    #region Fields

    private readonly IProductService _productService;

    #endregion

    public XmlApiController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductListAsync()
    {
        var products = await _productService.SearchProductsAsync(showHidden: true);

        var xml = new XElement("Products", products.Select(p =>
            new XElement("Product",
                new XElement("Id", p.Id),
                new XElement("Name", p.Name),
                new XElement("Description", p.FullDescription),
                new XElement("Price", p.Price)
            )));

        return Content(xml.ToString(), "text/xml");
    }
}