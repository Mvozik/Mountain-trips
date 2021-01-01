import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddTourFormComponent } from './components/add-tour-form/add-tour-form.component';
import { AppComponent } from './components/app-component/app.component';
import { MainpageComponent } from './components/mainpage/mainpage.component';
import { MyTracksComponent } from './components/my-tracks/my-tracks.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { TrackDetailsComponent } from './components/track-details/track-details.component';
const routes: Routes = [
  {
    path: '',
    component: MainpageComponent,
  },
  {
    path: 'my-tracks',
    component: MyTracksComponent,
    children: [
      {
        path: 'details/:id',
        component: TrackDetailsComponent,
      },
      {
        path: 'add',
        component: AddTourFormComponent,
      },
    ],
  },
  {
    path: 'register',
    component: RegisterFormComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
