using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SideHustleShop.Data;
using SideHustleShop.DTOs;

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

        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromQuery] int productId)
        {
            var product = await _sideHustleContext.Products
                .SingleOrDefaultAsync(x => x.Id == productId);

            if (product == null) return new NotFoundResult();

            ProductDto productDto = _mapper.Map<ProductDto>(product);

            return new JsonResult(productDto);
        }
    }
}
