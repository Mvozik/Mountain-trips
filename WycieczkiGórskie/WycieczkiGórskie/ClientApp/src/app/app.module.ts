import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { AuthService } from "./services/auth.service";
import { TokenInterceptor } from "./auth/token.interceptor";
import { StoreModule } from '@ngrx/store';
import { loginReducer } from './reducers/login-state.reducer';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { MatButtonModule } from '@angular/material/button';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MyTracksComponent } from './components/my-tracks/my-tracks.component';
import { TrackDetailsComponent } from './components/track-details/track-details.component';
import { TrackService } from './services/track.service';
import { AddTourFormComponent } from './components/add-tour-form/add-tour-form.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatMomentDateModule } from "@angular/material-moment-adapter";
import { NgxMatFileInputModule } from '@angular-material-components/file-input';
import { MatSelectModule } from '@angular/material/select';
import { FilterComponent } from './components/filter/filter.component';
import { MatVideoModule } from 'mat-video';

@NgModule({
  declarations: [AppComponent,RegisterFormComponent,MainpageComponent, MyTracksComponent, TrackDetailsComponent,AddTourFormComponent,FilterComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatCardModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatInputModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    StoreModule.forRoot({
      loginState : loginReducer,
    }),
    MatButtonModule,
    NgbModule,
    
    MatDatepickerModule,
    MatMomentDateModule,
    MatFormFieldModule,
    MatSelectModule,
    NgxMatFileInputModule,
    MatVideoModule
  ],
  providers: [AuthService, TrackService,{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi:true}],
  bootstrap: [AppComponent],
  exports:[]
})
export class AppModule { }
