import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 @Output () cancelledRegister =  new EventEmitter ();
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {

  }
  register() {
    this.authService.register(this.model).subscribe(()  => {
      // console.log('Registered Successfully');
      this.alertify.success('Registered Successfully');
    }, error => {
      // console.log(error);
      this.alertify.error(error);

    });
    // console.log(this.model);
  }
  cancelled () {
    this.cancelledRegister.emit(false); // emit cancelled event to parent note instead of false we can emit any object
    // console.log('cancelled');
    this.alertify.message('cancelled');
  }
}
