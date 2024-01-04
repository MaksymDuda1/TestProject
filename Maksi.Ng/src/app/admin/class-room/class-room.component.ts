import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ClassRoom } from '@models/class-room';
import { ClassRoomService } from '@services/class-room.service';
import { Observable } from 'rxjs';
import { ConfirmDeleteDialogComponent } from '../confirm-delete-dialog/confirm-delete-dialog.component';

@Component({
  selector: 'app-class-room',
  templateUrl: './class-room.component.html',
  styleUrls: ['./class-room.component.scss']
})
export class ClassRoomComponent {


  list$ : Observable<ClassRoom[]>;

  displayedColumns : string[] = ["id","name","actions"];

  constructor(private classRoomService : ClassRoomService,
   private dialog : MatDialog){
    this.list$ = this.classRoomService.list();
  }

  onShowConfirmDelete(id : number) {
      let dialogRef = this.dialog.open(ConfirmDeleteDialogComponent);

      dialogRef.afterClosed().subscribe(result =>{
        if(result){
          this.removeClassRoom(id);
        }
      })
  }

  private removeClassRoom(id : number){
    this.classRoomService.delete(id).subscribe(data =>{
      this.list$ = this.classRoomService.list();
    })
  }
}
