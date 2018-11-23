import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('identity')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  public get isAuthenticated(): boolean {
    if (this.userSubject.value) {
      return true;
    }
    return false;
  }

  login(email: string, password: string) {
    const url = 'api/auth/login';
    return this.http.post<any>(url, { email, password })
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('identity', JSON.stringify(user));
          this.userSubject.next(user);
        }
        return user;
      }));
  }

  logout() {
    localStorage.removeItem('identity');
    this.userSubject.next(null);
  }
}
