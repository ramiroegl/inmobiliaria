import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Login} from "../models/login";
import {LoginResult} from "../models/login-result";

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private apiUrl: string = environment.API_URL;
    private tokenKey = 'auth_token';
    constructor(private http: HttpClient) {
    }

    login(login: Login): Observable<LoginResult> {
        return this.http.post<LoginResult>(`${this.apiUrl}/users/login`, login);
    }

    saveToken(token: string) : void {
        localStorage.setItem(this.tokenKey, token);
    }

    logout(): void {
        localStorage.removeItem(this.tokenKey);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    isLoggedIn(): boolean {
        return this.getToken() !== null;
    }
}
