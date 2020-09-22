import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FrontComponent } from "./front/front.component";
import { NumberplateInformationComponent } from "./numberplate-information/numberplate-information.component";

const routes: Routes = [
  { path: '', redirectTo:'/front', pathMatch:'full'},
  { path:'front', component:FrontComponent},
  { path: 'numberplate-information/:id', component:NumberplateInformationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
