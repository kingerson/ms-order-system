using Microsoft.AspNetCore.Mvc;
using MS.Products.Application;
using MS.Products.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MS.Products.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;
        private readonly IProductRepository _productRepository;
        private readonly IDateService _dateService;

        public ProductController(
            IProductQuery productQuery,
            IProductRepository productRepository,
            IDateService dateService)
        {
            _productQuery = productQuery;
            _productRepository = productRepository;
            _dateService = dateService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateProduct(Product model)
        {
            model.register_date = _dateService.GetDate();
            var result = await _productRepository.Create(model);
            return CreatedAtAction(nameof(CreateProduct), result);
        }


        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDevice(Product model)
        {
            model.register_date = _dateService.GetDate();
            var result = await _productRepository.Update(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-state")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateState(Product model)
        {
            var result = await _productRepository.Update_State(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productQuery.GetById(id);
            return Ok(result);
        }

        [Route("pagination")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductPaginationViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Pagination([FromQuery]ProductFilter filter)
        {
            try
            {
                var result = await _productQuery.Pagination(filter);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}