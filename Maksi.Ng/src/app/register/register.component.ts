import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RegisterUser, User } from 'src/models/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  public email : string = '';
  public password : string = '';

  public errorMessage : string = '';

  constructor(private userService : UserService,
    private snackBar : MatSnackBar)
  {
  }

  onRegister() {

    var user = new RegisterUser();

    user.email = this.email;
    user.password = this.password;

    this.userService.register(user).subscribe(data => 
      {
        this.snackBar.open("User is registred", "Close");
      },errorResult =>{
        this.errorMessage = errorResult.error;
      }); 
  }
}
