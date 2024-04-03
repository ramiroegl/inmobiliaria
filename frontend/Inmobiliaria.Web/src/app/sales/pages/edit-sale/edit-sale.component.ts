import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {RouterLink} from '@angular/router';
import {IdentityTypes} from '../../../shared/resources/identification-types';
import {CivilStatuses} from '../../../shared/resources/civil-statuses';
import {SaleService} from '../../services/sale.service';
import {UpdateSale} from '../../models/update-sale';
import {ListedSale} from "../../models/listed-sales";
import {PropertyService} from "../../../properties/services/property.service";
import {CustomerService} from "../../../customers/services/customer.service";

@Component({
    selector: 'app-edit-sale',
    standalone: true,
    imports: [ReactiveFormsModule, RouterLink],
    templateUrl: './edit-sale.component.html',
    styleUrl: './edit-sale.component.css'
})
export class EditSaleComponent implements OnInit {
    @Input('id') id: string = '';
    updated: boolean = false;
    identificationTypes = IdentityTypes;
    civilStatuses = CivilStatuses;
    form: FormGroup = new FormGroup({});

    constructor(private saleService: SaleService, private propertyService: PropertyService, private customerService: CustomerService) {
        this.setData();
    }

    ngOnInit(): void {
        this.saleService
            .getSale(this.id)
            .subscribe((result: ListedSale): void => {
                console.log(result);
                this.setData(result);
            })
    }

    loadProperty(): void {
        const formValue = this.form!.value;
        this.propertyService
            .getPropertyByTuition(formValue.propertyTuition)
            .subscribe(property => {
                this.form?.patchValue({
                    propertyTuition: property.tuition,
                    propertyPrice: property.price,
                    propertyCoordinatesNorth: property.coordinates.north,
                    propertyCoordinatesSouth: property.coordinates.south,
                    propertyCoordinatesEast: property.coordinates.east,
                    propertyCoordinatesWest: property.coordinates.west,
                    propertyBlock: property.block,
                    propertyLot: property.lot,
                })
            });
    }

    loadCustomer(): void {
        const formValue = this.form!.value;
        this.customerService
            .getCustomerByIdentity(formValue.customerIdentityType, formValue.customerIdentityValue)
            .subscribe(customer => {
                this.form?.patchValue({
                    customerIdentityType: customer.identity.type,
                    customerIdentityValue: customer.identity.value,
                    customerIdentityExpedition: customer.identity.expedition,
                    customerNames: customer.names,
                    customerLastNames: customer.lastNames,
                    customerSalary: customer.salary,
                    customerPhoneNumber: customer.phoneNumber,
                    customerEmail: customer.email,
                    customerCivilStatus: customer.civilStatus,
                })
            });
    }

