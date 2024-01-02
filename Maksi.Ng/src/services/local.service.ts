import { Injectable } from "@angular/core";

@Injectable({providedIn : "root"})
export class LocalService 
{
    put(name : string, value : string ) 
    {
        localStorage.setItem(name, value)
    }

    get (name : string) : string | null
    {
        return localStorage.getItem(name);
    }
}