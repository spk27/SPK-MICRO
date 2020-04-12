using Spk.Catalog.Application.Products.Queries.GetProductsList;
using Spk.Catalog.Application.Products.Commands.UpsertProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Spk.Catalog.WebUI.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListVM>> GetAll() {
            var vm = await Mediator.Send(new GetProductsListQuery());

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(UpsertProductCommand command)
        {
            return await Mediator.Send(command);
        }


    }
}
