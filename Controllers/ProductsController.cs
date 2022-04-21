using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Annotations;
using WebApi.Json;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogAsyncFilter))]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [Route("GetProducts")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                IEnumerable<Product> products = _productRepository.Get();

                return Ok(products);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("InsertProduct")]
        [HttpPost]
        public ActionResult<Product> InsertProduct([FromBody] JsonInsertProduct jsonInsertProduct, [FromServices] CategoryRepository _categoryRepository)
        {
            try
            {
                Category category = _categoryRepository.GetCategoryByCode(jsonInsertProduct.CategoryCode);

                if (category == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Categoria não encontrada");

                Product product = new Product()
                {
                    Name = jsonInsertProduct.Name,
                    CategoryId = category.Id,
                    Price = jsonInsertProduct.Price,
                    ImageUrl = jsonInsertProduct.ImageUrl
                };

                _productRepository.Insert(product);

                return Created($@"api/Products/GetProductById/{product.Id}", product);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("GetProductById")]
        [HttpGet]
        public ActionResult<Product> GetProductById([FromQuery] long Id)
        {
            try
            {
                Product product = _productRepository.GetById(product => product.Id == Id);

                return Ok(product);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
