using System.Collections.Generic;
using Application.Invoices.ViewModels;
using MediatR;

namespace Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<ICollection<InvoiceViewModel>>
    {
        public string User { get; set; }
    }
}
