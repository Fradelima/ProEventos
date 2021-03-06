import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/Services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef = {} as BsModalRef;
  public eventos: Evento[] = [] ;
  public eventosFiltrados: any = [];
  larguraImg = 50;
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

 public filtrareventos(filtrarPor: string): Evento[] {
  filtrarPor = filtrarPor.toLocaleLowerCase();
  return this.eventos.filter(
    evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1,
    (evento: Evento) => evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1);

 }
  constructor(
              private eventoService: EventoService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private router: Router,
              private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetEventos();
    // this.spinner.show();

   // setTimeout(() => {
      /** spinner ends after 5 seconds */
   //   this.spinner.hide();
  //  }, 3000);
  }
  public AlterarImagem(): void {
    this.ExibirImg = !this.ExibirImg;
  }

   public GetEventos(): void {
       this.eventoService.getEventos().subscribe(
       (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
       },
      (error: any) => console.log(error),
      );
   }

   openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O Evento foi deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef.hide();
  }
detalheEvento(id: number): void {
this.router.navigate([`evento/detalhe/${id}`]);
}

}
