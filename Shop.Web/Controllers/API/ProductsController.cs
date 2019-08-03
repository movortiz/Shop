namespace Shop.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using Data;

    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {

        public IProductRepository productRepository { get; }
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
