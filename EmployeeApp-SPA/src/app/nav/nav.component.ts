import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService) {}

  ngOnInit() {}

  login() {
    // console.log(this.model);

    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Logged in successfully');
    });
  }
  loggedIn () {
    const token = localStorage.getItem('token');
    return !!token; // return true or false
  }
  logout () {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
