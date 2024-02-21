import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CreateSale } from '../../models/create-sale';
import { SaleService } from '../../services/sale.service';
import { CivilStatuses } from '../../../shared/resources/civil-statuses';
import { IdentityTypes } from '../../../shared/resources/identification-types';

@Component({
  selector: 'app-new-sale',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-sale.component.html',
  styleUrl: './new-sale.component.css'
})
export class NewSaleComponent {
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
  });

  constructor(private saleService: SaleService) { }

  save(): void {
    const formValue = this.form.value;
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
        approvalLetterNumber: true,
        compensationFundRecordNumber: true,
        creditApprovalLetter: true,
        deliveryDocument: true,
        identificationDocument: true,
        ministrySubsidyResolution: true,
        signedPledge: true
      },
    };

    this.saleService
      .createSale(sale)
      .subscribe(result => {
        console.log(result.id)
        this.refresh();
      })
  }

  refresh(): void {
    this.form.reset();
  }
}
