import {HttpClient} from "@angular/common/http"
import { Observable } from "rxjs";
import { User } from "../models/user";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })

export class userService
{
    constructor(private client : HttpClient){}

    getAll() : Observable<User[]> 
    {
        return this.client.get<User[]>("api/user");
    }

    add(user : User) : Observable<any>
    {
        return this.client.post("/api/user", user);
    }

}