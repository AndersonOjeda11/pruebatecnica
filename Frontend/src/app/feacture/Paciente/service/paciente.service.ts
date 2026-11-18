import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Paciente } from '../models/paciente.interface';

@Injectable({ providedIn: 'root' })
export class PacienteService {
  private readonly apiUrl = 'https://localhost:44396/api/Paciente';
  private readonly http = inject(HttpClient);

  getPacientes(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(`${this.apiUrl}`);
  }
}
