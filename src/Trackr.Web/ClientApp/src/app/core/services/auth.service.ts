import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';

export const TOKEN_NAME: string = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private manager = new UserManager(getClientSettings());
  private user: User = null;

  constructor() {
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
    return this.manager.signinRedirect();
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;
    });
  }

  logout() {
    localStorage.removeItem(TOKEN_NAME);
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'https://localhost:51864/',
    client_id: 'TrackrWebClient',
    redirect_uri: 'http://localhost:51865/auth-callback',
    post_logout_redirect_uri: 'http://localhost:51865/',
    response_type: "code",
    scope: "openid profile TrackrAPI",
    filterProtocolClaims: true,
    loadUserInfo: true,
    userStore: new WebStorageStateStore({ store: window.localStorage })
  }
}
