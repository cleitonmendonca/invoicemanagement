using Application.Common.Interfaces;
using Application.Invoices.Commands;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
