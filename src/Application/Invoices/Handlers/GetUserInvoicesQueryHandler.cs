using Application.Common.Interfaces;
using Application.Invoices.Queries;
using Application.Invoices.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Behaviors;

namespace Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, Response>
    {
        private readonly IInvoiceDbContext _context;
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IInvoiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            //var response = new Response();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync(cancellationToken);
                
            var response = new Response(_mapper.Map<List<InvoiceViewModel>>(invoices));
            return response;
        }
    }
}
