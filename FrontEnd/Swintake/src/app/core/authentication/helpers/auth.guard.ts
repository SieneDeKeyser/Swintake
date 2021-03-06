import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivate,
    Router,
    RouterStateSnapshot
} from '@angular/router';

import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(
        private authService: AuthService,
        protected router: Router
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {
        if (this.authService.isAuthenticated.toString().length > 20){
            return true;
        }
        else if (this.authService.isAuthenticated.token){
            return true;
        }
            this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
            return false;
        
    }
}
