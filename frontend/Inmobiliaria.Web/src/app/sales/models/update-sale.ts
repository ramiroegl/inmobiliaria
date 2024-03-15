import { Coordinates } from "../../shared/models/coordinates";
import { Identity } from "../../shared/models/identity";

export interface UpdateSale {
    id: string,
    customer: UpdateSaleCustomer,
    property: UpdateSaleProperty,
    financialData: UpdateFinancialData,
    documentaryData: UpdateDocumentaryData,
    appraisalData: UpdateAppraisalData,
    deedData: UpdateDeedData,
    deedCostsData: UpdateDeedCostsData,
    deliveryData: UpdateDeliveryData,
    subsidyData: UpdateSubsidyData,
    servicesData: UpdateServicesData,
    visitData: UpdateVisitData
}

export interface UpdateSaleCustomer {
    names: string,
    lastNames: string,
    email: string,
    identity: Identity,
    salary: number,
    civilStatus: string,
    phoneNumber: string
}

export interface UpdateSaleProperty {
    price: number,
    coordinates: Coordinates,
    tuition: string,
    block: string,
    lot: string
}

export interface UpdateFinancialData {
    price: number,
    valueToSetAside: number,
    otherPayments: number,
    compensationFundSubsidy: number,
    ministryOfHousingSubsidy: number,
    loanValue: number,
    loanEntity: string,
    debt: number
}

export interface UpdateDocumentaryData {
    identificationDocument: boolean,
    signedPledge: boolean,
    creditApprovalLetter: boolean,
    approvalLetterNumber: string,
    compensationFundRecordNumber: string,
    ministrySubsidyResolution: boolean,
    deliveryDocument: boolean
}

export interface UpdateAppraisalData {
    payment: boolean
    requestSubmissionOfDocuments: boolean
    visit: boolean
    report: boolean
    issuanceByTheBankOfALetterOfRatification: boolean
    titleStudyPayment: boolean
    sendingDocumentsForTitleStudy: boolean
    familyCodeInMinistryOfHousing: string
}

export interface UpdateDeedData {
    constructionCompanySignature: boolean,
    customerSignature: boolean,
    propertySellerSignature: boolean,
    bankSignature: boolean,
    copiesAndSettlement: boolean,
    entryDateIntoPublicInstruments: Date
}

export interface UpdateDeedCostsData {
    deedCosts: number,
    notaryPayment: number,
    propertyPayment: number,
    governmentPayment: number,
    publicInstrumentsPayment: number,
    deedDebt: number
}

export interface UpdateDeliveryData {
    scannedDeliveryCertificate: boolean,
    scannedTaxAndRegistrationSlip: boolean,
    scannedDeed: boolean,
    disbursementInstruction: boolean,
    peaceAndSafetyPropertySeller: boolean,
    scannedCTL: boolean,
    deedSentToLawyer: boolean
}

export interface UpdateSubsidyData {
    dialedMinistryCollection: boolean,
    ministryPayment: boolean,
    compensationBoxSubsidyFiled: boolean,
    compensationCashPayment: boolean,
    loanDisbursementDate: Date
}

export interface UpdateServicesData {
    electricMeterValue: number,
    installedElectricMeter: boolean,
    installedWaterMeter: boolean
}

export interface UpdateVisitData {
    visit: boolean,
    certified: boolean,
    sentAfiniaDocuments: boolean
}