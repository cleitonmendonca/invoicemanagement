using System.Collections.Generic;
using System.Linq;
using Application.Invoices.ViewModels;
using FluentValidation.Validators;

namespace Application.Invoices.Validators
{
    public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    {
        public MustHaveInvoiceItemPropertyValidator() 
            : base("Property {PropertyName} should not be an empty!")
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<InvoiceItemViewModel>;
            return list != null && list.Any();
        }
    }
}