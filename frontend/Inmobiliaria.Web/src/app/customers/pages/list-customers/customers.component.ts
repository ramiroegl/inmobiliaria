import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../../shared/models/customer';
import { LoginResult } from '../../../login/models/login-result';
import { LoginService } from '../../../login/services/login.service';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {
  public search: string = '';
  public take: number = 10;
  public skip: number = 0;
  public customers: Customer[] = [];
  public hasError: boolean = false;
  public errorMessage?: string;
  public session: LoginResult | null = null;

  constructor(private customerService: CustomerService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.customerService
      .getCustomers(this.search, this.skip, this.take)
      .subscribe(result => {
        this.customers = result.data;
      });

    this.session = this.loginService
      .getSession();
  }

  delete(id: string) {
    this.customerService
      .deleteConsumer(id)
      .subscribe(result => {
        if (result.ok) {
          this.customers = this.customers.filter(customer => customer.id != id);
        } else {
          this.hasError = true;
          this.errorMessage = result.error;
        }
      });
  }
}
