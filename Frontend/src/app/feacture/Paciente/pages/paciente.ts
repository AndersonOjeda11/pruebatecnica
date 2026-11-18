import { Component, inject, OnInit, signal } from '@angular/core';
import { PacienteService } from '../service/paciente.service';
import { Paciente } from '../models/paciente.interface';
import { ListarPacienteComponent } from '../components/listarPaciente';

@Component({
  standalone: true,
  selector: 'app-paciente',
  templateUrl: 'paciente.html',
  imports: [ListarPacienteComponent],
})
export class PacienteComponent implements OnInit {
  private readonly servicePaciente = inject(PacienteService);

  listPacientes = signal<Paciente[]>([]);

  ngOnInit() {
    this.obtenerPacientes();
  }

  obtenerPacientes() {
    this.servicePaciente.getPacientes().subscribe({
      next: (pacientes) => {
        this.listPacientes.set(pacientes);
        console.log(pacientes);
      },
      error: (error) => {
        console.error('Error al obtener los pacientes:', error);
      },
    });
  }
}
