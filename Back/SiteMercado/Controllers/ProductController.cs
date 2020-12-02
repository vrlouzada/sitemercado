
using Library.Contracts;
using Library.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SiteMercado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _productService = productService;
        }


        // GET: ProdutcController
        [HttpGet("GetAll")]
        public ActionResult Index()
        {
            return Ok(_productService.GetAll());
        }
                

        // POST: ProdutcController/
        [HttpPost("Insert")]
        public ActionResult Create(ProdutoDTO produto)
        {
            return Ok(_productService.Insert(produto));
        }

        
        // PUT: ProdutcController/
        [HttpPut("Update")]
        public ActionResult Edit(ProdutoDTO produto)
        {
            return Ok(_productService.Update(produto));
        }


        // PUT: ProdutcController/
        [HttpPut("Delete")]
        public ActionResult Delete(ProdutoDTO produto)
        {
            return Ok(_productService.Delete(produto.Id));
        }

    }
}
