import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../../shared/models/Customer';
import { CreatedResult } from "../../shared/models/CreatedResult";
import { Observable } from 'rxjs';
import { Result } from '../../shared/models/Result';
import { CreateCustomer } from '../../shared/models/CreateCustomer';
import { environment } from '../../../environments/environment';
import { UpdatedResult } from '../../shared/models/UpdatedResult';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl: string = 'https://oezz-inmobiliaria.azurewebsites.net';

  constructor(private http: HttpClient) { }

  getCustomers(search: string, skip: number, take: number): Observable<Result<Customer>> {
    return this.http.get<Result<Customer>>(`${environment.apiUrl}/customers`, {
      params: { search, skip, take }
    });
  }

  createCustomer(customer: CreateCustomer): Observable<CreatedResult> {
    return this.http.post<CreatedResult>(`${environment.apiUrl}/customers`, customer)
  }

  getCustomer(id: string): Observable<Customer> {
    return this.http.get<Customer>(`${environment.apiUrl}/customers/${id}`);
  }

  updateConsumer(customer: Customer) : Observable<UpdatedResult> {
    return this.http.put<UpdatedResult>(`${environment.apiUrl}/customers/${customer.id}`, customer);
  }
}
