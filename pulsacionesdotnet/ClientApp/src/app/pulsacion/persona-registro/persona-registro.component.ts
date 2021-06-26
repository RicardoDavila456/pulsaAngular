import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  formGroup: FormGroup;
  persona: Persona;



  constructor(private personaService: PersonaService,private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.buildForm();
  }


  private buildForm() {
    this.persona = new Persona();
    this.persona.identificacion = '';
    this.persona.nombre = '';
    this.persona.edad = 0;
    this.persona.pulsacion = 0;
    this.persona.sexo = '';
    this.formGroup = this.formBuilder.group({
      identificacion: [this.persona.identificacion, Validators.required],
      nombre: [this.persona.nombre, Validators.required],
      sexo: [this.persona.sexo, Validators.required],
      edad: [this.persona.edad, [Validators.required, Validators.min(1)]]
    });
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }
  add(){
    this.persona = this.formGroup.value;
    console.log(this.persona.pulsacion);
    this.personaService.post(this.persona).subscribe(p=>{
      if(p!=null){
        alert('Se agrego una nueva persona');
        this.persona=p;
      }
    });
  }

  get control() { return this.formGroup.controls; }
}
