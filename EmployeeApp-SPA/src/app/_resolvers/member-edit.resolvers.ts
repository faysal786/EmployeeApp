import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/Auth.service';

@Injectable()
export class MemberEditResolver implements Resolve<User> {
  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private router: Router,
    private authService: AuthService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
      return this.userService.getUser(this.authService.decodedToken.nameid).pipe(
        catchError (() => {
          this.alertify.error('Problem retriving params');
          this.router.navigate(['/member']);
          return of(null);
        })
      );

    }
}
