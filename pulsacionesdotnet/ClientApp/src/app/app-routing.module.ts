import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { PersonaConsultaComponent } from './pulsacion/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './pulsacion/persona-registro/persona-registro.component';

const routes:Routes=[
  {path: 'consulta', component: PersonaConsultaComponent},
  {path: 'registro', component: PersonaRegistroComponent},
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
