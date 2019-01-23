import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators'
import { Observable, of, BehaviorSubject } from 'rxjs';
import { UserAuth } from '../classes/userAuth';
import { LoggedInUser } from '../classes/loggedInUser';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable()

export class AuthService {

  private tokenInfoSubject: BehaviorSubject<UserAuth>;
  public tokenInfo: Observable<UserAuth>;

  private userUrl = ApiUrl.urlUsers;
  private jwtHelper: JwtHelperService;

  
  constructor(private http: HttpClient) {
    this.tokenInfoSubject = new BehaviorSubject<UserAuth>(JSON.parse(sessionStorage.getItem('tokenInfo')));
    this.tokenInfo = this.tokenInfoSubject.asObservable();
    this.jwtHelper = new JwtHelperService();
  }

  get currentUserTokenValue(): UserAuth{
    return this.tokenInfoSubject.value;
  }

  public isAuthenticated(): boolean{
    const token = localStorage.getItem('tokenInfo');
    if  (token)
    {
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  login(email: string, password: string) {
    return this.http.post<any>(`${this.userUrl}authenticate`, { email, password })
      .pipe(map(user => {
        if (user) {
          localStorage.setItem('tokenInfo', user);
          this.tokenInfoSubject.next(user);
        }
        return user;
      }));
  }

  getCurrentUser(): Observable<LoggedInUser> {
    return this.http.get<LoggedInUser>(`${this.userUrl}current`);
  }

  logout() {
    localStorage.removeItem('tokenInfo');
    this.tokenInfoSubject.next(null);
  }
}
