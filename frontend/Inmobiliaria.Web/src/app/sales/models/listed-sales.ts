import { Coordinates } from "../../shared/models/coordinates";
import { Identity } from "../../shared/models/identity";
import { PaginatedResult } from "../../shared/models/results";

export interface ListedSales extends PaginatedResult<ListedSale> { }

export interface ListedSale {
    id: string;
    customer: ListedSaleCustomer;
    property: ListedSaleProperty;
    financialData: ListedSaleFinancialData;
    documentaryData: ListedSaleDocumentaryData;
    appraisalData: ListedSaleAppraisalData;
    deedData: ListedSaleDeedData;
    deedCostsData: ListedSaleDeedCostData;
    deliveryData: ListedSaleDeliveryData;
    subsidyData: ListedSaleSubsidyData;
    servicesData: ListedSaleServicesData;
    visitData: ListedSaleVisitData;
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
    loanEntity: string;
    debt: number;
}

export interface ListedSaleDocumentaryData {
    identificationDocument: boolean;
    signedPledge: boolean;
    creditApprovalLetter: boolean;
    approvalLetterNumber: string;
    compensationFundRecordNumber: string;
    ministrySubsidyResolution: boolean;
    deliveryDocument: boolean;
}

export interface ListedSaleAppraisalData {
    payment: boolean;
    requestSubmissionOfDocuments: boolean;
    visit: boolean;
    report: boolean;
    issuanceByTheBankOfALetterOfRatification: boolean;
    titleStudyPayment: boolean;
    sendingDocumentsForTitleStudy: boolean;
    familyCodeInMinistryOfHousing: string;
}

export interface ListedSaleDeedData {
    constructionCompanySignature: boolean;
    customerSignature: boolean;
    propertySellerSignature: boolean;
    copiesAndSettlement: boolean;
    bankSignature: boolean;
    entryDateIntoPublicInstruments: Date;
}

export interface ListedSaleDeedCostData {
    deedCosts: number;
    notaryPayment: number;
    propertyPayment: number;
    governmentPayment: number;
    publicInstrumentsPayment: number;
    deedDebt: number;
}

export interface ListedSaleDeliveryData {
    scannedDeliveryCertificate: boolean;
    scannedTaxAndRegistrationSlip: boolean;
    scannedDeed: boolean;
    disbursementInstruction: boolean;
    peaceAndSafetyPropertySeller: boolean;
    scannedCTL: boolean;
    deedSentToLawyer: boolean;
}

export interface ListedSaleSubsidyData {
    dialedMinistryCollection: boolean;
    ministryPayment: boolean;
    compensationBoxSubsidyFiled: boolean;
    compensationCashPayment: boolean;
    loanDisbursementDate: Date;
}

export interface ListedSaleServicesData {
    electricMeterValue: number;
    installedElectricMeter: boolean;
    installedWaterMeter: boolean;
}

export interface ListedSaleVisitData {
    visit: boolean;
    certified: boolean;
    sentAfiniaDocuments: boolean;
}
