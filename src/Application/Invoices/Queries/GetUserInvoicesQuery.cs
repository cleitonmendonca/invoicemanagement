using MediatR;
using Application.Common.Behaviors;

namespace Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<Response>
    {
        public string User { get; set; }
    }
}
