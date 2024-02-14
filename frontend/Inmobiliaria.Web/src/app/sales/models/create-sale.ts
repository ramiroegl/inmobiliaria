import { Coordinates } from "../../shared/models/coordinates";
import { Identity } from "../../shared/models/identity";

export interface CreateSale {
    customer: CreateCustomerSale,
    property: CreatePropertySale,
    financialData: CreateFinancialDataSale,
    documentaryData: CreateDocumentaryDataSale
}

export interface CreateCustomerSale {
    names: string,
    lastNames: string,
    email: string,
    identity: Identity,
    salary: number,
    civilStatus: string,
    phoneNumber: string
}

export interface CreatePropertySale {
    price: number,
    coordinates: Coordinates,
    tuition: string,
    block: string,
    lot: string
}

export interface CreateFinancialDataSale {
    price: number,
    valueToSetAside: number,
    otherPayments: number,
    compensationFundSubsidy: number,
    ministryOfHousingSubsidy: number,
    loanValue: number,
    loanEntity: string,
    debt: number
}

export interface CreateDocumentaryDataSale {
    identificationDocument: boolean,
    signedPledge: boolean,
    creditApprovalLetter: boolean,
    approvalLetterNumber: boolean,
    compensationFundRecordNumber: boolean,
    ministrySubsidyResolution: boolean,
    deliveryDocument: boolean
}