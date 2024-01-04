import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassRoomFormComponent } from './class-room-form.component';

describe('ClassRoomFormComponent', () => {
  let component: ClassRoomFormComponent;
  let fixture: ComponentFixture<ClassRoomFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClassRoomFormComponent]
    });
    fixture = TestBed.createComponent(ClassRoomFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
