import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Problema } from '../problemas/problema.model';
import { ProblemaService } from '../problemas/problema.service';

@Component({
  selector: 'app-problemadetalhes',
  templateUrl: './problemadetalhes.component.html',
  styleUrls: ['./problemadetalhes.component.scss']
})
export class ProblemaDetalhesComponent implements OnInit {


  id: number;
  problema: Problema;

  constructor(private route: ActivatedRoute, private router: Router, private problemaService: ProblemaService) { }

  ngOnInit() {
    this.problema = new Problema();

    this.id = this.route.snapshot.params.id;

    this.problemaService.getProblema(this.id)
      .subscribe(data => {
        console.log(data);
        this.problema = data;
      }, error => console.log(error));
  }

  list() {
    this.router.navigate(['problemas']);
  }
}
