using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Invoices.Queries;
using Application.Invoices.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, ICollection<InvoiceViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<InvoiceViewModel>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceViewModel>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
            if (invoices != null)
            {
                result = _mapper.Map<List<InvoiceViewModel>>(invoices);
            }

            return result;
        }
    }
}
