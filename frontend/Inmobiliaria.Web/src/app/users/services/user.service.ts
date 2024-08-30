import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatedResult, DeletedResult } from '../../shared/models/results';
import { ListedUsers, User } from '../../shared/models/user';
import { createUser } from '../models/create-user';
import { ChangePassword, ResetPassword, UpdateUser } from '../models/update-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  getUsers(skip: number, take: number): Observable<ListedUsers> {
    return this.http.get<ListedUsers>(`${this.apiUrl}/users`, {
      params: { skip, take }
    });
  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/users/${id}`);
  }

  createUser(user: createUser): Observable<CreatedResult> {
    return this.http.post<CreatedResult>(`${this.apiUrl}/users`, user);
  }

  updateUser(updateUser: UpdateUser) {
    return this.http.put<CreatedResult>(`${this.apiUrl}/users/${updateUser.userId}`, updateUser);
  }

  me() {
    return this.http.get<ListedUsers>(`${this.apiUrl}/users/me`);
  }

  changePassword(changePassword: ChangePassword) {
    return this.http.put<CreatedResult>(`${this.apiUrl}/users/me/change-password`, changePassword);
  }

  resetPassword(id: string, resetPassword: ResetPassword) {
    return this.http.put<CreatedResult>(`${this.apiUrl}/users/${id}/reset-password`, resetPassword);
  }

  deleteUser(id: string): Observable<DeletedResult> {
    return this.http.delete<DeletedResult>(`${this.apiUrl}/users/${id}`);
  }

  generateRandomPassword(length: number = 6) {
    const characters = '0123456789';
    let result = '';

    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * characters.length));
    }

    return result;
  }
}
