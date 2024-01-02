import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ClassRoom } from "@models/class-room";

@Injectable({providedIn: 'root'})
export class ClassRoomService{

    url : string = "/api/class-room"
    constructor(private client : HttpClient){

    }

    list() : Observable<ClassRoom[]>{
        return this.client.get<ClassRoom[]>(this.url)
    }
}