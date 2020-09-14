/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.7.1.0 (NJsonSchema v10.1.26.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import authService from "../components/api-authorization/AuthorizeService";
export class ApiClientBase{
    baseApiUrl: string = "https://localhost:44385/";

    protected async transformOptions(options: RequestInit): Promise<RequestInit>{
        const token = await authService.getAccessToken();
        options.headers = {...options.headers, authorization: `Bearer ${token}`};
        return Promise.resolve(options);
    }

    protected transformResult(url: string, response: Response, processor: (response: Response) => any){
        return processor(response);
    }

    protected getBaseUrl(defaultUrl: string, baseUrl?: string){
        return this.baseApiUrl;
    }
}
export class InvoicesClient extends ApiClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : <any>window;
        this.baseUrl = this.getBaseUrl("https://localhost:44385", baseUrl);
    }

    create(command: CreateInvoiceCommand): Promise<number> {
        let url_ = this.baseUrl + "/api/Invoices";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processCreate(_response));
        });
    }

    protected processCreate(response: Response): Promise<number> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<number>(<any>null);
    }

    get(): Promise<InvoiceViewModel[]> {
        let url_ = this.baseUrl + "/api/Invoices";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGet(_response));
        });
    }

    protected processGet(response: Response): Promise<InvoiceViewModel[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(InvoiceViewModel.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<InvoiceViewModel[]>(<any>null);
    }
}

export class OidcConfigurationClient extends ApiClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : <any>window;
        this.baseUrl = this.getBaseUrl("https://localhost:44385", baseUrl);
    }

    getClientRequestParameters(clientId: string | null): Promise<FileResponse> {
        let url_ = this.baseUrl + "/_configuration/{clientId}";
        if (clientId === undefined || clientId === null)
            throw new Error("The parameter 'clientId' must be defined.");
        url_ = url_.replace("{clientId}", encodeURIComponent("" + clientId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/octet-stream"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGetClientRequestParameters(_response));
        });
    }

    protected processGetClientRequestParameters(response: Response): Promise<FileResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return response.blob().then(blob => { return { fileName: fileName, data: blob, status: status, headers: _headers }; });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<FileResponse>(<any>null);
    }
}

export class WeatherForecastClient extends ApiClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : <any>window;
        this.baseUrl = this.getBaseUrl("https://localhost:44385", baseUrl);
    }

    get(): Promise<WeatherForecast[]> {
        let url_ = this.baseUrl + "/WeatherForecast";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.transformResult(url_, _response, (_response: Response) => this.processGet(_response));
        });
    }

    protected processGet(response: Response): Promise<WeatherForecast[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(WeatherForecast.fromJS(item));
            }
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<WeatherForecast[]>(<any>null);
    }
}

export class CreateInvoiceCommand implements ICreateInvoiceCommand {
    invoiceNumber?: string | undefined;
    logo?: string | undefined;
    from?: string | undefined;
    to?: string | undefined;
    date?: Date;
    paymentTerms?: string | undefined;
    dueDate?: Date | undefined;
    discount?: number;
    discountType?: DiscountType;
    tax?: number;
    taxType?: TaxType;
    amountPaid?: number;
    invoiceItems?: InvoiceItemViewModel[] | undefined;

