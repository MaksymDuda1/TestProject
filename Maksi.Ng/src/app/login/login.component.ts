import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { concatWith } from 'rxjs';
import { User } from '@models/user';
import { LocalService } from '@services/local.service';
import { LoginService } from '@services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  email : string = "";
  password : string = "";

  errorMessage : string = "";

  constructor (private loginService : LoginService,
    private localService : LocalService, private router : Router)
  {

  }

  onLogin()
  {
    let user = new User();

    user.email = this.email;
    user.password = this.password;

    this.loginService.login(user).subscribe(data =>
      {
        this.localService.put(LocalService.AuthTokenName, data);
        window.location.href = "/";

      },
      errorResponse =>
      {
        this.errorMessage = errorResponse.error;
      });
  }
}
