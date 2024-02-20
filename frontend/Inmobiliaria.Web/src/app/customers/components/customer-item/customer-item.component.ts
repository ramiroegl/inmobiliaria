import { Component, Input } from '@angular/core';
import { Customer } from '../../../shared/models/Customer.ts';

@Component({
  selector: 'app-customer-item',
  standalone: true,
  imports: [],
  templateUrl: './customer-item.component.html',
  styleUrl: './customer-item.component.css'
})
export class CustomerItemComponent {
  @Input() customer!: Customer;
}
