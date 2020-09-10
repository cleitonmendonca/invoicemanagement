using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Invoices.Commands;
using Application.Invoices.Queries;
using Application.Invoices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ICollection<InvoiceViewModel>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery {User = _currentUserService.UserId});
        }
    }
}
