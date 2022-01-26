import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';

const routes: Routes = [
  {
    path: 'contacts',
    pathMatch: 'full',
    component: ContactsComponent
  },
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