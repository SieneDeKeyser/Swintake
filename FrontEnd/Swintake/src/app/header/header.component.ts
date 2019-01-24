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
  currentUser: LoggedInUser | null;
  isLoggedIn: UserAuth | null;
  currentUserName: string;

  constructor(private authService: AuthService, private router: Router, private modalService: NgbModal) {
    this.authService.currentUserToken.subscribe(
      data => {
        this.isLoggedIn = data;
        if (this.isLoggedIn) {
          
            this.getCurrentUserName();
       }
      }
    );
  
  }

  logOut() {
    this.currentUser = null;
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  getCurrentUserName() {
      return this.authService.getCurrentUser().subscribe(
         user => {
           this.currentUser = user;
           this.currentUserName = user.firstName;
         });     
}
}

