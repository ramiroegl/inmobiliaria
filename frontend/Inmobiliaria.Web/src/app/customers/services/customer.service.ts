import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Customer} from '../../shared/models/customer';
import {Observable} from 'rxjs';
import {CreateCustomer} from '../models/create-customer';
import {environment} from '../../../environments/environment';
import {UpdatedResult} from '../../shared/models/updatedResult';
import {CreatedResult, DeletedResult, PaginatedResult} from '../../shared/models/results';

@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    apiUrl: string = environment.API_URL;

    constructor(private http: HttpClient) {
    }

    getCustomers(search: string, skip: number, take: number): Observable<PaginatedResult<Customer>> {
        return this.http.get<PaginatedResult<Customer>>(`${this.apiUrl}/customers`, {
            params: {search, skip, take}
        });
    }

    createCustomer(customer: CreateCustomer): Observable<CreatedResult> {
        return this.http.post<CreatedResult>(`${this.apiUrl}/customers`, customer)
    }

    getCustomer(id: string): Observable<Customer> {
        return this.http.get<Customer>(`${this.apiUrl}/customers/${id}`);
    }

    updateConsumer(customer: Customer): Observable<UpdatedResult> {
        return this.http.put<UpdatedResult>(`${this.apiUrl}/customers/${customer.id}`, customer);
    }

    deleteConsumer(id: string): Observable<DeletedResult> {
        return this.http.delete<DeletedResult>(`${this.apiUrl}/customers/${id}`);
    }

    getCustomerByIdentity(identityType: string, identityValue: string): Observable<Customer> {
        return this.http.get<Customer>(`${this.apiUrl}/customers/get-by-identity`, {
            params: { identityType, identityValue }
        });
    }
}
