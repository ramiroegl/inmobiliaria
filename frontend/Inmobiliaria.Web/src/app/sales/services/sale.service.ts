import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatedResult, DeletedResult } from '../../shared/models/results';
import { ListedSale, ListedSales } from '../models/listed-sales';
import { CreateSale } from '../models/create-sale';
import { UpdatedResult } from '../../shared/models/updatedResult';
import { UpdateSale } from '../models/update-sale';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  apiUrl: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  getSale(id: string): Observable<ListedSale> {
    return this.http.get<ListedSale>(`${this.apiUrl}/sales/${id}`);
  }

  getSales(skip: number, take: number): Observable<ListedSales> {
    return this.http.get<ListedSales>(`${this.apiUrl}/sales`, {
      params: { skip, take }
    })
  }

  createSale(sale: CreateSale): Observable<CreatedResult> {
    return this.http.post<CreatedResult>(`${this.apiUrl}/sales`, sale);
  }

  updateSale(id: string, sale: UpdateSale): Observable<UpdatedResult> {
    return this.http.put<UpdatedResult>(`${this.apiUrl}/sales/${id}`, sale);
  }

  deleteSale(id: string): Observable<DeletedResult> {
    return this.http.delete<DeletedResult>(`${this.apiUrl}/sales/${id}`);
  }
}
