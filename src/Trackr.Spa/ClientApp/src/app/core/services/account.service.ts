import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private accountUrl = environment.apiUrl + '/account';

  constructor(private http: HttpClient) { }

  signup(email: string, password: string, confirmPassword: string): Observable<any> {
    const url = this.accountUrl + '/signup';
    return this.http.post<any>(url, { email, password, confirmPassword });
  }
}
