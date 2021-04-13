import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  // {providedIn: 'root'}  maneira de injetar um serviços nos componentes
)
export class EventoService {
baseURL = 'https://localhost:5001/api/Eventos';

constructor(private http: HttpClient) { }
  // tslint:disable-next-line:typedef
  getEventos(): Observable<Evento []>  {
  return this.http.get<Evento[]>(this.baseURL);
  }

  getEventosByTema(tema: string): Observable<Evento []>  {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
}

getEventosById(id: number): Observable<Evento>  {
  return this.http.get<Evento>(`${this.baseURL}/${id}`);
}

}
