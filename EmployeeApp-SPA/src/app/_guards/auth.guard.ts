import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/Auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { routerNgProbeToken } from '@angular/router/src/router_module';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authSerive: AuthService, private router: Router , private alertify: AlertifyService) {

  }
  canActivate(): boolean {
      // Yype script that can return any of the value either boolean promise etc.
    if (this.authSerive.loggedIn()) {
      return true;
    }
    this.alertify.error('You are not authorized to view!');
    this.router.navigate(['/home']);
    return false;
  }
}
