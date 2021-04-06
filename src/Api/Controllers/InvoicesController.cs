using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Application.Common.Interfaces;
using Application.Invoices.Commands;
using Application.Invoices.Queries;
using Application.Invoices.ViewModels;

namespace Api.Controllers
{
    [Authorize]
    public class InvoicesController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoicesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceCommand command)
        {
            var response = await Mediator.Send(command);
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Result);
        }

        [HttpGet]
        public async Task<ICollection<InvoiceViewModel>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery { User = _currentUserService.UserId });
        }
    }
}
