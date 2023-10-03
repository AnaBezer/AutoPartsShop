using AutoPartsShop.API.Extensions;
using AutoPartsShop.API.Repositories.Interfaces;
using AutoPartsShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDTOs = products
                        .ConvertToDTO(productCategories)
                        .Select(product => new ProductDTO
                        {
                            Id = product.Id,
                            ProductName = product.ProductName, 
                            Brand = product.Brand,
                            Description = product.Description,
                            ImageURL = product.ImageURL,
                            Price = product.Price,
                            Qty = product.Qty,
                            CategoryId = product.CategoryId,
                            CategoryName = productCategories.FirstOrDefault(c => c.Id == product.CategoryId)?.CategoryName
                        });

                    return Ok(productDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productCategory = await this.productRepository.GetCategory(product.CategoryId);

                    var productDTO = new ProductDTO
                    {
                        Id = product.Id,
                        ProductName = product.ProductName, 
                        Brand = product.Brand,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory?.CategoryName
                    };

                    return Ok(productDTO);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }

    }
}
