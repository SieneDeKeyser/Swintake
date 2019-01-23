import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { User } from '../classes/user';
import { of } from 'rxjs'
import { LoggedInUser } from '../classes/loggedInUser';
import { ApiUrl } from '../../CommonUrl/CommonUrl';

fdescribe('AuthService', () => {
  let httpClient: HttpClient;
  let authService: AuthService;

  beforeEach(() => {
    httpClient = ({ get: null, post: null } as unknown) as HttpClient;
    authService = new AuthService(httpClient);
  });

  it('should return token', () => {

    let user: User = {
      Email: 'caroline@switchfully.com',
      Password: 'Passwoord123'
    };
    spyOn(httpClient, 'post').and.callFake((url: string) => {
      expect(url).toBe(`${ApiUrl.urlUsers}authenticate`);
      return of("testToken");
    });

    authService.login(user.Email, user.Password)
      .subscribe((result: string) =>
        expect(result).toEqual("testToken"));
  });

  it('should return current username', () => {
    let user: LoggedInUser = {
      firstName: 'Caroline'
    };
    spyOn(httpClient, 'get').and.callFake((url :string) => {
      expect(url).toBe(`${ApiUrl.urlUsers}current`);
      return of(user);
    });

    authService.getCurrentUser()
    .subscribe((result: LoggedInUser) =>
    expect(result.firstName).toEqual("Caroline"));
  });

});
