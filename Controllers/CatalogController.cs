using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        #region Constructor

        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion

        #region get products

        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<Product>), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        #endregion

        #region get product

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(type: typeof(Product), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError(message: "product with id {Id} is not found", id);
                return NotFound();
            }

            return Ok(product);
        }

        #endregion

        #region get product by category name

        [HttpGet("[action]/{category}")]
        [ProducesResponseType(type: typeof(IEnumerable<Product>), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _productRepository.GetProductByCategory(category);
            return Ok(products);
        }

        #endregion

        #region create product

        [HttpPost]
        [ProducesResponseType(type: typeof(Product), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);
            return CreatedAtRoute(routeName: "GetProduct", routeValues: new { id = product.Id }, value: product);
        }

        #endregion

        #region update product

        [HttpPut]
        [ProducesResponseType(type: typeof(Product), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            var result = await _productRepository.UpdateProduct(product);
            return Ok(result);
        }

        #endregion

        #region delete product

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(type: typeof(Product), statusCode: (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            var result = await _productRepository.DeleteProduct(id);
            return Ok(result);
        }

        #endregion
    }
}