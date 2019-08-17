import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SecurityService } from '../shared/security.service';
import { ProblemaService } from '../problemas/problema.service';
import { Problema } from '../problemas/problema.model';
import { CadProblema } from '../cad-problemas/cad-problema.model';
import { CadProblemasService } from '../cad-problemas/cad-problemas.service';

@Component({
  selector: 'app-problemacreate',
  templateUrl: './problemacreate.component.html',
  styleUrls: ['./problemacreate.component.scss']
})
export class ProblemaCreateComponent implements OnInit {

  cadProblemas: CadProblema[];
  cadProblemaCodigo: string;

  problema = new Problema();
  submitted = false;

  constructor(private problemaService: ProblemaService,
              private router: Router, private secService: SecurityService,
              private cadProblemasService: CadProblemasService) {}

  ngOnInit() {
    this.problema.quemReportou = this.secService.UserData.nome;
    this.getCadProblemas();
  }

  getCadProblemas() {
    this.cadProblemasService.getCadProblemas().subscribe (
      dados => { this.cadProblemas = dados;  });
  }
  selectCadProblema() {
    this.problema.codigo = this.cadProblemaCodigo;
    this.problema.descricao = this.cadProblemas[this.cadProblemaCodigo].descricao;
  }

  newProblema(): void {
    this.submitted = false;
    this.problema = new Problema();
  }

  save() {
    this.problemaService.createProblema(this.problema)
      .subscribe(data => console.log(data), error => console.log(error));
    this.problema = new Problema();
    this.gotoList();
  }

  onSubmit() {
    this.submitted = true;
    this.save();
  }

  gotoList() {
    this.router.navigate(['/problemas']);
  }
}
