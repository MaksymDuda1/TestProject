import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponentAdmin } from './home/home.component';
import { GradeComponent } from './grade/grade.component';
import { ClassRoomComponent } from './class-room/class-room.component';

const routes: Routes = [
  {path: "grade", component: GradeComponent},
  {path: "class-room", component: ClassRoomComponent},
  {path: "", component: HomeComponentAdmin},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
