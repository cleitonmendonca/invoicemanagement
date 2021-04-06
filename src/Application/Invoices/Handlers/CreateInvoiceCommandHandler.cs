using Application.Common.Interfaces;
using Application.Invoices.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Behaviors;
using Application.Invoices.ViewModels;

namespace Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Response>
    {
        private readonly IInvoiceDbContext _context;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IInvoiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Invoice>(request);

            await _context.Invoices.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response(_mapper.Map<InvoiceViewModel>(entity));
            return response;
        }
    }
}
