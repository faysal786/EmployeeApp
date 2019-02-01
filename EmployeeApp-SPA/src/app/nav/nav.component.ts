import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) {}

  ngOnInit() {}

  login() {
    // console.log(this.model);

    this.authService.login(this.model).subscribe(next => {
      // console.log('Logged in successfully');
      this.alertify.success('Logged in successfully');
    }, error => {
      // console.log(error);
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/members']);
    });
  }
  loggedIn () {
    return this.authService.loggedIn();
    /* const token = localStorage.getItem('token');
    return !!token; // return true or false */
  }
  logout () {
    localStorage.removeItem('token');
    // console.log('logged out');
    this.alertify.message('Logged out successfully');
    this.router.navigate(['/home']);
  }

}
