using Microsoft.AspNetCore.Mvc;
using MS.Suppliers.Application.Commands;
using MS.Suppliers.Application.Queries;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using util_net;

namespace MS.Suppliers.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierQuery _supplierQuery;
        public SupplierController(ISupplierQuery supplierQuery)
        {
            _supplierQuery = supplierQuery;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSupplier(CreateSupplierCommand command)
        {
            CultureInfo ci = new CultureInfo("es-PE");
            TextInfo textInfo = ci.TextInfo;
            var ggg = "caja de herramientaS, hola a mundo";
            var dddd = textInfo.ToTitleCase(ggg);
            var textResult = Core.GetNameFormat(ggg);
            var result = await Task.FromResult(command);
            return CreatedAtAction(nameof(CreateSupplier), command);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDevice(UpdateSupplierCommand command)
        {
            var result = await Task.FromResult(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-state")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateState(UpdateSupplierStateCommand command)
        {
            var result = await Task.FromResult(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SupplierViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _supplierQuery.GetById(id);
            return Ok(result);
        }

        [Route("pagination")]
        [HttpGet]
        [ProducesResponseType(typeof(SupplierPaginationViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Pagination([FromQuery]SupplierFilter filter)
        {
            try
            {
                var result = await _supplierQuery.Pagination(filter);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}