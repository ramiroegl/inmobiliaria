import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {CreateSale} from '../../models/create-sale';
import {SaleService} from '../../services/sale.service';
import {CivilStatuses} from '../../../shared/resources/civil-statuses';
import {IdentityTypes} from '../../../shared/resources/identification-types';
import {CustomerService} from "../../../customers/services/customer.service";
import {PropertyService} from "../../../properties/services/property.service";

@Component({
    selector: 'app-new-sale',
    standalone: true,
    imports: [ReactiveFormsModule],
    templateUrl: './new-sale.component.html',
    styleUrl: './new-sale.component.css'
})
export class NewSaleComponent implements OnInit {
    identificationTypes = IdentityTypes;
    civilStatuses = CivilStatuses;
    form: FormGroup | undefined;

    constructor(private saleService: SaleService, private customerService: CustomerService, private propertyService: PropertyService) {
    }

    ngOnInit(): void {
        this.form = new FormGroup({
            propertyTuition: new FormControl(null, [Validators.required]),
            propertyPrice: new FormControl(0),
            propertyCoordinatesNorth: new FormControl(''),
            propertyCoordinatesSouth: new FormControl(''),
            propertyCoordinatesEast: new FormControl(''),
            propertyCoordinatesWest: new FormControl(''),
            propertyBlock: new FormControl(''),
            propertyLot: new FormControl(''),
            customerIdentityType: new FormControl(''),
            customerIdentityValue: new FormControl(''),
            customerIdentityExpedition: new FormControl(''),
            customerNames: new FormControl(''),
            customerLastNames: new FormControl(''),
            customerSalary: new FormControl(0),
            customerPhoneNumber: new FormControl(''),
            customerEmail: new FormControl(''),
            customerCivilStatus: new FormControl(''),
            financialPrice: new FormControl(0),
            financialValueToSetAside: new FormControl(0),
            financialOtherPayments: new FormControl(0),
            financialCompensationFundSubsidy: new FormControl(0),
            financialMinistryOfHousingSubsidy: new FormControl(0),
            financialLoanValue: new FormControl(0),
            financialLoanEntity: new FormControl(''),
            financialDebt: new FormControl(0),
            documentaryIdentificationDocument: new FormControl(false),
            documentarySignedPledge: new FormControl(false),
            documentaryCreditApprovalLetter: new FormControl(false),
            documentaryApprovalLetterNumber: new FormControl(''),
            documentaryCompensationFundRecordNumber: new FormControl(''),
            documentaryMinistrySubsidyResolution: new FormControl(false),
            documentaryDeliveryDocument: new FormControl(false),
            appraisalPayment: new FormControl(false),
            appraisalRequestSubmissionOfDocuments: new FormControl(false),
            appraisalVisit: new FormControl(false),
            appraisalReport: new FormControl(false),
            appraisalIssuanceByTheBankOfALetterOfRatification: new FormControl(false),
            appraisalTitleStudyPayment: new FormControl(false),
            appraisalSendingDocumentsForTitleStudy: new FormControl(false),
            appraisalFamilyCodeInMinistryOfHousing: new FormControl(''),
            deedConstructionCompanySignature: new FormControl(false),
            deedCustomerSignature: new FormControl(false),
            deedPropertySellerSignature: new FormControl<boolean>(false),
            deedBankSignature: new FormControl<boolean>(false),
            deedCopiesAndSettlement: new FormControl<boolean>(false),
            deedEntryDateIntoPublicInstruments: new FormControl(new Date()),
            deedCostsDeedCosts: new FormControl(0),
            deedCostsNotaryPayment: new FormControl(0),
            deedCostsPropertyPayment: new FormControl(0),
            deedCostsGovernmentPayment: new FormControl(0),
            deedCostsPublicInstrumentsPayment: new FormControl(0),
            deedCostsDeedDebt: new FormControl(0),
            deliveryScannedDeliveryCertificate: new FormControl(false),
            deliveryScannedTaxAndRegistrationSlip: new FormControl(false),
            deliveryScannedDeed: new FormControl(false),
            deliveryDisbursementInstruction: new FormControl(false),
            deliveryPeaceAndSafetyPropertySeller: new FormControl(false),
            deliveryScannedCTL: new FormControl(false),
            deliveryDeedSentToLawyer: new FormControl(false),
            subsidyDialedMinistryCollection: new FormControl(false),
            subsidyMinistryPayment: new FormControl(false),
            subsidyCompensationBoxSubsidyFiled: new FormControl(false),
            subsidyCompensationCashPayment: new FormControl(false),
            subsidyLoanDisbursementDate: new FormControl(new Date()),
            servicesElectricMeterValue: new FormControl(0),
            servicesInstalledElectricMeter: new FormControl(false),
            servicesInstalledWaterMeter: new FormControl(false),
            visitVisit: new FormControl(false),
            visitCertified: new FormControl(false),
            visitSentAfiniaDocuments: new FormControl(false)
        });
    }

    save(): void {
        if (this.form!.invalid) {
            alert("Revisa los datos del formulario");
            return;
        }
        const formValue = this.form!.value;
        let sale: CreateSale = {
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

        console.log(formValue);
        console.log(sale);

        this.saleService
            .createSale(sale)
            .subscribe(_ => {
                this.refresh();
            });
    }

    refresh(): void {
        this.form!.reset();
        this.ngOnInit();
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
}
