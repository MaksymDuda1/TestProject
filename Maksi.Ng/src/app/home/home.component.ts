import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProtectedService } from '@services/protected.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  secret : string = '';

  constructor(private protectedService : ProtectedService,
    private snackBar : MatSnackBar)
  {

  }

  onGetSecret()
  {
    this.protectedService.getSecret().subscribe(secret => 
      {
        this.secret = secret;
      },
      errorResponse => 
      {
        this.snackBar.open("No acess");
      }
      );
  }
}
