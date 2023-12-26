import { Component } from '@angular/core';
import { Customer } from '../../shared/models/customer';
import { CustomerItemComponent } from '../components/customer-item/customer-item.component';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CustomerItemComponent],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent {
  public customers: Customer[] = [{
    id: '1',
    cellphone: '213123',
    civilStatus: 'soltero',
    identification: '10231232',
    lastnames: 'Gonzalez',
    names: 'Ramiro',
    salary: 1200000
  }];
}
