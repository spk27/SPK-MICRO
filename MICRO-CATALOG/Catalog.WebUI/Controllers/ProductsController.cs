using Spk.Catalog.Application.Products.Queries.GetProductBasics;
using Spk.Catalog.Application.Products.Queries.GetProductsList;
using Spk.Catalog.Application.Products.Commands.UpsertProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Spk.Catalog.WebUI.Controllers
{
    // [Authorize]
    public class ProductsController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBasicsVM>> GetBasics(long id) 
            => await Mediator.Send(new GetProductBasicsQuery() { Id = id });
        
        [HttpGet]
        public async Task<ActionResult<ProductsListVM>> GetAll() 
            => await Mediator.Send(new GetProductsListQuery());
        

        [HttpPost]
        public async Task<ActionResult<long>> Create(UpsertProductCommand command)
            => await Mediator.Send(command);


    }
}
