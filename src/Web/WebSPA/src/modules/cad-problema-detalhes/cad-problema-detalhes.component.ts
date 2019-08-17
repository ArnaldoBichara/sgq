import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CadProblema } from '../cad-problemas/cad-problema.model';
import { CadProblemasService } from '../cad-problemas/cad-problemas.service';

@Component({
  selector: 'app-cad-problema-detalhes',
  templateUrl: './cad-problema-detalhes.component.html',
  styleUrls: ['./cad-problema-detalhes.component.scss']
})
export class CadProblemaDetalhesComponent implements OnInit {


  codigo: string;
  cadProblema: CadProblema;

  constructor(private route: ActivatedRoute, private router: Router, private cadProblemasService: CadProblemasService) { }

  ngOnInit() {
    this.cadProblema = new CadProblema();

    this.codigo = this.route.snapshot.params.codigo;

    this.cadProblemasService.getCadProblema(this.codigo)
      .subscribe(data => {
        console.log(data);
        this.cadProblema = data;
      }, error => console.log(error));
  }

  list() {
    this.router.navigate(['cadProblemas']);
  }
}
