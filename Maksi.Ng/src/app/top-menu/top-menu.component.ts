import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalService } from '@services/local.service';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.scss']
})
export class TopMenuComponent implements OnInit{

  isAdmin : boolean = false;
  
  constructor(private jwtHelperService: JwtHelperService,
    private localService: LocalService){

  }
  ngOnInit(): void {
    let token = this.localService.get("auth-token");

    console.log(token)

    if(token)
    {
      let data = this.jwtHelperService.decodeToken(token);

      this.isAdmin = data.role == "Admin";
      console.log(data.role);
      
    }
  }
}
