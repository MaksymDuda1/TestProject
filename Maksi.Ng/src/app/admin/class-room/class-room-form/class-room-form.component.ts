import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ClassRoom } from '@models/class-room';
import { ClassRoomService } from '@services/class-room.service';

@Component({
  selector: 'app-class-room-form',
  templateUrl: './class-room-form.component.html',
  styleUrls: ['./class-room-form.component.scss']
})

export class ClassRoomFormComponent {
  id : number = 0;
  

  form = new FormGroup({
    name: new FormControl("",Validators.compose([Validators.required, Validators.maxLength(20)]))
  });

  errorMessage : string = '';

  constructor(private classRoomService : ClassRoomService,
    private router : Router, private route : ActivatedRoute){
      this.route.paramMap.subscribe(params =>{
        this.id = parseInt(params.get('id') ?? "0");
        this.getDetail();
      })
  }

  private getDetail() {
    this.classRoomService.detail(this.id).subscribe(data => {
      this.form.controls.name.setValue(data.name);
    });
  }

  onSubmit(){
    let classRoom = new ClassRoom();
    classRoom.name = this.form.controls.name.value ?? "";

    classRoom.id = this.id;

    // if(this.validate()){
    //   return;
    // }

    if(classRoom.id){
      this.classRoomService.save(classRoom).subscribe(_ => {
        this.router.navigateByUrl("/admin/class-room");
      },errorResult=>{
        this.errorMessage = errorResult.error.errorList[0];
      });
    }else{
    this.classRoomService.add(classRoom).subscribe(_ => {
      this.router.navigateByUrl("/admin/class-room");
      }, errorResult=>{
        this.errorMessage = errorResult.error.errorList[0];
      });
    }
  }

  // validate(): boolean {

  //   if(this.name.length == 0){
  //     this.errorMessage == "Name shouldn't be empty";
  //     return false;
  //   }

  //   if(this.name.length > 20){
  //     this.errorMessage == "Name shouldn't be less than 20 symbols";
  //     return false;
  //   }

  //   return true;
  // }
  
}
