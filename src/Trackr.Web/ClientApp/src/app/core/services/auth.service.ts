import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';

export const TOKEN_NAME: string = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  getToken(): string {
    return localStorage.getItem(TOKEN_NAME);
  }

  setToken(token: string): void {
    localStorage.setItem(TOKEN_NAME, token);
  }

  getTokenExpirationDate(token: string): Date {
    const decoded = jwt_decode(token);
    console.log(decoded);
    if (decoded.exp === undefined) return null;

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    console.log(date);
    return date;
  }

  public get isAuthenticated(): boolean {
    const token = this.getToken();
    if (token) {
      const tokenDate = this.getTokenExpirationDate(token);
      if (tokenDate === undefined) return false;
      return (tokenDate.valueOf() > new Date().valueOf());
    }
    return false;
  }

  login(email: string, password: string): Observable<any>{
    const url = 'api/auth/login';
    return this.http.post<any>(url, { email, password })
      .pipe(map(resp => {
        if (resp.token) {
          this.setToken(resp.token);
        }
      }));
  }

  logout() {
    localStorage.removeItem(TOKEN_NAME);
  }
}
