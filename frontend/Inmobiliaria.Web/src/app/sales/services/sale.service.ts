import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatedResult, DeletedResult } from '../../shared/models/results';
import { ListedSales } from '../models/listed-sales';
import { CreateSale } from '../models/create-sale';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  apiUrl: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  getSales(skip: number, take: number): Observable<ListedSales> {
    return this.http.get<ListedSales>(`${this.apiUrl}/sales`, {
      params: { skip, take }
    })
  }

  createSale(sale: CreateSale): Observable<CreatedResult> {
    return this.http.post<CreatedResult>(`${this.apiUrl}/sales`, sale);
  }

  deleteSale(id: string): Observable<DeletedResult> {
    return this.http.delete<DeletedResult>(`${this.apiUrl}/sales/${id}`);
  }
}
