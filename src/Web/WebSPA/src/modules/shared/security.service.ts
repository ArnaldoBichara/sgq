import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { StorageService } from './storage.service';
import {Usuario} from './usuario.model';

@Injectable()
export class SecurityService {

    private actionUrl: string;
    private headers: Headers;
    private storage: StorageService;
    private authenticationSource = new Subject<boolean>();
    authenticationChallenge$ = this.authenticationSource.asObservable();
    private authorityUrl = '';
    public IsAuthorized: boolean;
    
    constructor(private http: Http, private router: Router, private route: ActivatedRoute, private storageService: StorageService) {
        // tslint:disable-next-line: deprecation
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
        this.storage = storageService;
        this.UserData = new Usuario;

/*        this.configurationService.settingsLoaded$.subscribe(() => {
            this.authorityUrl = this.configurationService.serverSettings.identityUrl;
            this.storage.store('IdentityUrl', this.authorityUrl);
        });
*/
        if (this.storage.retrieve('IsAuthorized') !== '') {
            this.IsAuthorized = this.storage.retrieve('IsAuthorized');
            if (this.IsAuthorized == true) {
                this.UserData.email = this.storage.retrieve('userEmail');
                this.UserData.nome = this.storage.retrieve('userName');
            }
            this.authenticationSource.next(true);
        }
    }

    public GetToken(): any {
        return this.storage.retrieve('authorizationData');
    }

    public ResetAuthorizationData() {
        this.storage.store('authorizationData', '');
        this.storage.store('authorizationDataIdToken', '');

        this.IsAuthorized = false;
        this.storage.store('IsAuthorized', false);

        this.storage.store('userName', '');
        this.storage.store('userEmail', '');
        this.UserData.nome = '';
        this.UserData.email = '';
    }
    public UserData: Usuario;

    public SetAuthorizationData(token: any, id_token: any, usuario: Usuario) {

        this.storage.store('authorizationData', token);
        this.storage.store('authorizationDataIdToken', id_token);
        this.IsAuthorized = true;
        this.storage.store('IsAuthorized', true);

        this.storage.store('userName', usuario.nome);
        this.storage.store('userEmail', usuario.email);
        this.UserData = usuario;
        // emit observable
        this.authenticationSource.next(true);

/*        this.getUserData()
            .subscribe(data => {
                this.UserData = data;
                this.storage.store('userData', data);
                // emit observable
                this.authenticationSource.next(true);
//                window.location.href = location.origin;
            },
            error => this.HandleError(error),
            () => {
                console.log(this.UserData);
            });
*/
    }
    public Authorize(usuario: Usuario) {
    
        this.ResetAuthorizationData();

        const authorizationUrl = this.authorityUrl + '/connect/authorize';
        // tslint:disable-next-line: variable-name
        const client_id = 'js';
        // tslint:disable-next-line: variable-name
        const redirect_uri = location.origin + '/';
        // tslint:disable-next-line: variable-name
        const response_type = 'id_token token';
        const scope = 'openid profile problemas workflow';
        const nonce = 'N' + Math.random() + '' + Date.now();
        const state = Date.now() + '' + Math.random();

        this.storage.store('authStateControl', state);
        this.storage.store('authNonce', nonce);

        // fazendo um curto circuito aqui. Sempre autoriza
        // validate nonce
        this.storage.store('authNonce', '');
        this.storage.store('authStateControl', '');

        console.log('AuthorizedCallback state and nonce validated, returning access token');

        this.SetAuthorizationData("1", "1", usuario);
    }


    public Logoff() {
        const authorizationUrl = this.authorityUrl + '/connect/endsession';

        const idtokenhint = this.storage.retrieve('authorizationDataIdToken');
        const postlogoutredirecturi = location.origin + '/';

/*        let url =
            authorizationUrl + '?' +
            'id_token_hint=' + encodeURI(idtokenhint) + '&' +
            'post_logout_redirect_uri=' + encodeURI(postlogoutredirecturi);
*/
        this.ResetAuthorizationData();

        // emit observable
        this.authenticationSource.next(false);
//        window.location.href = url;
    }

    public HandleError(error: any) {
        console.log(error);
        if (error.status === 403) {
            this.router.navigate(['/Forbidden']);
        } else if (error.status === 401) {
            // this.ResetAuthorizationData();
            this.router.navigate(['/Unauthorized']);
        }
    }

    private urlBase64Decode(str: string) {
        let output = str.replace('-', '+').replace('_', '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
            default:
                throw new Error('Illegal base64url string!');
        }

        return window.atob(output);
    }

/*    private getDataFromToken(token: any) {
        let data = {};
        if (typeof token !== 'undefined') {
            const encoded = token.split('.')[1];
            data = JSON.parse(this.urlBase64Decode(encoded));
        }

        return data;
    }
*/
/*    private getUserData = (): Observable<string[]> => {
        this.setHeaders();
        if (this.authorityUrl === '')
            this.authorityUrl = this.storage.retrieve('IdentityUrl');

        return this._http.get(this.authorityUrl + '/connect/userinfo', {
            headers: this.headers,
            body: ''
        }).pipe(map(res => res.json()));
    }

    private setHeaders() {
        // tslint:disable-next-line: deprecation
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');

        const token = this.GetToken();

        if (token !== '') {
            this.headers.append('Authorization', 'Bearer ' + token);
        }
    }
*/}