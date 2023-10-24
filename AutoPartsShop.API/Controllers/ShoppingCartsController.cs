using AutoPartsShop.DataAccess.Extensions;
using AutoPartsShop.DataAccess.Repositories.Interfaces;
using AutoPartsShop.DataAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public ShoppingCartsController(IShoppingCartRepository shoppingCartRepository,
                                      IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId}/GetProducts")]
        public async Task<ActionResult<IEnumerable<ShoppingCartProductDTO>>> GetProducts(int userId)
        {
            try
            {
                var shoppingCartProducts = await this.shoppingCartRepository.GetProducts(userId);

                if (shoppingCartProducts == null)
                {
                    return NoContent();
                }

                var products = await this.productRepository.GetProducts();

                if (products == null)
                {
                    throw new Exception("No products exist in the system");
                }

                var shoppingCartProductDTO = shoppingCartProducts.ConvertToDTO(products);

                return Ok(shoppingCartProductDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShoppingCartProductDTO>> GetProductById(int id)
        {
            try
            {
                var shoppingCartProduct = await this.shoppingCartRepository.GetProduct(id);
                if (shoppingCartProduct == null)
                {
                    return NotFound();
                }
                var product = await productRepository.GetProduct(shoppingCartProduct.ProductId);

                if (product == null)
                {
                    return NotFound();
                }
                var shoppingCartProductDTO = shoppingCartProduct.ConvertToDTO(product);

                return Ok(shoppingCartProductDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartProductDTO>> PostProduct([FromBody] ShoppingCartProductToAddDTO shoppingCartProductToAddDTO)
        {
            try
            {
                var newShoppingCartProduct = await this.shoppingCartRepository.AddProduct(shoppingCartProductToAddDTO);

                if (newShoppingCartProduct == null)
                {
                    return NoContent();
                }

                var product = await productRepository.GetProduct(newShoppingCartProduct.ProductId);

                if (product == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId:({newShoppingCartProduct.ProductId})");
                }

                var newShoppingCartProductDTO = newShoppingCartProduct.ConvertToDTO(product);

                return CreatedAtAction(nameof(GetProducts), new { id = newShoppingCartProductDTO.Id }, newShoppingCartProductDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ShoppingCartProductDTO>> DeleteProduct(int id)
        {
            try
            {
                var shoppingCartProduct = await this.shoppingCartRepository.DeleteProduct(id);

                if (shoppingCartProduct == null)
                {
                    return NotFound();
                }

                var product = await this.productRepository.GetProduct(shoppingCartProduct.ProductId);

                if (product == null)
                    return NotFound();

                var shoppingCartProductDTO = shoppingCartProduct.ConvertToDTO(product);

                return Ok(shoppingCartProductDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ShoppingCartProductDTO>> UpdateQty(int id, ShoppingCartProductQtyUpdateDTO shoppingCartProductQtyUpdateDTO)
        {
            try
            {
                var shoppingCartProduct = await this.shoppingCartRepository.UpdateQty(id, shoppingCartProductQtyUpdateDTO);
                if (shoppingCartProduct == null)
                {
                    return NotFound();
                }

                var product = await productRepository.GetProduct(shoppingCartProduct.ProductId);

                var shoppingCartProductDTO = shoppingCartProduct.ConvertToDTO(product);

                return Ok(shoppingCartProductDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}