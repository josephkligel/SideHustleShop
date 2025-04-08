using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideHustleShop.Data;
using SideHustleShop.DTOs;
using SideHustleShop.Models;
using System.ComponentModel.DataAnnotations;

namespace SideHustleShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SideHustleShopContext _sideHustleContext;

        public ProductController(IMapper mapper, SideHustleShopContext sideHustleContext)
        {
            _mapper = mapper;
            _sideHustleContext = sideHustleContext;
        }

        [HttpGet("/GetProductById")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromQuery] int productId)
        {
            var product = await _sideHustleContext.Products
                .SingleOrDefaultAsync(x => x.Id == productId);

            if (product == null) return new NotFoundResult();

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return new JsonResult(productDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            Product product = _mapper.Map<Product>(productDto);

            await _sideHustleContext.AddAsync(product);

            await _sideHustleContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductById([Required]int id)
        {
            var product = await _sideHustleContext.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            _sideHustleContext.Products.Remove(product);

            return Ok();
        }
    }

    
}
