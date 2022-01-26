import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './authentication/login/login.component';

const routes: Routes = [
  {path: '', pathMatch: 'full',component: AppComponent},
  { 
    path: 'auth',
    loadChildren: () => import('./authentication/authentication-routing.module')
                          .then(x => x.AuthenticationRoutingModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }