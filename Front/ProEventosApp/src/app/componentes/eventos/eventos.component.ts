
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/Services/evento.service';
// import { Evento } from '../models/Evento';
// import { EventoService } from '../Services/evento.service';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  //  , providers: [EventoService]  segunda maneira de injetar um serviço no  componente
})
export class EventosComponent implements OnInit {
 ngOnInit(): void {

 }
}
