import { Component, NgModule, OnInit } from '@angular/core';
import { userService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})

export class AppComponent implements OnInit {
  title = 'Front-end';
  users : User[] = [];

  constructor(private userService : userService) {}

  ngOnInit(): void {
    this.userService.getAll().subscribe(data => {
      this.users = data;
    })
  }

  onButtonClick() : void
  {
    let user = new User();
    user.id = 4;
    user.email = "email@email.com";
    user.password = "qwertqwe"
    this.userService.add(user).subscribe(data => {
      console.log("User added");      
    });
  }
}
