import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { CadProblemasComponent } from './cad-problemas/cad-problemas.component';
import { CadProblemaCreateComponent } from './cad-problema-create/cad-problema-create.component';
import { CadProblemaDetalhesComponent } from './cad-problema-detalhes/cad-problema-detalhes.component';
import { ProblemaComponent } from './problemas/problema.component';
import { ProblemaCreateComponent } from './problemacreate/problemacreate.component';
import { ProblemaDetalhesComponent } from './problemadetalhes/problemadetalhes.component';
import { IdentityComponent } from './identity/identity.component';
import { CadAtivsComponent } from './cad-ativs/cad-ativs.component';


export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Home', component: HomeComponent },
  { path: 'cadProblemas', component: CadProblemasComponent },
  { path: 'detalhesCadProblema/:codigo', component: CadProblemaDetalhesComponent },
  { path: 'addCadProblema', component: CadProblemaCreateComponent },
  { path: 'problemas', component: ProblemaComponent },
  { path: 'detalhesProblema/:id', component: ProblemaDetalhesComponent },
  { path: 'addProblema', component: ProblemaCreateComponent },
  { path: 'cadAtivs', component: CadAtivsComponent },
  { path: 'login', component: IdentityComponent },
 // { path: '**', redirectTo: 'Home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
