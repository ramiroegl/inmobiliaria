import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { IdentityTypes } from '../../../shared/resources/identification-types';
import { CivilStatuses } from '../../../shared/resources/civil-statuses';

@Component({
  selector: 'app-edit-customer',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent implements OnInit {
  @Input('id') id: string = '';
  updated: boolean = false;
  identityTypes = IdentityTypes;
  civilStatuses = CivilStatuses;
  form = new FormGroup({
    email: new FormControl<string>(''),
    names: new FormControl<string>(''),
    lastNames: new FormControl<string>(''),
    civilStatus: new FormControl<string>(''),
    identityValue: new FormControl<string>(''),
    identityType: new FormControl<string>(''),
    identityExpedition: new FormControl(''),
    salary: new FormControl<number>(0),
    phoneNumber: new FormControl(''),
  });

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    console.log(this.id);
    this.customerService
      .getCustomer(this.id)
      .subscribe(result => {
        this.form.setValue({
          email: result.email,
          civilStatus: result.civilStatus,
          identityExpedition: result.identity.expedition,
          identityType: result.identity.type,
          identityValue: result.identity.value,
          lastNames: result.lastNames,
          names: result.names,
          phoneNumber: result.phoneNumber,
          salary: result.salary
        });
      });
  }

  update(): void {
    let formValue = this.form.value;
    this.customerService.updateConsumer({
      id: this.id,
      email: formValue.email!,
      civilStatus: formValue.civilStatus!,
      identity: { expedition: formValue.identityExpedition!, type: formValue.identityType!, value: formValue.identityValue! },
      lastNames: formValue.lastNames!,
      names: formValue.names!,
      phoneNumber: formValue.phoneNumber!,
      salary: formValue.salary!
    }).subscribe(_ => {
      this.updated = true;
    });
  }
}
