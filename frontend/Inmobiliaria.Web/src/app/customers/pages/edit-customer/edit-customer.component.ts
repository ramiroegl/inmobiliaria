import { Component, Input, OnInit } from '@angular/core';
import { Customer } from '../../../shared/models/Customer';
import { Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-edit-customer',
  standalone: true,
  imports: [],
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent implements OnInit {
  constructor(private customerService: CustomerService) {
  }
  ngOnInit(): void {
    this.customerService.getCustomer("a044746a-d493-4ef6-832e-a85f05cd41c9").subscribe(result => console.log(result));
  }
}
