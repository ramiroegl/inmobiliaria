import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../../shared/models/Customer';
import { CreationResult } from "../../shared/models/CreationResult";
import { Observable } from 'rxjs';
import { Result } from '../../shared/models/Result';
import { CreateCustomer } from '../../shared/models/CreateCustomer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  apiUrl: string = 'https://oezz-inmobiliaria.azurewebsites.net';

  constructor(private http: HttpClient) { }

  getCustomers(search: string, skip: number, take: number): Observable<Result<Customer>> {
    return this.http.get<Result<Customer>>(`${this.apiUrl}/customers`, {
      params: { search, skip, take }
    });
  }

  createCustomer(customer: CreateCustomer): Observable<CreationResult> {
    return this.http.post<CreationResult>(`${this.apiUrl}/customers`, customer)
  }

  getCustomer(id: string): Observable<Result<Customer>> {
    return this.http.get<Result<Customer>>(`https://localhost:7232/customers/${id}`);
  }
}
