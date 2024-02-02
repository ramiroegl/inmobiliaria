import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Customer } from '../../../shared/models/Customer';
import { CustomerItemComponent } from '../../components/customer-item/customer-item.component';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CustomerItemComponent, RouterLink],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {
  public search: string = '';
  public take: number = 10;
  public skip: number = 0;
  public customers: Customer[] = [];

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.customerService.getCustomers(this.search, this.skip, this.take).subscribe(result => {
      this.customers = result.data;
    });
  }

  delete(id: string) {
    this.customerService.deleteConsumer(id).subscribe(_ => {
      this.customers = this.customers.filter(customer => customer.id != id);
    });
  }
}
