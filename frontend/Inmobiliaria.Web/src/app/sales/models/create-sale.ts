import { Coordinates } from "../../shared/models/coordinates";
import { Identity } from "../../shared/models/identity";

export interface CreateSale {
    customer: CreateSaleCustomer,
    property: CreateSaleProperty,
    financialData: CreateFinancialData,
    documentaryData: CreateDocumentaryData,
    appraisalData: CreateAppraisalData,
    deedData: CreateDeedData,
}

export interface CreateSaleCustomer {
    names: string,
    lastNames: string,
    email: string,
    identity: Identity,
    salary: number,
    civilStatus: string,
    phoneNumber: string
}

export interface CreateSaleProperty {
    price: number,
    coordinates: Coordinates,
    tuition: string,
    block: string,
    lot: string
}

export interface CreateFinancialData {
    price: number,
    valueToSetAside: number,
    otherPayments: number,
    compensationFundSubsidy: number,
    ministryOfHousingSubsidy: number,
    loanValue: number,
    loanEntity: string,
    debt: number
}

export interface CreateDocumentaryData {
    identificationDocument: boolean,
    signedPledge: boolean,
    creditApprovalLetter: boolean,
    approvalLetterNumber: string,
    compensationFundRecordNumber: string,
    ministrySubsidyResolution: boolean,
    deliveryDocument: boolean
}

export interface CreateDeedData {
    constructionCompanySignature: boolean,
    customerSignature: boolean,
    propertySellerSignature: boolean,
    copiesAndSettlement: boolean,
    entryDateIntoPublicInstruments: Date
}

export interface CreateAppraisalData {
    payment: boolean
    requestSubmissionOfDocuments: boolean
    visit: boolean
    report: boolean
    issuanceByTheBankOfALetterOfRatification: boolean
    titleStudyPayment: boolean
    sendingDocumentsForTitleStudy: boolean
    familyCodeInMinistryOfHousing: string
}