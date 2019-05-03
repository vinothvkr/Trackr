import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';
import { Router } from '@angular/router'

export const RETURN_URL: string = 'return_url';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private manager = new UserManager(getClientSettings());
  private user: User = null;

  constructor(
    private router: Router
  ) {
    this.manager.getUser().then(user => {
      this.user = user;
    })
  }

  public get isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  getCliams(): any {
    return this.user.profile;
  }

  getAuthorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  startAuthentication(): Promise<void> {
    return this.manager.signinRedirect(window.localStorage.setItem(RETURN_URL, window.location.pathname));
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;
      this.router.navigate([window.localStorage.getItem(RETURN_URL)]);
    });
  }

  logout(): Promise<void> {
    return this.manager.signoutRedirect();
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'https://localhost:51864',
    client_id: 'TrackrWebClient',
    redirect_uri: 'https://localhost:51866/auth-callback',
    post_logout_redirect_uri: 'https://localhost:51866',
    response_type: "code",
    scope: "openid profile TrackrAPI",
    filterProtocolClaims: true,
    loadUserInfo: true,
    userStore: new WebStorageStateStore({ store: window.localStorage })
  }
}
