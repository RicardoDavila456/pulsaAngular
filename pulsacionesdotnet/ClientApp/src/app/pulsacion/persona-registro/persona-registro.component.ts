import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  sex:string;
  durations=[{ title: "Femenino", value: "femenino" }, 
    { title: "masculino", value: "masculino" }];

  constructor(private personaService: PersonaService) { }
  ngOnInit(): void {
    this.persona = new Persona;
  }

  add(){
    this.persona.calcularpul();
    this.personaService.post(this.persona).subscribe(p=>{
      if(p!=null){
        alert('Se agrego una nueva persona');
        this.persona=p;
      }
    });
  }


}
