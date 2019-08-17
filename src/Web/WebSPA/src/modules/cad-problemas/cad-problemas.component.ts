import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CadProblemasService } from './cad-problemas.service';
import { CadProblema } from './cad-problema.model';


@Component({
  selector: 'app-cad-problemas',
  templateUrl: './cad-problemas.component.html',
  styleUrls: ['./cad-problemas.component.scss']
})
export class CadProblemasComponent implements OnInit {

  cadProblemas: Observable<CadProblema[]>;

  constructor(private cadProblemasService: CadProblemasService, private router: Router) { }

  ngOnInit() {
      this.reloadData();
  }
  reloadData() {
    this.cadProblemas = this.cadProblemasService.getCadProblemas();
  }
  cadProblemaDetalhes(codigo: string) {
    this.router.navigate(['detalhesCadProblema', codigo]);
  }
}
