import {Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {Property} from "../../shared/models/property";
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class PropertyService {
    apiUrl: string = environment.API_URL;
    constructor(private http: HttpClient) {
    }

    getPropertyByTuition(tuition: string): Observable<Property> {
        return this.http.get<Property>(`${this.apiUrl}/properties/get-by-tuition`, {
            params: {tuition}
        });
    }
}
