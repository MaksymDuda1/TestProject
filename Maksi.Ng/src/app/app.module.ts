import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { TopMenuComponent } from './top-menu/top-menu.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { LocalService } from '@services/local.service';
import { MaterialModule } from './_material/material.module';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

function jwtFactory(localService : LocalService){
  return {
    tokenGetter :() => {
      return localService.get(LocalService.AuthTokenName);
    }
  }
}

@NgModule({
  declarations: [
    AppComponent,
    TopMenuComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    
    
    JwtModule.forRoot({
      jwtOptionsProvider : {
      provide : JWT_OPTIONS,
      useFactory : jwtFactory,
      deps: [LocalService]
     } 
    })
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
