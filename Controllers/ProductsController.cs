using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Annotations;
using Api.Json;

using Api.DTO;
using Api.DTO.Mapping;

using Application.Domain.Entities;
using Application.Data.Interfaces;
using Application.Data.Repositories;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [ServiceFilter(typeof(LogAsyncFilter))]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<ProductsController> _logger;

        private readonly MappingTool _mappingTool;

        public ProductsController(ILogger<ProductsController> logger, UnitOfWork unitOfWork, MappingTool mappingTool)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mappingTool = mappingTool;
        }

        [Route("GetProducts")]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts(int pageNumber = 1, int pageSize = 6)
        {
            try
            {
                IEnumerable<Product> products = _unitOfWork.productRepository.GetProductsPaginated(pageNumber, pageSize);

                if(products == null)
                return NoContent();

                IEnumerable<ProductDTO> productsDTOList = _mappingTool.AutomaticMapper<Product, ProductDTO>(products);

                return Ok(productsDTOList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);

                return NotFound();
            }
        }

        [Route("InsertProduct")]
        [HttpPost]
        public ActionResult<Product> InsertProduct([FromBody] InsertProductDTO jsonInsertProduct)
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

                return Ok(new { product = product, rel = $"https://localhost:5001/api/Products/GetProductById?Id={product.Id}" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("GetProductById")]
        [HttpGet]
        public ActionResult<ProductDTO> GetProductById([FromQuery] long Id)
        {
            try
            {
                Product product = _unitOfWork.productRepository.GetById(product => product.Id == Id);

                if (product == null)
                    return NotFound("Produto não econtrado");

                var productDTO = _mappingTool.AutomaticMapper<Product, ProductDTO>(product);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
