import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { HomeComponentAdmin } from './home/home.component';
import { ClassRoomComponent } from './class-room/class-room.component';
import { GradeComponent } from './grade/grade.component';
import { AdminRoutingModule } from './admin.route';
import { MaterialModule } from '../_material/material.module';



@NgModule({
  declarations: [
    AdminComponent,
    SideMenuComponent,
    HomeComponentAdmin,
    ClassRoomComponent,
    GradeComponent
  ],
  imports: [
    CommonModule, 
    AdminRoutingModule,
    MaterialModule
  ]
})
export class AdminModule { }
