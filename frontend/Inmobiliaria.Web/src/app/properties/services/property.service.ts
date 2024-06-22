import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { Property } from "../../shared/models/property";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { DeletedResult, PaginatedResult } from '../../shared/models/results';

@Injectable({
    providedIn: 'root'
})
export class PropertyService {
    apiUrl: string = environment.API_URL;
    constructor(private http: HttpClient) {
    }

    getPropertyByTuition(tuition: string): Observable<Property> {
        return this.http.get<Property>(`${this.apiUrl}/properties/get-by-tuition`, {
            params: { tuition }
        });
    }

    getPaginated(search: string, skip: number, take: number): Observable<PaginatedResult<Property>> {
        return this.http.get<PaginatedResult<Property>>(`${this.apiUrl}/properties`, {
            params: { search, skip, take }
        })
    }

    delete(id: string): Observable<DeletedResult> {
        return this.http.delete<DeletedResult>(`${this.apiUrl}/properties/${id}`);
    }
}
