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
        private readonly UnitOfWork _unitOfWork;

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Route("GetProducts")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 6)
        {
            try
            {
                IEnumerable<Product> products = _unitOfWork.productRepository.GetProductsPaginated(pageNumber, pageSize);

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,ex.Message,ex.StackTrace);

                return NotFound();
            }
        }

        [Route("InsertProduct")]
        [HttpPost]
        public ActionResult<Product> InsertProduct([FromBody] JsonInsertProduct jsonInsertProduct)
        {
            try
            {
                Category category = _unitOfWork.categoryRepository.GetCategoryByCode(jsonInsertProduct.CategoryCode);

                if (category == null)
                    return NotFound("Categoria não encontrada");

                Product product = new Product()
                {
                    Name = jsonInsertProduct.Name,
                    CategoryId = category.Id,
                    Price = jsonInsertProduct.Price,
                    ImageUrl = jsonInsertProduct.ImageUrl
                };

                _unitOfWork.productRepository.Insert(product);

                _unitOfWork.Commit();

                return new CreatedAtRouteResult("GetProductById", new { id = product.Id }, product);
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
                Product product = _unitOfWork.productRepository.GetById(product => product.Id == Id);

                if (product == null)
                    return NotFound("Produto não econtrado");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
