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
    private session_key = 'session';
    constructor(private http: HttpClient) {
    }

    login(login: Login): Observable<LoginResult> {
        return this.http.post<LoginResult>(`${this.apiUrl}/users/login`, login);
    }

    saveToken(session: LoginResult) : void {
        var json = JSON.stringify(session);
        localStorage.setItem(this.session_key, json);
    }

    logout(): void {
        localStorage.removeItem(this.session_key);
    }

    getSession(): LoginResult | null {
        var json = localStorage.getItem(this.session_key);
        if (json === null) {
            return null;
        }
        return JSON.parse(json);
    }

    isLoggedIn(): boolean {
        return this.getSession() !== null;
    }
}
