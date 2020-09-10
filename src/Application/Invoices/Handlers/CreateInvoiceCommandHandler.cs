﻿using Application.Common.Interfaces;
using Application.Invoices.Commands;

using MediatR;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

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
            var entity = new Invoice
            {
                AmountPaid = request.AmountPaid,
                Date = request.Date,
                Discount = request.Discount,
                DiscountType = request.DiscountType,
                DueDate = request.DueDate,
                From = request.From,
                InvoiceNumber = request.InvoiceNumber,
                Logo = request.Logo,
                PaymentTerms = request.PaymentTerms,
                Tax = request.Tax,
                TaxType = request.TaxType,
                To = request.To,
                InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                {
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Rate = i.Rate
                }).ToList()
            };
            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
