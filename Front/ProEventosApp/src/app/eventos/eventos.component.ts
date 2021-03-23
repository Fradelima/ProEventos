import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [] ;
  public eventosFiltrados: any = [];
  larguraImg = 100;
  margemImg = 2;
 ExibirImg = true;
  private filtrolistateste: string = '';

   public get filtrolista(): string {
  return this.filtrolistateste;
 }

 public set filtrolista( value: string) {
  this.filtrolistateste = value;
  this.eventosFiltrados = this.filtrolista ? this.filtrareventos(this.filtrolista) : this.eventos;
 }

 filtrareventos(filtrarPor: string): any {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
    (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1);
 }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetEventos();
  }
  AlterarImagem(): void {
    this.ExibirImg = !this.ExibirImg;
  }

   public GetEventos(): void {
       this.http.get('https://localhost:5001/api/Eventos').subscribe(
       response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
       },
      error => console.log(error));
   }
}
