import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { map, catchError, tap } from 'rxjs/operators'
import { Observable, of, BehaviorSubject, throwError } from 'rxjs';
import { UserAuth } from '../classes/userAuth';
import { LoggedInUser } from '../classes/loggedInUser';
import { ApiUrl } from '../../CommonUrl/CommonUrl';
import { JwtHelperService } from '@auth0/angular-jwt';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};


@Injectable()

export class AuthService {

  private currentUserTokenSubject: BehaviorSubject<UserAuth>;
  public currentUserToken: Observable<UserAuth>;

  private userUrl = ApiUrl.urlUsers;
  private jwtHelper: JwtHelperService;
  
  private logginIn = false;
  
  constructor(private http: HttpClient) {
    let userAuth = new UserAuth();
    userAuth.token = localStorage.getItem('tokenInfo');
    this.currentUserTokenSubject = new BehaviorSubject<UserAuth>(userAuth);
    this.currentUserToken = this.currentUserTokenSubject.asObservable();
  }

  public get isAuthenticated(){
    return this.currentUserTokenSubject.value;
  }

  login(email: string, password: string) {
    return this.http.post<any>(`${this.userUrl}authenticate`, { email, password})
      .pipe(
        map(user => {
          localStorage.setItem('tokenInfo', user);
          this.logginIn = true;
          this.currentUserTokenSubject.next(user);
        return true;
      }),
      catchError(err => {return throwError(err);}));
  }

  getCurrentUser(): Observable<LoggedInUser> {
    return this.http.get<LoggedInUser>(`${this.userUrl}current`);
  }

  logout() {
    if (localStorage.getItem('tokenInfo'))
    {
      localStorage.removeItem('tokenInfo');
    }
    this.currentUserTokenSubject.next(null);
  }
}
