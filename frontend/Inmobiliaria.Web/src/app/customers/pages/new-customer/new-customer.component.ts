import { Component } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { CreateCustomer } from '../../models/create-customer';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { IdentityTypes } from '../../../shared/resources/identification-types';
import { CivilStatuses } from '../../../shared/resources/civil-statuses';

@Component({
  selector: 'app-new-customer',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-customer.component.html',
  styleUrl: './new-customer.component.css'
})
export class NewCustomerComponent {
  identityTypes = IdentityTypes;
  civilStatuses = CivilStatuses;
  form = new FormGroup({
    email: new FormControl(''),
    names: new FormControl(''),
    lastNames: new FormControl(''),
    civilStatus: new FormControl(''),
    identityValue: new FormControl(''),
    identityType: new FormControl(''),
    identityDateOfIssue: new FormControl<Date>(new Date()),
    salary: new FormControl<number>(0),
    phoneNumber: new FormControl(''),
  });

  constructor(private customerService: CustomerService) { }

  save(): void {
    const formValue = this.form.value;

    let customer: CreateCustomer = {
      email: formValue.email!,
      names: formValue.names!,
      lastNames: formValue.lastNames!,
      civilStatus: formValue.civilStatus!,
      phoneNumber: formValue.phoneNumber!,
      identity: { value: formValue.identityValue!, type: formValue.identityType!, dateOfIssue: formValue.identityDateOfIssue! },
      salary: formValue.salary!
    };

    this.customerService.createCustomer(customer).subscribe(result => {
      alert(result.id);
      this.refresh();
    })
  }

  refresh(): void {
    this.form.reset();
  }
}
