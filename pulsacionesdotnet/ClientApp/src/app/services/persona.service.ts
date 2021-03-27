import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Persona } from '../pulsacion/models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor() { }

  get(): Observable<Persona[]> {
    let personas: Persona[] = [];
    personas=JSON.parse(localStorage.getItem('datos'));
    return of(personas);
  }

  post(persona: Persona):Observable<Persona>{
    let personas: Persona[] = [];
    let localeDatos=localStorage.getItem('datos');
    if(localeDatos!=null){
      personas = JSON.parse(localeDatos);
    }
    personas.push(persona);
    localStorage.setItem('datos',JSON.stringify(personas));
    return of(persona);
  }
}
