import { Coordinates } from "../../shared/models/coordinates";
import { Identity } from "../../shared/models/identity";
import { PaginatedResult } from "../../shared/models/results";

export interface ListedSales extends PaginatedResult<ListedSale> { }

export interface ListedSale {
    id: string;
    customer: ListedSaleCustomer;
    property: ListedSaleProperty;
    financialData: ListedSaleFinancialData;
    createdOn: Date;
    updatedOn: Date;
}

export interface ListedSaleCustomer {
    customerId: string;
    identity: Identity;
    email: string;
    names: string;
    lastNames: string;
    civilStatus: string;
    salary: number;
    phoneNumber: string;
}

export interface ListedSaleProperty {
    propertyId: string;
    tuition: string;
    price: number;
    coordinates: Coordinates;
    block: string;
    lot: string;
}

export interface ListedSaleFinancialData {
    price: number;
    valueToSetAside: number;
    otherPayments: number;
    compensationFundSubsidy: number;
    ministryOfHousingSubsidy: number;
    loanValue: number;
    loanEntity: number;
    debt: number;
}
