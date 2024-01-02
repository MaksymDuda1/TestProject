import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Grade } from "@models/grade";

Injectable({providedIn: "root"})
export class GradeService{
    url : string = "/api/grade"
    
    constructor(private client : HttpClient){

    }

    list() : Observable<Grade[]>{
        return this.client.get<Grade[]>(this.url);
    }


}