    constructor(data?: ICreateInvoiceCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.invoiceNumber = _data["invoiceNumber"];
            this.logo = _data["logo"];
            this.from = _data["from"];
            this.to = _data["to"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.paymentTerms = _data["paymentTerms"];
            this.dueDate = _data["dueDate"] ? new Date(_data["dueDate"].toString()) : <any>undefined;
            this.discount = _data["discount"];
            this.discountType = _data["discountType"];
            this.tax = _data["tax"];
            this.taxType = _data["taxType"];
            this.amountPaid = _data["amountPaid"];
            if (Array.isArray(_data["invoiceItems"])) {
                this.invoiceItems = [] as any;
                for (let item of _data["invoiceItems"])
                    this.invoiceItems!.push(InvoiceItemViewModel.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CreateInvoiceCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateInvoiceCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["invoiceNumber"] = this.invoiceNumber;
        data["logo"] = this.logo;
        data["from"] = this.from;
        data["to"] = this.to;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["paymentTerms"] = this.paymentTerms;
        data["dueDate"] = this.dueDate ? this.dueDate.toISOString() : <any>undefined;
        data["discount"] = this.discount;
        data["discountType"] = this.discountType;
        data["tax"] = this.tax;
        data["taxType"] = this.taxType;
        data["amountPaid"] = this.amountPaid;
        if (Array.isArray(this.invoiceItems)) {
            data["invoiceItems"] = [];
            for (let item of this.invoiceItems)
                data["invoiceItems"].push(item.toJSON());
        }
        return data; 
    }
}

export interface ICreateInvoiceCommand {
    invoiceNumber?: string | undefined;
    logo?: string | undefined;
    from?: string | undefined;
    to?: string | undefined;
    date?: Date;
    paymentTerms?: string | undefined;
    dueDate?: Date | undefined;
    discount?: number;
    discountType?: DiscountType;
    tax?: number;
    taxType?: TaxType;
    amountPaid?: number;
    invoiceItems?: InvoiceItemViewModel[] | undefined;
}

export enum DiscountType {
    Flat = 0,
    Percentage = 1,
}

export enum TaxType {
    Flat = 0,
    Percentage = 1,
}

export class InvoiceItemViewModel implements IInvoiceItemViewModel {
    id?: number;
    item?: string | undefined;
    quantity?: number;
    rate?: number;
    amount?: number;

    constructor(data?: IInvoiceItemViewModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.item = _data["item"];
            this.quantity = _data["quantity"];
            this.rate = _data["rate"];
            this.amount = _data["amount"];
        }
    }

    static fromJS(data: any): InvoiceItemViewModel {
        data = typeof data === 'object' ? data : {};
        let result = new InvoiceItemViewModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["item"] = this.item;
        data["quantity"] = this.quantity;
        data["rate"] = this.rate;
        data["amount"] = this.amount;
        return data; 
    }
}

export interface IInvoiceItemViewModel {
    id?: number;
    item?: string | undefined;
    quantity?: number;
    rate?: number;
    amount?: number;
}

export class InvoiceViewModel implements IInvoiceViewModel {
    id?: number;
    invoiceNumber?: string | undefined;
    logo?: string | undefined;
    from?: string | undefined;
    to?: string | undefined;
    date?: Date;
    paymentTerms?: string | undefined;
    dueDate?: Date | undefined;
    discountType?: DiscountType;
    discount?: number;
    taxType?: TaxType;
    tax?: number;
    amountPaid?: number;
    invoiceItems?: InvoiceItemViewModel[] | undefined;
    created?: Date;

    constructor(data?: IInvoiceViewModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.invoiceNumber = _data["invoiceNumber"];
            this.logo = _data["logo"];
            this.from = _data["from"];
            this.to = _data["to"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.paymentTerms = _data["paymentTerms"];
            this.dueDate = _data["dueDate"] ? new Date(_data["dueDate"].toString()) : <any>undefined;
            this.discountType = _data["discountType"];
            this.discount = _data["discount"];
            this.taxType = _data["taxType"];
            this.tax = _data["tax"];
            this.amountPaid = _data["amountPaid"];
            if (Array.isArray(_data["invoiceItems"])) {
                this.invoiceItems = [] as any;
                for (let item of _data["invoiceItems"])
                    this.invoiceItems!.push(InvoiceItemViewModel.fromJS(item));
            }
            this.created = _data["created"] ? new Date(_data["created"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): InvoiceViewModel {
        data = typeof data === 'object' ? data : {};
        let result = new InvoiceViewModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["invoiceNumber"] = this.invoiceNumber;
        data["logo"] = this.logo;
        data["from"] = this.from;
        data["to"] = this.to;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["paymentTerms"] = this.paymentTerms;
        data["dueDate"] = this.dueDate ? this.dueDate.toISOString() : <any>undefined;
        data["discountType"] = this.discountType;
        data["discount"] = this.discount;
        data["taxType"] = this.taxType;
        data["tax"] = this.tax;
        data["amountPaid"] = this.amountPaid;
        if (Array.isArray(this.invoiceItems)) {
            data["invoiceItems"] = [];
            for (let item of this.invoiceItems)
                data["invoiceItems"].push(item.toJSON());
        }
        data["created"] = this.created ? this.created.toISOString() : <any>undefined;
        return data; 
    }
}

export interface IInvoiceViewModel {
    id?: number;
    invoiceNumber?: string | undefined;
    logo?: string | undefined;
    from?: string | undefined;
    to?: string | undefined;
    date?: Date;
    paymentTerms?: string | undefined;
    dueDate?: Date | undefined;
    discountType?: DiscountType;
    discount?: number;
    taxType?: TaxType;
    tax?: number;
    amountPaid?: number;
    invoiceItems?: InvoiceItemViewModel[] | undefined;
    created?: Date;
}

export class WeatherForecast implements IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    temperatureF?: number;
    summary?: string | undefined;

    constructor(data?: IWeatherForecast) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.temperatureC = _data["temperatureC"];
            this.temperatureF = _data["temperatureF"];
            this.summary = _data["summary"];
        }
    }

    static fromJS(data: any): WeatherForecast {
        data = typeof data === 'object' ? data : {};
        let result = new WeatherForecast();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["temperatureC"] = this.temperatureC;
        data["temperatureF"] = this.temperatureF;
        data["summary"] = this.summary;
        return data; 
    }
}

export interface IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    temperatureF?: number;
    summary?: string | undefined;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}