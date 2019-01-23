import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/services/auth.service';
import { LoggedInUser } from '../core/authentication/classes/loggedInUser';
import { UserAuth } from '../core/authentication/classes/userAuth';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],

})

export class HeaderComponent {
  currentUser: LoggedInUser = new LoggedInUser();
  currentUserToken: UserAuth;
  isAuhtenticated: boolean = this.authService.isAuthenticated()
  currentUserName: string;

  constructor(private authService: AuthService, private router: Router, private modalService: NgbModal) {
    this.authService.tokenInfo.subscribe(t => { this.currentUserToken = t });
    if (this.isAuhtenticated)
    {
      this.currentUserName = this.getCurrentUserName();
      console.log(this.getCurrentUserName())
    }
  }

  ngOnInit() {
    console.log(this.isAuhtenticated);
    if (this.isAuhtenticated)
    {
      this.getCurrentUserName();
      console.log(this.getCurrentUserName())
    }
  }

  logOut() {
    this.isAuhtenticated = false;
    this.authService.logout();
    this.currentUser = new LoggedInUser();
    this.router.navigate(['/login']);
  }

  getCurrentUserName(): string {
    if (this.isAuhtenticated) {
      this.authService.getCurrentUser().pipe(first()).subscribe(
        user => {
          this.currentUser = user;
          this.currentUserName = user.firstName;
        });
    }
    return `${this.currentUser.firstName}`;
  }
}

