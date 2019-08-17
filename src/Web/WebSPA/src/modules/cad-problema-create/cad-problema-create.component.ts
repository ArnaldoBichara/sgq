import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CadProblemasService } from '../cad-problemas/cad-problemas.service';
import { CadProblema } from '../cad-problemas/cad-problema.model';

@Component({
  selector: 'app-cad-problema-create',
  templateUrl: './cad-problema-create.component.html',
  styleUrls: ['./cad-problema-create.component.scss']
})
export class CadProblemaCreateComponent implements OnInit {

  cadProblema: CadProblema = new CadProblema();
  submitted = false;

  constructor(private cadProblemasService: CadProblemasService,
    private router: Router) { }

  ngOnInit() {
  }
  newCadProblema(): void {
    this.submitted = false;
    this.cadProblema = new CadProblema();
  }

  save() {
    this.cadProblemasService.createCadProblema(this.cadProblema)
      .subscribe(data => console.log(data), error => console.log(error));
    this.cadProblema = new CadProblema();
    this.gotoList();
  }

  onSubmit() {
    this.submitted = true;
    this.save();
  }

  gotoList() {
    this.router.navigate(['/cadProblemas']);
  }
}
