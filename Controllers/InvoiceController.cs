using LoginAPIDotNet7_2.Interfaces;
using LoginAPIDotNet7_2.Models;
using LoginAPIDotNet7_2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoginAPIDotNet7_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] HeaderDto headerDto)
        {

            var createdInvoice = await _invoiceService.CreateInvoiceAsync(headerDto);
            return Ok(createdInvoice);
        }

        //[HttpPost]
        //public async Task<ActionResult<ApiResponse<bool>>> CreateInvoice([FromBody] HeaderDto headerDto)
        //{
        //    if (headerDto is null)
        //    {
        //        return BadRequest(new ApiResponse<bool>
        //        {
        //            Success = false,
        //            Message = "Invalid model state",
        //            Data = false
        //        });
        //    }

        //    var result = await _invoiceService.CreateInvoiceAsync(headerDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }
        //}
    }
}
