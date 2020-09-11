using AutoMapper;
using Domain.Entities;
using Application.Invoices.Commands;
using Application.Invoices.ViewModels;

namespace Application.Invoices.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceViewModel>();
            CreateMap<InvoiceItem, InvoiceItemViewModel>().ConstructUsing(item => new InvoiceItemViewModel
            {
                Item = item.Item,
                Quantity = item.Quantity,
                Rate = item.Rate
            });

            CreateMap<InvoiceViewModel, Invoice>();
            CreateMap<InvoiceItemViewModel, InvoiceItem>();

            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}
