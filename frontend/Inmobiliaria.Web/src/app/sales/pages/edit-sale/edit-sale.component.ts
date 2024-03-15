import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { IdentityTypes } from '../../../shared/resources/identification-types';
import { CivilStatuses } from '../../../shared/resources/civil-statuses';
import { SaleService } from '../../services/sale.service';
import { UpdateSale } from '../../models/update-sale';

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
  form = new FormGroup({
    propertyTuition: new FormControl(''),
    propertyPrice: new FormControl(0),
    propertyCoordinatesNorth: new FormControl(''),
    propertyCoordinatesSouth: new FormControl(''),
    propertyCoordinatesEast: new FormControl(''),
    propertyCoordinatesWest: new FormControl(''),
    propertyBlock: new FormControl(''),
    propertyLot: new FormControl(''),
    customerIdentityType: new FormControl(''),
    customerIdentityValue: new FormControl(''),
    customerIdentityDateofissue: new FormControl(new Date()),
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
    deedPropertySellerSignature: new FormControl(false),
    deedBankSignature: new FormControl(false),
    deedCopiesAndSettlement: new FormControl(false),
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

  constructor(private saleService: SaleService) { }

  ngOnInit(): void {
    this.saleService
      .getSales
  }

  update(): void {
    let formValue = this.form.value;
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
          dateOfIssue: formValue.customerIdentityDateofissue!,
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
      .updateSale(sale)
      .subscribe(_ => {
        this.updated = true;
      });
  }
}
