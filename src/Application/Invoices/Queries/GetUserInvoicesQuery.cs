using MediatR;
using System.Collections.Generic;
using Application.Invoices.ViewModels;

namespace Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<ICollection<InvoiceViewModel>>
    {
        public string User { get; set; }
    }
}
