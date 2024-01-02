import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "@models/user";

@Injectable({providedIn : "root"})

export class LoginService
{
    [x: string]: any;
    constructor(private client : HttpClient)
    {

    }

    login(user : User) : Observable<string>
    {
        return this.client.post("api/login", user, {responseType : "text"});
    }
}