    setData(sale: ListedSale | null = null): void {
        this.form = new FormGroup({
            // Property
            propertyTuition: new FormControl<string>(sale?.property?.tuition ?? "", [Validators.required]),
            propertyPrice: new FormControl<number>(sale?.property?.price ?? 0),
            propertyBlock: new FormControl<string>(sale?.property?.block ?? ""),
            propertyLot: new FormControl<string>(sale?.property?.lot ?? ""),
            propertyCoordinatesNorth: new FormControl<string>(sale?.property?.coordinates?.north ?? ""),
            propertyCoordinatesSouth: new FormControl<string>(sale?.property?.coordinates?.south ?? ""),
            propertyCoordinatesEast: new FormControl<string>(sale?.property?.coordinates?.east ?? ""),
            propertyCoordinatesWest: new FormControl<string>(sale?.property?.coordinates?.west ?? ""),
            // Customer
            customerIdentityType: new FormControl<string>(sale?.customer?.identity?.type  ?? ""),
            customerIdentityValue: new FormControl<string>(sale?.customer?.identity.value  ?? ""),
            customerIdentityExpedition: new FormControl<string>(sale?.customer?.identity?.expedition ?? ""),
            customerNames: new FormControl<string>(sale?.customer?.names ?? ""),
            customerLastNames: new FormControl<string>(sale?.customer?.lastNames ?? ""),
            customerSalary: new FormControl<number>(sale?.customer?.salary ?? 0),
            customerPhoneNumber: new FormControl<string>(sale?.customer?.phoneNumber ?? ""),
            customerEmail: new FormControl<string>(sale?.customer?.email ?? ""),
            customerCivilStatus: new FormControl<string>(sale?.customer?.civilStatus ?? ""),
            // Financial
            financialPrice: new FormControl<number>(sale?.financialData?.price ?? 0),
            financialValueToSetAside: new FormControl<number>(sale?.financialData?.valueToSetAside ?? 0),
            financialOtherPayments: new FormControl<number>(sale?.financialData?.otherPayments ?? 0),
            financialCompensationFundSubsidy: new FormControl<number>(sale?.financialData?.compensationFundSubsidy ?? 0),
            financialMinistryOfHousingSubsidy: new FormControl<number>(sale?.financialData?.ministryOfHousingSubsidy ?? 0),
            financialLoanValue: new FormControl<number>(sale?.financialData?.loanValue ?? 0),
            financialLoanEntity: new FormControl<string>(sale?.financialData?.loanEntity ?? ""),
            financialDebt: new FormControl<number>(sale?.financialData?.debt ?? 0),
            // Documentary
            documentaryIdentificationDocument: new FormControl<boolean>(sale?.documentaryData?.identificationDocument ?? false),
            documentarySignedPledge: new FormControl<boolean>(sale?.documentaryData?.signedPledge ?? false),
            documentaryCreditApprovalLetter: new FormControl<boolean>(sale?.documentaryData?.creditApprovalLetter ?? false),
            documentaryApprovalLetterNumber: new FormControl<string>(sale?.documentaryData?.approvalLetterNumber ?? ""),
            documentaryCompensationFundRecordNumber: new FormControl<string>(sale?.documentaryData?.compensationFundRecordNumber ?? ""),
            documentaryMinistrySubsidyResolution: new FormControl<boolean>(sale?.documentaryData?.ministrySubsidyResolution ?? false),
            documentaryDeliveryDocument: new FormControl<boolean>(sale?.documentaryData?.deliveryDocument ?? false),
            // Appraisal
            appraisalPayment: new FormControl<boolean>(sale?.appraisalData?.payment ?? false),
            appraisalRequestSubmissionOfDocuments: new FormControl<boolean>(sale?.appraisalData?.requestSubmissionOfDocuments ?? false),
            appraisalVisit: new FormControl<boolean>(sale?.appraisalData?.visit ?? false),
            appraisalReport: new FormControl<boolean>(sale?.appraisalData?.report ?? false),
            appraisalIssuanceByTheBankOfALetterOfRatification: new FormControl<boolean>(sale?.appraisalData?.issuanceByTheBankOfALetterOfRatification ?? false),
            appraisalTitleStudyPayment: new FormControl<boolean>(sale?.appraisalData?.titleStudyPayment ?? false),
            appraisalSendingDocumentsForTitleStudy: new FormControl<boolean>(sale?.appraisalData?.sendingDocumentsForTitleStudy ?? false),
            appraisalFamilyCodeInMinistryOfHousing: new FormControl<string>(sale?.appraisalData?.familyCodeInMinistryOfHousing ?? ""),
            // Deed
            deedConstructionCompanySignature: new FormControl<boolean>(sale?.deedData?.constructionCompanySignature ?? false),
            deedCustomerSignature: new FormControl<boolean>(sale?.deedData?.customerSignature ?? false),
            deedPropertySellerSignature: new FormControl<boolean>(sale?.deedData?.propertySellerSignature ?? false),
            deedBankSignature: new FormControl<boolean>(sale?.deedData?.bankSignature ?? false),
            deedCopiesAndSettlement: new FormControl<boolean>(sale?.deedData?.copiesAndSettlement ?? false),
            deedEntryDateIntoPublicInstruments: new FormControl<Date>(sale?.deedData?.entryDateIntoPublicInstruments ?? new Date()),
            // Deed Costs
            deedCostsDeedCosts: new FormControl<number>(sale?.deedCostsData?.deedCosts ?? 0),
            deedCostsNotaryPayment: new FormControl<number>(sale?.deedCostsData?.notaryPayment ?? 0),
            deedCostsPropertyPayment: new FormControl<number>(sale?.deedCostsData?.propertyPayment ?? 0),
            deedCostsGovernmentPayment: new FormControl<number>(sale?.deedCostsData?.governmentPayment ?? 0),
            deedCostsPublicInstrumentsPayment: new FormControl<number>(sale?.deedCostsData?.publicInstrumentsPayment ?? 0),
            deedCostsDeedDebt: new FormControl<number>(sale?.deedCostsData?.deedDebt ?? 0),
            // Delivery
            deliveryScannedDeliveryCertificate: new FormControl<boolean>(sale?.deliveryData?.scannedDeliveryCertificate ?? false),
            deliveryScannedTaxAndRegistrationSlip: new FormControl<boolean>(sale?.deliveryData?.scannedTaxAndRegistrationSlip ?? false),
            deliveryScannedDeed: new FormControl(sale?.deliveryData?.scannedDeed),
            deliveryDisbursementInstruction: new FormControl<boolean>(sale?.deliveryData?.disbursementInstruction ?? false),
            deliveryPeaceAndSafetyPropertySeller: new FormControl<boolean>(sale?.deliveryData?.peaceAndSafetyPropertySeller ?? false),
            deliveryScannedCTL: new FormControl<boolean>(sale?.deliveryData?.scannedCTL ?? false),
            deliveryDeedSentToLawyer: new FormControl<boolean>(sale?.deliveryData?.deedSentToLawyer ?? false),
            // Subsidy
            subsidyDialedMinistryCollection: new FormControl<boolean>(sale?.subsidyData?.dialedMinistryCollection ?? false),
            subsidyMinistryPayment: new FormControl<boolean>(sale?.subsidyData?.ministryPayment ?? false),
            subsidyCompensationBoxSubsidyFiled: new FormControl<boolean>(sale?.subsidyData?.compensationBoxSubsidyFiled ?? false),
            subsidyCompensationCashPayment: new FormControl<boolean>(sale?.subsidyData?.compensationCashPayment ?? false),
            subsidyLoanDisbursementDate: new FormControl<Date>(sale?.subsidyData?.loanDisbursementDate ?? new Date()),
            // Services
            servicesElectricMeterValue: new FormControl<number>(sale?.servicesData?.electricMeterValue ?? 0),
            servicesInstalledElectricMeter: new FormControl<boolean>(sale?.servicesData?.installedElectricMeter ?? false),
            servicesInstalledWaterMeter: new FormControl<boolean>(sale?.servicesData?.installedWaterMeter ?? false),
            // Visit
            visitVisit: new FormControl<boolean>(sale?.visitData?.visit ?? false),
            visitCertified: new FormControl<boolean>(sale?.visitData?.certified ?? false),
            visitSentAfiniaDocuments: new FormControl<boolean>(sale?.visitData?.sentAfiniaDocuments ?? false)
        });
    }

