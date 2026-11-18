import { Component, input, OnInit } from '@angular/core';
import { Paciente } from '../models/paciente.interface';

@Component({
  selector: 'app-listarPaciente',
  templateUrl: 'listarPaciente.html',
  standalone: true,
  imports: [],
})
export class ListarPacienteComponent implements OnInit {
  data = input.required<Paciente[]>();

  constructor() {}

  ngOnInit() {}
}
