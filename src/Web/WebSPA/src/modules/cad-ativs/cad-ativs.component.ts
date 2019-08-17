import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CadAtivService } from './cad-ativ.service';
import { CadAtividade } from './cad-ativ.model';

@Component({
  selector: 'app-cad-ativ',
  templateUrl: './cad-ativs.component.html',
  styleUrls: ['./cad-ativs.component.scss']
})
export class CadAtivsComponent implements OnInit {

    cadAtivs: Observable<CadAtividade[]>;

    constructor(private cadAtivService: CadAtivService, private router: Router) { }

    ngOnInit() {
        this.reloadData();
    }
    reloadData() {
      this.cadAtivs = this.cadAtivService.getCadAtivs();
    }
    cadAtivDetalhes(codigo: string) {
      this.router.navigate(['detalhesCadAtiv', codigo]);
    }
  }
