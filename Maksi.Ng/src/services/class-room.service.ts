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

    add(data: ClassRoom) : Observable<ClassRoom>{
        return this.client.post<ClassRoom>(this.url, data);
    }

    save(data: ClassRoom) : Observable<ClassRoom>{
        return this.client.put<ClassRoom>(this.url, data);
    }

    detail(id : number): Observable<ClassRoom>{
        return this.client.get<ClassRoom>(this.url+ "/" + id)
    }

    delete(id: number) : Observable<any>{
        return this.client.delete<ClassRoom>(this.url + '/' + id);
    }
}