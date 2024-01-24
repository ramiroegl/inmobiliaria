import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

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
  form = new FormGroup({
    email: new FormControl(''),
    names: new FormControl(''),
    lastNames: new FormControl(''),
    civilStatus: new FormControl(''),
    identityValue: new FormControl(''),
    identityType: new FormControl(''),
    identityDateOfIssue: new FormControl(''),
    salary: new FormControl<number>(0),
    phoneNumber: new FormControl(''),
  });
  
  constructor(private customerService: CustomerService) {
  }

  ngOnInit(): void {
    console.log(this.id);
    this.customerService.getCustomer(this.id).subscribe(result => {
      console.log(result);
      this.form.setValue({
        email: result.email,
        civilStatus: result.civilStatus,
        identityDateOfIssue: result.identity.dateOfIssue,
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
      identity: {dateOfIssue: formValue.identityDateOfIssue!, type: formValue.identityType!, value: formValue.identityValue!},
      lastNames: formValue.lastNames!,
      names: formValue.names!,
      phoneNumber: formValue.phoneNumber!,
      salary: formValue.salary!
    }).subscribe(_ => {
      this.updated = true;
    });
  }
}
