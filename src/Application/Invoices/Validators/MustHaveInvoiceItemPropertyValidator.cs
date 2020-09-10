using System.Linq;
using System.Collections.Generic;
using FluentValidation.Validators;
using Application.Invoices.ViewModels;

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