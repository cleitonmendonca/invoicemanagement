using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Domain.Enums;
using Domain.Common;

namespace Domain.Entities
{
    public class Invoice : AuditEntity
    {
        public Invoice()
        {
            this.InvoiceItems = new Collection<InvoiceItem>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public TaxType TaxType { get; set; }
        public double Tax { get; set; }
        public double AmountPaid { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
