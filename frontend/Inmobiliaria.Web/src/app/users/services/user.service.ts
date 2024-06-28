import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatedResult, DeletedResult } from '../../shared/models/results';
import { ListedUsers } from '../../shared/models/user';
import { createUser } from '../models/create-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  getUsers(skip: number, take: number): Observable<ListedUsers> {
    return this.http.get<ListedUsers>(`${this.apiUrl}/users`, {
      params: { skip, take }
    })
  }

  createUser(user: createUser): Observable<CreatedResult> {
    return this.http.post<CreatedResult>(`${this.apiUrl}/users`, user)
}

  deleteUser(id: string): Observable<DeletedResult> {
    return this.http.delete<DeletedResult>(`${this.apiUrl}/users/${id}`);
  }
}
