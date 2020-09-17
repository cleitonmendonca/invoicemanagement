import moment from "moment";
import React from "react";
import { useEffect, useState } from "react"
import { Table } from "reactstrap";
import { InvoicesClient, InvoiceViewModel } from "../../utils/api"
import { getBalance } from "../../utils/invoiceUtils";

interface IInvoices {}

const Invoices: React.FC<IInvoices> = ({}) =>{
    const [invoices, setInvoices] = useState<InvoiceViewModel[]>([]);
    const client = new InvoicesClient();

    useEffect(() => {
        client.get().then(res => setInvoices(res))
        .catch(err => console.log(err));
    }, [])

    return (
        <div>
            <Table striped>
                <thead>
                    <tr>
                        <th>Invoice #</th>
                        <th>Date</th>
                        <th>Balance</th>
                    </tr>
                </thead>
                <tbody>
                   {invoices && invoices.map(invoice => <tr key={`invoice-${invoice.id}`}>
                        <td>{invoice.invoiceNumber}</td>
                        <td>{invoice.date && moment(invoice.date).format("DD MMMM YYYY")}</td>
                        <td>{getBalance(invoice)}</td>
                   </tr>)} 
                </tbody>
            </Table>
        </div>
    )
}

export default Invoices;