    update(): void {
        let formValue = this.form!.value;
        let sale: UpdateSale = {
            id: this.id,
            property: {
                tuition: formValue.propertyTuition!,
                block: formValue.propertyBlock!,
                coordinates: {
                    north: formValue.propertyCoordinatesNorth!,
                    south: formValue.propertyCoordinatesSouth!,
                    east: formValue.propertyCoordinatesEast!,
                    west: formValue.propertyCoordinatesWest!
                },
                lot: formValue.propertyLot!,
                price: formValue.propertyPrice!
            },
            customer: {
                civilStatus: formValue.customerCivilStatus!,
                email: formValue.customerEmail!,
                identity: {
                    expedition: formValue.customerIdentityExpedition!,
                    type: formValue.customerIdentityType!,
                    value: formValue.customerIdentityValue!
                },
                lastNames: formValue.customerLastNames!,
                names: formValue.customerNames!,
                phoneNumber: formValue.customerPhoneNumber!,
                salary: formValue.customerSalary!
            },
            financialData: {
                price: formValue.financialPrice!,
                valueToSetAside: formValue.financialValueToSetAside!,
                otherPayments: formValue.financialOtherPayments!,
                compensationFundSubsidy: formValue.financialCompensationFundSubsidy!,
                ministryOfHousingSubsidy: formValue.financialMinistryOfHousingSubsidy!,
                loanValue: formValue.financialLoanValue!,
                loanEntity: formValue.financialLoanEntity!,
                debt: formValue.financialDebt!,
            },
            documentaryData: {
                approvalLetterNumber: formValue.documentaryApprovalLetterNumber!,
                compensationFundRecordNumber: formValue.documentaryCompensationFundRecordNumber!,
                creditApprovalLetter: formValue.documentaryCreditApprovalLetter!,
                deliveryDocument: formValue.documentaryDeliveryDocument!,
                identificationDocument: formValue.documentaryIdentificationDocument!,
                ministrySubsidyResolution: formValue.documentaryMinistrySubsidyResolution!,
                signedPledge: formValue.documentarySignedPledge!
            },
            appraisalData: {
                payment: formValue.appraisalPayment!,
                requestSubmissionOfDocuments: formValue.appraisalRequestSubmissionOfDocuments!,
                visit: formValue.visitCertified!,
                report: formValue.appraisalReport!,
                issuanceByTheBankOfALetterOfRatification: formValue.appraisalIssuanceByTheBankOfALetterOfRatification!,
                titleStudyPayment: formValue.appraisalTitleStudyPayment!,
                sendingDocumentsForTitleStudy: formValue.appraisalSendingDocumentsForTitleStudy!,
                familyCodeInMinistryOfHousing: formValue.appraisalFamilyCodeInMinistryOfHousing!
            },
            deedData: {
                constructionCompanySignature: formValue.deedConstructionCompanySignature!,
                customerSignature: formValue.deedCustomerSignature!,
                propertySellerSignature: formValue.deedPropertySellerSignature!,
                bankSignature: formValue.deedBankSignature!,
                copiesAndSettlement: formValue.deedCopiesAndSettlement!,
                entryDateIntoPublicInstruments: formValue.deedEntryDateIntoPublicInstruments!
            },
            deedCostsData: {
                deedCosts: formValue.deedCostsDeedCosts!,
                notaryPayment: formValue.deedCostsNotaryPayment!,
                propertyPayment: formValue.deedCostsPropertyPayment!,
                governmentPayment: formValue.deedCostsGovernmentPayment!,
                publicInstrumentsPayment: formValue.deedCostsPublicInstrumentsPayment!,
                deedDebt: formValue.deedCostsDeedDebt!
            },
            deliveryData: {
                scannedDeliveryCertificate: formValue.deliveryScannedDeliveryCertificate!,
                scannedTaxAndRegistrationSlip: formValue.deliveryScannedTaxAndRegistrationSlip!,
                scannedDeed: formValue.deliveryScannedDeed!,
                disbursementInstruction: formValue.deliveryDisbursementInstruction!,
                peaceAndSafetyPropertySeller: formValue.deliveryPeaceAndSafetyPropertySeller!,
                scannedCTL: formValue.deliveryScannedCTL!,
                deedSentToLawyer: formValue.deliveryDeedSentToLawyer!
            },
            subsidyData: {
                dialedMinistryCollection: formValue.subsidyDialedMinistryCollection!,
                ministryPayment: formValue.subsidyMinistryPayment!,
                compensationBoxSubsidyFiled: formValue.subsidyCompensationBoxSubsidyFiled!,
                compensationCashPayment: formValue.subsidyCompensationCashPayment!,
                loanDisbursementDate: formValue.subsidyLoanDisbursementDate!
            },
            servicesData: {
                electricMeterValue: formValue.servicesElectricMeterValue!,
                installedElectricMeter: formValue.servicesInstalledElectricMeter!,
                installedWaterMeter: formValue.servicesInstalledWaterMeter!
            },
            visitData: {
                visit: formValue.visitVisit!,
                certified: formValue.visitCertified!,
                sentAfiniaDocuments: formValue.visitSentAfiniaDocuments!,
            }
        };
        this.saleService
            .updateSale(sale.id, sale)
            .subscribe(_ => {
                this.updated = true;
            });
    }
}
