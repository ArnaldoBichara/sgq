import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { SecurityService } from '../shared/security.service';
import { StorageService } from '../shared/storage.service';
import { Usuario } from '../shared/usuario.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-identity',
  templateUrl: './identity.component.html',
  styleUrls: ['./identity.component.scss']
})
export class IdentityComponent implements OnInit {

    authenticated = false;
    private subscription: Subscription;
    Usuario: Usuario = new Usuario();
    submitted = false;
  
    constructor(private secService: SecurityService, private storeService: StorageService, private router: Router) {

    }

    ngOnInit() {
        console.log('identity component, checking authorized' + this.secService.IsAuthorized);
        this.authenticated = this.secService.IsAuthorized;

        if (this.authenticated) {
            if (this.secService.UserData) {
                this.Usuario.nome = this.secService.UserData.nome;
                this.Usuario.email = this.secService.UserData.email;
            }
        }
    }

    logoutClicked(event: any) {
        event.preventDefault();
        console.log('Logout clicked');
        this.logout();
    }

    logout() {
        this.secService.Logoff();
    }

    login() {
        this.submitted = true;
        this.secService.Authorize(this.Usuario);
        this.gotoHome();
      }
      
      gotoHome() {
        this.router.navigate(['/']);
      }
}

