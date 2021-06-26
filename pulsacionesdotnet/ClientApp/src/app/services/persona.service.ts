import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Persona } from '../pulsacion/models/persona';
import { catchError, tap} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl:string
  constructor(private http:HttpClient,
    @Inject ('BASE_URL') baseUrl : string) { 
      this.baseUrl=baseUrl;
    }

    get():Observable<Persona[]>{
      return this.http.get<Persona[]>(this.baseUrl+'api/persona').pipe(
        tap(),
        catchError(error=>{
          console.log('se ha presentado un error al registrar los datos')
          return of(error as Persona[])
        })
      );
      
    }

  post(persona:Persona):Observable<Persona>{
    return this.http.post<Persona>(this.baseUrl+'api/persona',persona).pipe(
      tap(_=>console.log("Los datos se guardaron Stisfactoriamente")),
      catchError(error=>{
        console.log('se ha presentado un error al registrar los datos')
        return of(persona)
      })
    )
  }
}
